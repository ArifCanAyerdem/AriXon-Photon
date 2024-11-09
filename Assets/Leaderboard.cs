using UnityEngine;
using System.Linq;
using Photon.Pun;
using TMPro;
using Photon.Pun.UtilityScripts;

public class Leaderboard : MonoBehaviour
{
  

public GameObject playersHolder;

public float refreshRate=1f;

public GameObject[] slots;

public TextMeshProUGUI[] scoreTexts;
public TextMeshProUGUI[] nameTexts;


void Start()
{
    
    InvokeRepeating(nameof(Refresh),1f,refreshRate);

}



public void Refresh(){

foreach(var slot in slots){

slot.SetActive(false);

}

var sortedPlayerList=(from player in PhotonNetwork.PlayerList orderby player.GetScore()descending select player).ToList();

int i=0;
foreach(var player in sortedPlayerList){

    slots[i].SetActive(true);

    if(player.NickName =="")
    player.NickName="unnamed";


nameTexts[i].text=player.NickName;
scoreTexts[i].text=player.GetScore().ToString();


i++;


}


}

void Update()
{
    playersHolder.SetActive(Input.GetKey(KeyCode.Tab));
}



}
