using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class Menu : MonoBehaviourPunCallbacks
{
    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private Text textStatus;
    [SerializeField]
    private GameObject buttonEnter;

    private bool isConnecting = false;
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 20;
    // Start is called before the first frame update
    void Start()
    {
        textStatus.enabled = false;
        Debug.Log("Start Photon Network");
    }
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void SearchForGame()
    {
        textStatus.enabled = true;
        buttonEnter.SetActive(false);
        textStatus.text = "Searching for Server";
        Debug.Log("Searching for Server");

        isConnecting = true;
        if (PhotonNetwork.IsConnected)
        {
            
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            textStatus.text = "Connected to Server";
            Debug.Log("Connecting to Server");
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        textStatus.text = "Connected to Server " + cause.ToString();
        Debug.Log("Disconnected from Server" + cause.ToString());
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
        Debug.Log(returnCode + "," + message);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Client succesfully joined room");
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.Log(debugMessage);
    }

}
