using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BulletWalksCopy : MonoBehaviourPun {

	public float scrollSpeed = 1.0f;
	public BulletEffect bulletEffect = BulletEffect.Null;

  //  public PhotonView pv;
   // public GameObject CharPrefab, BulletPrefab;

    IEnumerator DestroyPeluru()
    {
        yield return new WaitForSeconds(2f);
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
    }

	// Update is called once per frame
	void Update () {
        //this.transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);
        this.transform.position += Vector3.left * (scrollSpeed * Time.deltaTime);
        //if (this.transform.position.y <= -5)
        //{
        //    try
        //    {
        //        UIGame.uiGame.DT.value += 1;
        //    }
        //    finally
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
        //if (PhotonNetwork.IsMasterClient)
        //{

        //}
	}
    
    [PunRPC]
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
