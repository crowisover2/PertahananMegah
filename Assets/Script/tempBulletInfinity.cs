using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBulletInfinity : MonoBehaviour {

	public GameObject bullet;
    public GameObject Shield;
	public Transform SpawnPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			GenerateBullet();
		}
	}
	
	public void GenerateBullet()
    {
        GameObject newBullet = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
        newBullet.transform.parent = Shield.transform;
    }
}
