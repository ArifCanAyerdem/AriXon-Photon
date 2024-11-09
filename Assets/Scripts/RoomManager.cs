using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{


public static RoomManager instance;

public GameObject Player;
[Space]
public Transform[] spawnPoints;
public GameObject roomCam;

public GameObject nameUI;
public GameObject connectingUI;
private string nickname="unnamed";

 void Awake() {
    
instance=this;

}

public void ChangeNickname(string _name){

nickname=_name;
}

public void JoinRoomButtonPressed(){

Debug.Log("Connecting to Photon");
        PhotonNetwork.ConnectUsingSettings();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);

}



    // Start is called before the first frame update
    void Start()
    {
      
    }

    

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby  ();
    }


    public override void OnJoinedLobby()
    {

base.OnJoinedLobby();
PhotonNetwork.JoinOrCreateRoom("test",null,null,null);

Debug.Log("Joined Lobby");


}
public override void OnJoinedRoom()
    {

base.OnJoinedRoom();


Debug.Log("Joined Lobby");

roomCam.SetActive(false);
SpawnPlayer();

}


public void SpawnPlayer(){

Transform spawnPoint=spawnPoints[UnityEngine.Random.Range(0,spawnPoints.Length)];

GameObject _player =PhotonNetwork.Instantiate(Player.name, spawnPoint.position, Quaternion.identity);
_player.GetComponent<PlayerSetup>().IsLocalPlayer();
_player.GetComponent<Health>().isLocalPlayer= true;

_player.GetComponent<PhotonView>().RPC("SetNickname",RpcTarget.AllBuffered,nickname);
PhotonNetwork.LocalPlayer.NickName=nickname;

}
 

}
