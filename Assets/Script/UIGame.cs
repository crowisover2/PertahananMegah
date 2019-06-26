using System.Collections.Generic;
using Photon.Pun;
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
    public bool StartCOUNT = false;
    public Slider DT;

    public GameObject ShieldMode, ShootMode;
    public Text score;
    public int YOURS, MINE;

	// Use this for initialization
	void Start () {
        uiGame = this.GetComponent<UIGame>();
    }

    void Update()
    {
        score.text = "MINE = " + MINE + " || " + "YOURS = " + YOURS;
    }
	
	//public void Shield_Active(){
	//	if(UIGame.uiGame.DT.value > 1)Shield.active = nyala =true;
	//}
	//public void Shield_Deactive(){
	//	Shield.active = nyala = false;
	//}
}
