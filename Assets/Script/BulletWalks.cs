using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWalks : MonoBehaviour {

	public GameObject Alpha;
	public float scrollSpeed = 10.0f;
	BulletEffect bulletEffect = BulletEffect.Null;
	
	// Use this for initialization
	void Start () {
		Alpha = GameObject.Find("char_perisai");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);		
		if (this.transform.position.y <= -5) Destroy(this.gameObject);
		
	}
	
	void OnTriggerEnter2D(Collider2D e)
    {
        //the problem no lies in detect shield active or not
        if (UIGame.uiGame.Shield.active)
        {
            if (e.gameObject.name == "Area_OutsideRange")
			{
				bulletEffect = BulletEffect.OutsideRange;
				Debug.Log("OU");
			}
			else if (e.gameObject.name == "Area_WithinRange")
			{
				bulletEffect = BulletEffect.WithinRange;
				Debug.Log("WI");
			}
            //Debug.Log("Da");
        }
        else
        {
            bulletEffect = BulletEffect.Null;
        }
    }

}
