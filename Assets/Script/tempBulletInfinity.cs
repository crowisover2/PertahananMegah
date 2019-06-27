using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class tempBulletInfinity : MonoBehaviourPun, IPunObservable {

	public GameObject bullet;
    public GameObject Shield;
	public Transform SpawnPoint;
    public PhotonView photonView;

    //Text countDownTxt;
    //float oCount = 30;
    //float oCount_Serve = 99; 

    void Start()
    {
      //  countDownTxt = GameObject.Find("countDown").GetComponent<Text>();
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

    //void Update()
    //{
    //    //if (UIGame.uiGame.PHASE_TWO == true && oCount <= 0) oCount = 30f;
    //  //  countDownTxt.text = Convert.ToString((int)oCount);
    //    //if(PhotonNetwork.PlayerList.Length == 2)
    //    //{
    //    //    if(UIGame.uiGame.StartCOUNT)
    //    //    {
    //    //        oCount -= 0.01f;
    //    //    }
    //    //    else
    //    //    {
    //    //        countDownTxt.text = Convert.ToString((int)oCount_Serve);
    //    //        oCount = oCount_Serve;
    //    //    }
    //    //}

    //    //if(oCount <= 0)
    //    //{
    //    //    //StopCoroutine("Clock");
    //    //   // oCount = 0;
    //    //    countDownTxt.text = ("0");
    //    //    if(UIGame.uiGame.MINE == 0 || UIGame.uiGame.YOURS == 0)
    //    //    {
    //    //        if (!PhotonNetwork.IsMasterClient)
    //    //        {
    //    //            Change(true, false);
    //    //            //Change(false, true);
    //    //        }
    //    //        else
    //    //        {
    //    //                Change(false, true);
    //    //          //  UIGame.uiGame.PHASE_TWO = true;
    //    //            //    oCount = 30;
    //    //        }
    //            //if (photonView.IsMine)
    //            //{

    //            // }

    //            //if (UIGame.uiGame.StartCOUNT)
    //            //{
    //            //    Change(true, false);
    //            // //   UIGame.uiGame.StartCOUNT = false;
    //            //}
    //            //else if (oCount_Serve <= 0)
    //            //{
    //            //    Change(false, true);
    //            //    //       UIGame.uiGame.StartCOUNT = true;
    //            //}
    //    //    }
               
    //    //}
    //    //UIGame.uiGame.MINE = data2.score;
    //}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting){ stream.SendNext(UIGame.uiGame.oCount); }
        else if (stream.IsReading) UIGame.uiGame.oCount_Serve = (float)stream.ReceiveNext();
        //throw new System.NotImplementedException();
        
    }
}
