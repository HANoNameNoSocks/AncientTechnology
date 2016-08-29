using UnityEngine;
using System.Collections;

public class MachineController : MonoBehaviour {

  public float OrderTime;
  public float OrderTimeVariance;
  public float OrderVisibility;
  public GameObject Bulle;
  public GameObject ElementSprite;
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
        Destroy (collision.gameObject);
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
    print ("Gheuuuuah... Ramenez moi un " + currentOrder + " les enfants !");
  }

  private float getRandomDuration(float fixedTime, float variance)
  {
    float res = fixedTime;

    res += ((-1) * variance) + (Random.value * variance * 2);

    return res;
  }

  private void setElementImage()
  {
    ElementSprite.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>(ObjectTypesManager.Instance.getImagePath (currentOrder));
  }
}
