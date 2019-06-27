using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

public class RealManager : MonoBehaviour {

    public GameObject player1, player2;
    tempBulletInfinity TBI;
    DetectBullet DB;


    // Use this for initialization
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer(player1, "defend");
            UIGame.uiGame.ShieldMode.SetActive(true);
            PlayServices.playServices.UnlockAchievement(GPGSIds.achievement_room_master);
        }
        else
        {
            SpawnPlayer(player2, "shoot");
            UIGame.uiGame.ShootMode.SetActive(true);
            PlayServices.playServices.UnlockAchievement(GPGSIds.achievement_challenge_accepted);
            UIGame.uiGame.StartCOUNT = true;
        }
    }

    void SpawnPlayer(GameObject a, string alpha)
    {
        GameObject game = PhotonNetwork.Instantiate(a.name, a.transform.position, Quaternion.identity);
        game.gameObject.tag = alpha;

        tempBulletInfinity tbi = game.GetComponent<tempBulletInfinity>();
        DetectBullet db = game.GetComponentInChildren<DetectBullet>();
        if (tbi.photonView.IsMine) TBI = tbi;
        if (db.photonView.IsMine)DB = db;
    }

    public void Shoot() { TBI.GenerateBullet(); }
    public void Shield_Active()
    {
        DB.Shield_Active();
      //  DB.GetComponent<PhotonView>().RPC("Shield_Active", RpcTarget.AllBuffered);
    }
    public void Shield_Deactive()
    {
        DB.Shield_Deactive();
       // DB.GetComponent<PhotonView>().RPC("Shield_Deactive", RpcTarget.AllBuffered);
    }
}
