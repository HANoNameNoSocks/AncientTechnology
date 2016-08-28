using UnityEngine;

public enum ElementState { NORMAL, THROWN };

public class MachineElement : MonoBehaviour {
  private Greek owner;
  private Greek thrower;
  private Rigidbody2D elementBody;
  private ElementState state = ElementState.NORMAL;

	// Use this for initialization
	void Start () {
    elementBody = gameObject.GetComponent<Rigidbody2D>();
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

  public void setOwner(Greek owner) {
    this.owner = owner;
    thrower = null;
    elementBody.isKinematic = true;
    transform.parent = owner.transform;
    transform.position = owner.getHeadPosition();
  }

  public void thrown(Vector2 force, Vector3 position) {
    state = ElementState.THROWN;
    thrower = owner;
    owner = null;
    transform.parent = null;
    elementBody.isKinematic = false;
    transform.position = position;
    elementBody.AddForce(force);
  }

  public ElementState getState() {
    return state;
  }

  public Greek getThrower() {
    return thrower;
  }
}
