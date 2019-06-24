using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bulletSpawn : MonoBehaviourPun, IPunObservable {

    public GameObject projectilePrefab;
    public PhotonView photonView;

    Vector3 smoothPosition;
    public Sprite nD2;
    private float pVelocity = 3;

	// Use this for initialization
	void Start () {
        if (photonView.IsMine)
        {
            GetComponent<SpriteRenderer>().sprite = nD2;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.IsMine)
        {
            ProcessInput();
        }
        else
        {

        }
        
    }

    void SmoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothPosition, 2);
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * (2f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * (2f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * (2f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * (2f * Time.deltaTime);
        }
    }

    public void menembak()
    {
        //GameObject bullet;
        if(photonView.IsMine)PhotonNetwork.Instantiate(projectilePrefab.name, transform.position, Quaternion.identity);
        //Debug.Log(transform.position);
           // newBullet.transform.parent = Shield.transform;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    stream.SendNext(transform.position);
        //}
        //else if (stream.IsReading)
        //{
        //    smoothPosition = (Vector3)stream.ReceiveNext();
        //}
    }
}
