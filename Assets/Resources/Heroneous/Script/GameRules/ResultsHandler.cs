using UnityEngine;
using System.Collections;

public class ResultsHandler : MonoBehaviour {

  public GameObject[] players;

	// Use this for initialization
	void Start () {
    for (int i = 0; i < 4; i++) {
      if (i == GameManager.Instance.getWinner ()) {
        players [i].GetComponent<SpriteRenderer> ().enabled = true;
      } else {
        players [i].GetComponent<SpriteRenderer> ().enabled = false;
      }
    }
	}
	
	// Update is called once per frame
	void Update () {
    for (int i = 0; i < 4; i++) {
      if (ControllerManager.Instance.Controllers [i].GetMenuStart ()) {
        Application.LoadLevel ("MainMenu");
      }
    }
	}
}
