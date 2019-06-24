using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks {
    //Launcher
    public GameObject MainButton;
    public SpriteRenderer con;
    public Color color1, Color2, Color3;

	void Start () {
        con.color = Color3;
        PhotonNetwork.ConnectUsingSettings();	
	}

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        con.color = color1;
    }

    public override void OnJoinedLobby()
    {
        con.color = Color2;
        MainButton.SetActive(true);
    }

    //Room
    public GameObject Room, Join, CreateRoom;
    public InputField NamaPlayer, NamaRoom;
    public Text notification;

    public void Join_Or_Create(bool temp)
    {
        if (temp)
        {
            Join.SetActive(false);
            CreateRoom.SetActive(true);
        }
        else
        {
            Join.SetActive(true);
            CreateRoom.SetActive(false);
        }

        Room.SetActive(true);
        MainButton.SetActive(false);
    }

    public void Join_Room()
    {
        PhotonNetwork.JoinRoom(NamaRoom.text, null);
    }

    public override void OnJoinedRoom()
    {
        print("Room Joined Success");
        PhotonNetwork.LoadLevel(1);
    }

    public void Create_Room()
    {
        PhotonNetwork.CreateRoom(NamaRoom.text, new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        notification.text = "Failed To Join Room" + returnCode + "Message" + message;
    }
}
