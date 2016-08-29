using System;
using UnityEngine;

public enum GreekState { NORMAL, DASHING, SHOCKED };

public class Greek : MonoBehaviour {

  public int Player;
  public GameObject camera;
  private int Speed = 5000;
  private Vector3 decalageTete = new Vector3(0, 0.4f, 0);
  private Controller controller;

  private Rigidbody2D characterBody;

  private GreekState state = GreekState.NORMAL;
  
  private double coolDownState = 0;
  private double coolDownDash = 0;

  private Vector3 nextForce = Vector3.zero;

  MachineElement possession;

  private int score;

  private int currentAnimation = 7;


  void Start () {
    controller = ControllerManager.Instance.Controllers[Player];
    characterBody = GetComponent<Rigidbody2D>();
    score = 0;
  }

  #region states and draw

  void Update() {
    updateCoolDowns(Time.deltaTime);

    if ((state == GreekState.DASHING || state == GreekState.SHOCKED) && coolDownState <= 0) {
      state = GreekState.NORMAL;
    }
  }

  void updateCoolDowns(float elapsedTime) {
    coolDownState -= elapsedTime;
    coolDownDash -= elapsedTime;
  }

  #endregion

  #region physics

  void FixedUpdate() {

    if (state != GreekState.DASHING) {
      characterBody.velocity = Vector3.zero;
    }
    characterBody.AddForce(nextForce);
    nextForce = Vector3.zero;
    
    // normal : can move
    if (state == GreekState.NORMAL) {
      nextForce = new Vector2(Speed * Time.fixedDeltaTime * controller.GetInGameHorizontal(), -Speed * Time.fixedDeltaTime * controller.GetInGameVertical());
      if (tired()) {
        nextForce *= 0.5f;
      }
      if (controller.GetInGameDash()) {        
        dash();
      }
    }

    updateAnimation();
  }

  void OnCollisionStay2D(Collision2D collision) {
    // Player
    Greek zorba = collision.gameObject.GetComponent<Greek>();

    if (zorba != null && state == GreekState.DASHING) {
      zorba.shock();
      nextForce = Vector3.zero;
    }

    // Element
    MachineElement element = collision.gameObject.GetComponent<MachineElement>();
    if (element != null) {
      // thrown element ?
      if (element.getState() == ElementState.THROWN) {
        if (element.getThrower() != this) { 
          shock();
        }
      } else if(possession == null && state != GreekState.SHOCKED){
        element.setOwner(this);
        possession = element;
      }
    }
  }

  void shock() {
    state = GreekState.SHOCKED;
    if (camera != null) {
      camera.GetComponent<ScreenShake>().shake();
    }
    coolDownState = 3;
    dropElement();
  }

  void dash() {
    if (possession != null) {
      throwElement();
      coolDownDash = 1;
    } else if (!tired()) {
      nextForce *= 3;
      state = GreekState.DASHING;
      coolDownState = 0.2f;
      coolDownDash = 1;
    }
  }

  void dropElement() {
    if (possession != null) {
      possession.thrown(Vector3.zero, possession.transform.position);
      possession = null;
    }
  }

  void throwElement() {
    if (nextForce == Vector3.zero) {
      dropElement();
    }
    possession.thrown(nextForce*3, transform.position + (nextForce*3).normalized);
    possession = null;
  }

  bool tired() {
    return coolDownDash > 0;
  }

  public Vector3 getHeadPosition() {
    return transform.position + decalageTete;
  }

  public Vector3 getThrowPosition(Vector3 velocity) {
    return transform.position + velocity.normalized;
  }

  public void incrementScore()
  {
    score++;
  }

  public float getScore()
  {
    return score;
  }

  public void updateAnimation() {
    int nextAnimation = 4;
    
    if (state == GreekState.NORMAL) {
      if (nextForce.magnitude == 0) {
        // stop
        nextAnimation = currentAnimation % 4 + 4;
      } else if (Math.Abs(nextForce.x) > Math.Abs(nextForce.y)) {
        if (nextForce.x > 0) {
          nextAnimation = 0;
        } else {
          nextAnimation = 1;
        }
      } else {
        if (nextForce.y > 0) {
          nextAnimation = 2;
        } else {
          nextAnimation = 3;
        }
      }
    }

    transform.GetComponent<Animator>().SetInteger("status", nextAnimation);
    currentAnimation = nextAnimation;
  }

  #endregion
}
