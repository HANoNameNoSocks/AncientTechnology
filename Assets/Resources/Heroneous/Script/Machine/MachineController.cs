using UnityEngine;
using System;
using System.Collections;

public class MachineController : MonoBehaviour {

  public float OrderTime;
  public float OrderTimeVariance;
  public float OrderVisibility;
  public GameObject Bulle;
  public GameObject ElementSprite;
  public GameObject camera;

  public AudioClip sndItem;
  public AudioClip sndOld_1;
  public AudioClip sndOld_2;
  public AudioClip sndOld_3;

  private double orderTime;
  private double orderDuration;
  private string currentOrder;

	// Use this for initialization
	void Start () {
    resetOrder ();
	}
	
	// Update is called once per frame
	void Update () {
    orderTime += Time.deltaTime;

    if (orderTime > orderDuration) {
      resetOrder ();
    }

    if (orderTime < OrderVisibility) {
      Bulle.GetComponent<SpriteRenderer> ().enabled = true;
      ElementSprite.GetComponent<SpriteRenderer> ().enabled = true;
    } else {
      Bulle.GetComponent<SpriteRenderer> ().enabled = false;
      ElementSprite.GetComponent<SpriteRenderer> ().enabled = false;
    }
	}

  void OnCollisionEnter2D(Collision2D collision)
  {
    Component script = collision.gameObject.GetComponent<MachineElement> ();
    if (script != null) {
      if (collision.gameObject.GetComponent<MachineElement>().getObjectType() == currentOrder) {
        collision.gameObject.GetComponent<MachineElement> ().getThrower ().GetComponent<Greek> ().incrementScore ();
        Destroy (collision.gameObject);
        camera.GetComponent<AudioSource> ().PlayOneShot (sndItem, 1);
        camera.GetComponent<ScreenShake> ().shake ();
        resetOrder ();
      }
    }
  }

  private void resetOrder()
  {
    orderTime = 0;
    orderDuration = getRandomDuration(OrderTime, OrderTimeVariance);
    currentOrder = ObjectTypesManager.Instance.getRandomItem();
    setElementImage ();

    int rand = (int)Math.Floor(UnityEngine.Random.value * 3);
    if (rand == 0) {
      camera.GetComponent<AudioSource> ().PlayOneShot (sndOld_1, 1);
    } else if (rand == 1) {
      camera.GetComponent<AudioSource> ().PlayOneShot (sndOld_2, 1);
    } else if (rand == 2) {
      camera.GetComponent<AudioSource> ().PlayOneShot (sndOld_3, 1);
    }
  }

  private float getRandomDuration(float fixedTime, float variance)
  {
    float res = fixedTime;

    res += ((-1) * variance) + (UnityEngine.Random.value * variance * 2);

    return res;
  }

  private void setElementImage()
  {
    ElementSprite.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>(ObjectTypesManager.Instance.getSchematicsImagePath(currentOrder));
  }
}
