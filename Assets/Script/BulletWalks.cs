using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWalks : MonoBehaviour {

	public float scrollSpeed = 1.0f;
	public BulletEffect bulletEffect = BulletEffect.Null;
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);
        if (this.transform.position.y <= -5)
        {
            try
            {
                UIGame.uiGame.DT.value += 1;
            }
            finally
            {
                Destroy(this.gameObject);
            }
        }
	}
    
}
