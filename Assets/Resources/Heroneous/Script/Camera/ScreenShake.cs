using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

  public float intensity;
  public float shakeTime;
  private float timer;

  void Start()
  {
    timer = shakeTime + 1;
  }

  void Update()
  {
    if (timer < shakeTime) {
      timer += Time.deltaTime;
      float verticalAmount = ((-1)*intensity) + (Random.value * intensity * 2);
      float horizontalAmount = ((-1)*intensity) + (Random.value * intensity * 2);;
      transform.position = new Vector3 (horizontalAmount, verticalAmount, -10);
    } else {
      transform.position = new Vector3 (0, 0, -10);
    }
  }

  public void shake()
  {
    timer = 0;
  }

}
