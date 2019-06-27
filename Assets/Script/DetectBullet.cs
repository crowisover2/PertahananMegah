using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class DetectBullet : MonoBehaviourPun, IPunObservable {
    public GameObject Alpha, Beta;
    public PhotonView photonView;
    public Color ON, OFF;

    public SpriteRenderer Shield_ON;
    // Use this for initialization
    void Start()
    { 
        Alpha = GameObject.Find("Area_WithinRange");
        Beta = GameObject.Find("Area_OutsideRange");
        this.transform.parent = Alpha.transform.parent;

       // photonView.RPC("ALL_SHIELD_DOWN", RpcTarget.AllBuffered);
    }

    void Detect_Distance()
    {
        BulletWalks[] bulletWalks = FindObjectsOfType<BulletWalks>();
        foreach (BulletWalks item in bulletWalks)
        {
            float distance = Vector3.Distance(Alpha.transform.position, item.transform.position);
            float distance2 = Vector3.Distance(Beta.transform.position, item.transform.position);

            if (item.bulletEffect == BulletEffect.Null)
            {
                if (distance2 <= 2.6f)
                {
                    item.bulletEffect = BulletEffect.OutsideRange;
                }
                else
                {
                    item.bulletEffect = BulletEffect.Null;
                }

                if (item.bulletEffect == BulletEffect.Null)
                {
                    if (distance <= 0.5f)
                    {
                        item.bulletEffect = BulletEffect.WithinRange;
                    }
                    else
                    {
                        item.bulletEffect = BulletEffect.Null;
                    }
                }
                
            }
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Detect_Distance();
        }

        if(gameObject.transform.position.z > 60) { Shield_ON.color = ON; }
        else { Shield_ON.color = OFF; }
    }

    void OnTriggerEnter2D(Collider2D e)
    {
        if (photonView.IsMine && gameObject.transform.position.z > 60)
        {
            try
            {
                if (e.GetComponent<BulletWalks>().bulletEffect == BulletEffect.WithinRange)
                {
                    UIGame.uiGame.DT.value += 3;
                    Debug.Log("Within");
                    e.GetComponent<BulletWalks>().photonView.RPC("DESTROY", RpcTarget.AllBuffered);
                }
                else if (e.GetComponent<BulletWalks>().bulletEffect == BulletEffect.OutsideRange)
                {
                    UIGame.uiGame.DT.value -= 2;
                    Debug.Log("OutSIde");
                    e.GetComponent<BulletWalks>().photonView.RPC("DESTROY", RpcTarget.AllBuffered);
                }
            }
            catch
            {

            }
        }
        
    }
   [PunRPC]
    public void Shield_Active()
    {
        if (UIGame.uiGame.DT.value > 1)
           gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 64f);
    }
    [PunRPC]
    public void Shield_Deactive()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) { stream.SendNext(UIGame.uiGame.YOURS); }
        else if (stream.IsReading) UIGame.uiGame.MINE = (int)stream.ReceiveNext();
    }
}
