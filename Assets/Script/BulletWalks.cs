using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BulletWalks : MonoBehaviourPun{

	public float scrollSpeed = 1.0f;
	public BulletEffect bulletEffect = BulletEffect.Null;

    BoxCollider2D bc2;
    PhotonView pv; 

    void Start()
    {
        pv = GetComponent<PhotonView>();
        bc2 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        this.transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);
        //this.transform.position += Vector3.left * (scrollSpeed * Time.deltaTime);
        if (this.transform.position.y <= -5)
        {
            if (!photonView.IsMine)
            {
                try
                {
                    UIGame.uiGame.DT.value += 1;
                    UIGame.uiGame.YOURS++;
                }
                finally
                {
                    // PhotonNetwork.Destroy(this.gameObject);
                    photonView.RPC("DESTROY", RpcTarget.AllBuffered);
                    // Destroy(this.gameObject);
                }
            }
            
        }
        //if (PhotonNetwork.IsMasterClient)
        //{

            //}
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(bc2);
    //    }
    //    else if(stream.IsReading)
    //    {
    //        bc2 = (BoxCollider2D)stream.ReceiveNext();
    //    }
    //}
    [PunRPC]
    public void DESTROY()
    {
        Destroy(this.gameObject);
    }

}
