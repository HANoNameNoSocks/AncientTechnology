using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {

  public int ScoreToWin;
  public GameObject[] players;

	// Use this for initialization
	void Start () {

    for (int i = 0; i < 4; i++) {
      if (GameManager.Instance.isPlayerIn (i)) {
        players[i].gameObject.SetActive (true);
      } else {
        players[i].gameObject.SetActive (false);
      }
    }
	}
	
	// Update is called once per frame
	void Update () {
    for (int i = 0; i < 4; i++) {
      if (players [i].GetComponent<Greek> ().getScore () >= ScoreToWin) {
        print ("player " + (i + 1) + " won !");
      }
    }
	}
}
