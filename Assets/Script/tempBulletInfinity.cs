using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class tempBulletInfinity : MonoBehaviourPun, IPunObservable {

	public GameObject bullet;
    public GameObject Shield;
	public Transform SpawnPoint;
    public PhotonView photonView;

    Text countDownTxt;
    float oCount = 60;
    float oCount_Serve = 0; 

    void Start()
    {
        countDownTxt = GameObject.Find("countDown").GetComponent<Text>();
        Shield = GameObject.Find("GO");
    }

	public void GenerateBullet()
    {
        if (photonView.IsMine)
        {
            GameObject newBullet = PhotonNetwork.Instantiate(bullet.name, SpawnPoint.transform.position, Quaternion.identity);
            newBullet.transform.parent = Shield.transform;
        }
            
    }

    void Update()
    {
        countDownTxt.text = Convert.ToString((int)oCount);
        if(PhotonNetwork.PlayerList.Length == 2)
        {
            if(UIGame.uiGame.StartCOUNT)
            {
                oCount -= 0.01f;
            }
            else
            {
                countDownTxt.text = Convert.ToString((int)oCount_Serve);
                oCount = oCount_Serve;
            }
        }

        if(oCount <= 0)
        {
            //StopCoroutine("Clock");
            oCount = 0;
            countDownTxt.text = ("0");
        }
        //UIGame.uiGame.MINE = data2.score;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting){ stream.SendNext(oCount); }
        else if (stream.IsReading) oCount_Serve = (float)stream.ReceiveNext();
        //throw new System.NotImplementedException();
    }
}
