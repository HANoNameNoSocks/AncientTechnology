using UnityEngine;

public enum State { NORMAL, DASHING, SHOCKED };

public class Greek : MonoBehaviour {

  public int Player;
  private int Speed = 10000;
  private Controller controller;

  private Rigidbody2D characterBody;

  private State state = State.NORMAL;
  
  private double coolDownState = 0;
  private double coolDownDash = 0;

  private Vector3 nextForce = Vector3.zero;
  
  void Start () {
    controller = ControllerManager.Instance.Controllers[Player];
    characterBody = GetComponent<Rigidbody2D>();
  }

  #region states and draw

  void Update() {
    updateCoolDowns();

    if ((state == State.DASHING || state == State.SHOCKED) && coolDownState <= 0) {
      state = State.NORMAL;
    }
  }

  void updateCoolDowns() {
    coolDownState -= Time.deltaTime;
    coolDownDash -= Time.deltaTime;
  }

  #endregion

  #region physics

  void FixedUpdate() {

    if (state != State.DASHING) {
      characterBody.velocity = Vector3.zero;
    }
    characterBody.AddForce(nextForce);
    nextForce = Vector3.zero;
    
    // normal : can move
    if (state == State.NORMAL) {
      nextForce = new Vector2(Speed * Time.deltaTime * controller.GetInGameHorizontal(), -Speed * Time.deltaTime * controller.GetInGameVertical());
      if (controller.GetInGameDash() && canDash()) {
        dash();
      }
    }
  }

  void OnCollisionEnter2D(Collision2D collision) {
    Greek zorba = collision.gameObject.GetComponent<Greek>();

    if (zorba != null && state == State.DASHING) {
      zorba.shock(collision.relativeVelocity);
      nextForce = Vector3.zero;
    }
  }

  void shock(Vector2 velocity) {
    //print(velocity);
    //nextForce = -velocity;
    state = State.SHOCKED;
    coolDownState = 3;
  }

  void dash() {
    nextForce *= 3;
    state = State.DASHING;
    coolDownState = 0.2f;
    coolDownDash = 1;
  }

  bool canDash() {
    return coolDownDash <= 0;
  }

  #endregion
}
