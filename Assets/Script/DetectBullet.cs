using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBullet : MonoBehaviour {
    public GameObject Alpha, Beta;

    // Use this for initialization
    void Start()
    {
        Alpha = GameObject.Find("Area_WithinRange");
        Beta = GameObject.Find("Area_OutsideRange");
    }

    void Detect_Distance()
    {
        BulletWalks[] bulletWalks = FindObjectsOfType<BulletWalks>();
        foreach (BulletWalks item in bulletWalks)
        {
            float distance = Vector3.Distance(Alpha.transform.position, item.transform.position);
            float distance2 = Vector3.Distance(Beta.transform.position, item.transform.position);

            if (item.bulletEffect == BulletEffect.Null)
            {
                if (distance2 <= 2.6f)
                {
                    item.bulletEffect = BulletEffect.OutsideRange;
                }
                else
                {
                    item.bulletEffect = BulletEffect.Null;
                }

                if (item.bulletEffect == BulletEffect.Null)
                {
                    if (distance <= 0.5f)
                    {
                        item.bulletEffect = BulletEffect.WithinRange;
                    }
                    else
                    {
                        item.bulletEffect = BulletEffect.Null;
                    }
                }
                
            }
        }
    }

    void FixedUpdate()
    {
        Detect_Distance();
    }

    void OnTriggerEnter2D(Collider2D e)
    {
        if (e.GetComponent<BulletWalks>().bulletEffect == BulletEffect.WithinRange)
        {
            UIGame.uiGame.DT.value += 3;
            Destroy(e.gameObject);
        }
        else if (e.GetComponent<BulletWalks>().bulletEffect == BulletEffect.OutsideRange)
        {
            UIGame.uiGame.DT.value -= 2;
            Debug.Log("F");
            Destroy(e.gameObject);
        }
        else
        {
            //score here
        }
    }
}
