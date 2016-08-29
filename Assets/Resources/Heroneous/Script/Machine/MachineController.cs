using UnityEngine;
using System.Collections;

public class MachineController : MonoBehaviour {

  public float OrderTime;
  public float OrderTimeVariance;
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
      print ("Gheuuuuah... Ramenez moi un " + currentOrder + " les enfants !");
    }
	}

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.name == "MachineElement") {
      Destroy (collision.gameObject);
    }
  }

  private void resetOrder()
  {
    orderTime = 0;
    orderDuration = getRandomDuration(OrderTime, OrderTimeVariance);
    currentOrder = ObjectTypesManager.Instance.getRandomItem();
  }

  private float getRandomDuration(float fixedTime, float variance)
  {
    float res = fixedTime;

    res += ((-1) * variance) + (Random.value * variance * 2);

    return res;
  }
}
