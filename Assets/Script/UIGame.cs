using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BulletEffect{
	Null,
	WithinRange,
	OutsideRange
}

public class UIGame : MonoBehaviour {

	static public UIGame uiGame;
	public GameObject Shield;
	
	// Use this for initialization
	void Start () {
        uiGame = this.GetComponent<UIGame>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Shield_Active(){
		Shield.active =true;
	}
	public void Shield_Deactive(){
		Shield.active = false;
	}
}
