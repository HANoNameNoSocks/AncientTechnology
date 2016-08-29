using UnityEngine;

public enum ElementState { NORMAL, THROWN };

public class MachineElement : MonoBehaviour {
  private Greek owner;
  private Greek thrower;
  private Rigidbody2D elementBody;
  private BoxCollider2D elementCollider;
  private ElementState state = ElementState.NORMAL;

  private string objectType;

	// Use this for initialization
	void Start () {
    elementBody = gameObject.GetComponent<Rigidbody2D>();
    elementCollider = gameObject.GetComponent<BoxCollider2D>();
    objectType = ObjectTypesManager.Instance.getRandomItem ();
    setImage ();
  }
	
	// Update is called once per frame
	void Update () {
    if (elementBody.velocity.magnitude <= 2) {
      state = ElementState.NORMAL;
    }
    if (elementBody.velocity.magnitude <= 0) {
      thrower = null;
    }
	}

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.name == "MachineElement") {
      Destroy (collision.gameObject);
    }
  }

  public void setOwner(Greek owner) {
    this.owner = owner;
    thrower = null;
    elementBody.isKinematic = true;
    elementCollider.enabled = false;
    transform.parent = owner.transform;
    transform.position = owner.getHeadPosition();
  }

  public void thrown(Vector2 force, Vector3 position) {
    state = ElementState.THROWN;
    thrower = owner;
    owner = null;
    transform.parent = null;
    elementBody.isKinematic = false;
    elementCollider.enabled = true;
    transform.position = position;
    elementBody.AddForce(force);
  }

  public ElementState getState() {
    return state;
  }

  public Greek getThrower() {
    return thrower;
  }

  public string getObjectType()
  {
    return objectType;
  }

  private void setImage()
  {
    Sprite newSprite = new Sprite ();
    newSprite = Resources.Load<Sprite> (ObjectTypesManager.Instance.getImagePath (objectType));
    GetComponent<SpriteRenderer> ().sprite = newSprite;
  }
}
