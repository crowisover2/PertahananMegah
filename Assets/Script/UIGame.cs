using System;
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
    public bool StartCOUNT = false, PHASE_TWO = false;
    public Slider DT;

    public GameObject ShieldMode, ShootMode, WIN, LOSE, DRAW, CHARP, CHARE;
    public Text score;
    public int YOURS, MINE;

    public Text countDownTxt;
    public float oCount = 30;
    public float oCount_Serve = 30;

    // Use this for initialization
    void Start () {
        uiGame = this.GetComponent<UIGame>();
    }

    void Update()
    {
        score.text = "MINE = " + MINE + "\n" + "YOURS = " + YOURS;
        countDownTxt.text = Convert.ToString((int)oCount);

        if (PhotonNetwork.PlayerList.Length == 2)
        {
            if (StartCOUNT)
            {
                oCount -= 0.01f;
            }
            else
            {
             //   countDownTxt.text = Convert.ToString((int)oCount_Serve);
                oCount = oCount_Serve;
            }
        }

        if (oCount <= 0)
        {
            countDownTxt.text = ("0");
            if (MINE == 0 || YOURS == 0)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    Change(false, true);
                   // if(StartCOUNT)oCount = 30;
                    //Change(false, true);
                }
                else
                {
                    Change(true, false);
                    // oCount = 30;
                }
            }
        }

        if (StartCOUNT)
        {
            if (oCount <= -2 && StartCOUNT)
            {
                oCount = 30;
                if (!PHASE_TWO) PHASE_TWO = true;
                else
                {
                    Change(false, false);
                    score.gameObject.SetActive(false);
                    countDownTxt.gameObject.SetActive(false);
                    CHARE.active = CHARP.active = false;
                    if (MINE > YOURS)
                    {
                        WIN.SetActive(true);
                    }
                    else if (YOURS > MINE)
                    {
                        LOSE.SetActive(true);
                    }
                    else
                    {
                        DRAW.SetActive(true);
                    }
                    oCount = 66;
                }
            }
        }
        else
        {
            if (oCount_Serve > 60 && oCount_Serve < 70)
            {
                Change(false, false);
                score.gameObject.SetActive(false);
                countDownTxt.gameObject.SetActive(false);
                CHARE.active = CHARP.active = false;
                if (MINE > YOURS)
                {
                    WIN.SetActive(true);
                }
                else if (YOURS > MINE)
                {
                    LOSE.SetActive(true);
                }
                else
                {
                    DRAW.SetActive(true);
                }
            }
        }
    }

    void Change(bool a, bool b)
    {
        ShieldMode.SetActive(a);
        ShootMode.SetActive(b);
        //if (StartCOUNT) oCount = 30;
    }

}
