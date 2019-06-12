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
    public bool nyala = false;
    public Slider DT;
	
	// Use this for initialization
	void Start () {
        uiGame = this.GetComponent<UIGame>();
        
    }
	
	public void Shield_Active(){
		if(UIGame.uiGame.DT.value > 1)Shield.active = nyala =true;
	}
	public void Shield_Deactive(){
		Shield.active = nyala = false;
	}
}
