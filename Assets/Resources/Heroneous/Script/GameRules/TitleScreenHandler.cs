using UnityEngine;
using System.Collections;

public class TitleScreenHandler : MonoBehaviour {
  
  public GameObject player_1;
  public GameObject player_2;
  public GameObject player_3;
  public GameObject player_4;

  public AudioClip voice_1;
  public AudioClip voice_2;
  public AudioClip voice_3;
  public AudioClip voice_4;
  public AudioClip sndAdd;
  public AudioClip sndRemove;

  public GameObject camera;

  private GameObject[] players;

	// Use this for initialization
	void Start () {
    players = new GameObject[4];

    players[0] = player_1;
    players[1] = player_2;
    players[2] = player_3;
    players[3] = player_4;

    for (int i = 0; i < 4; i++) {
      players[i].SetActive(false);
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
    camera.GetComponent<AudioSource> ().PlayOneShot (sndAdd, 0.6f);

    if (i == 0) {
      camera.GetComponent<AudioSource> ().PlayOneShot (voice_1, 1);
    } else if (i == 1) {
      camera.GetComponent<AudioSource> ().PlayOneShot (voice_2, 1);
    }else if (i == 2) {
      camera.GetComponent<AudioSource> ().PlayOneShot (voice_3, 1);
    }else if (i == 3) {
      camera.GetComponent<AudioSource> ().PlayOneShot (voice_4, 1);
    }
  }

  void removePlayer(int i) {
    GameManager.Instance.removePlayer(i);
    players[i].SetActive(false);
    camera.GetComponent<AudioSource> ().PlayOneShot (sndRemove);
  }
}