using UnityEngine;
using System.Collections;

public class TitleScreenHandler : MonoBehaviour {
  
  public GameObject player_1;
  public GameObject player_2;
  public GameObject player_3;
  public GameObject player_4;

  private GameObject[] players;

	// Use this for initialization
	void Start () {
    players = new GameObject[4];

    players[0] = player_1;
    players[1] = player_2;
    players[2] = player_3;
    players[3] = player_4;

    for (int i = 0; i < 4; i++) {
      players[i].SetActive(false); ;
    }
	}
	
	// Update is called once per frame
	void Update () {
    for (int i = 0; i < 4; i++) {
      if (ControllerManager.Instance.Controllers [i].GetMenuConfirm ()){
        addPlayer(i);
      }

      if (ControllerManager.Instance.Controllers [i].GetMenuBack()){
        removePlayer(i);
      }

      if(ControllerManager.Instance.Controllers[i].GetMenuStart() && GameManager.Instance.isPlayerIn(i)){
        Application.LoadLevel("TestControles");
      }
	  }
  }

  void addPlayer(int i) {
    GameManager.Instance.addPlayer(i);
    players[i].SetActive(true);
    //players[i].GetComponent<SpriteRenderer>().enabled = true;
    //players[i].GetComponent<Greek>().enabled = true;
  }

  void removePlayer(int i) {
    GameManager.Instance.removePlayer(i);
    players[i].SetActive(false);
    //players[i].GetComponent<SpriteRenderer>().enabled = false;
    //players[i].GetComponent<Greek>().enabled = false;
  }
}