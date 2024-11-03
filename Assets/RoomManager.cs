using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{

public GameObject Player;
[Space]public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Photon");
        PhotonNetwork.ConnectUsingSettings();
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
GameObject _player =PhotonNetwork.Instantiate(Player.name, spawnPoint.position, Quaternion.identity);
_player.GetComponent<PlayerSetup>().IsLocalPlayer();
}

}
