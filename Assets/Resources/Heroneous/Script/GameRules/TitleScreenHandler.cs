using UnityEngine;
using System.Collections;

public class TitleScreenHandler : MonoBehaviour {

  public GameObject player_1;
  public GameObject player_2;
  public GameObject player_3;
  public GameObject player_4;

	// Use this for initialization
	void Start () {
    player_1.GetComponent<SpriteRenderer> ().enabled = false;
    player_2.GetComponent<SpriteRenderer> ().enabled = false;
    player_3.GetComponent<SpriteRenderer> ().enabled = false;
    player_4.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
    for (int i = 0; i < 4; i++) {
      if (ControllerManager.Instance.Controllers [i].GetMenuConfirm ()){
        GameManager.Instance.addPlayer(i);
      }

      if (ControllerManager.Instance.Controllers [i].GetMenuBack()){
          GameManager.Instance.removePlayer(i);
      }

      if(ControllerManager.Instance.Controllers[i].GetMenuStart()){
        Application.LoadLevel("TestControles");
      }
	  }

    if (GameManager.Instance.isPlayerIn (0)) {
      player_1.GetComponent<SpriteRenderer> ().enabled = true;
    } else {
      player_1.GetComponent<SpriteRenderer> ().enabled = false;
    }

    if (GameManager.Instance.isPlayerIn (1)) {
      player_2.GetComponent<SpriteRenderer> ().enabled = true;
    } else {
      player_2.GetComponent<SpriteRenderer> ().enabled = false;
    }

    if (GameManager.Instance.isPlayerIn (2)) {
      player_3.GetComponent<SpriteRenderer> ().enabled = true;
    } else {
      player_3.GetComponent<SpriteRenderer> ().enabled = false;
    }

    if (GameManager.Instance.isPlayerIn (3)) {
      player_4.GetComponent<SpriteRenderer> ().enabled = true;
    } else {
      player_4.GetComponent<SpriteRenderer> ().enabled = false;
    }
  }
}