using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject playerPrefab1;
    bulletSpawn Pemain;
   // public Transform Spawn1;

	// Use this for initialization
	void Start () {
       //if (PhotonNetwork.IsMasterClient)
       //{
            SpawnPlayer1();
       //}
	}

    void SpawnPlayer1()
    {
        bulletSpawn player;
        player = PhotonNetwork.Instantiate(playerPrefab1.name, new Vector3(Random.Range(-5, 5), Random.Range(-2, 2)), Quaternion.identity).GetComponent<bulletSpawn>();
        if (player.photonView.IsMine)
        {
            Pemain = player;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Menembak()
    {
        Pemain.menembak();
    }
}
