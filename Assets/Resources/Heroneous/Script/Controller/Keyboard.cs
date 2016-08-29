using UnityEngine;

public class Keyboard : Controller {
  
  //default keys
  private KeyCode haut = KeyCode.Z;
  private KeyCode bas = KeyCode.S;
  private KeyCode gauche = KeyCode.Q;
  private KeyCode droite = KeyCode.D;

  private KeyCode pause = KeyCode.Escape;

  private KeyCode dash = KeyCode.Space;

  // MENUS
  public override bool GetMenuHaut() {
    return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(haut);
  }

  public override bool GetMenuBas() {
    return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(bas);
  }

  public override bool GetMenuGauche() {
    return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(gauche);
  }

  public override bool GetMenuDroite() {
    return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(droite);
  }

  public override bool GetMenuConfirm() {
    return Input.GetKeyDown(KeyCode.Space);
  }

  public override bool GetMenuStart() {
    return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
  }

  public override bool GetMenuBack() {
    return Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace);
  }

  // IN-GAME
  public override float GetInGameHorizontal() {
    if (Input.GetKey(gauche)) {
      return -1;
    } else if (Input.GetKey(droite)) {
      return 1;
    } else {
      return 0;
    }
  }

  public override float GetInGameVertical() {
    if (Input.GetKey(haut)) {
      return -1;
    } else if (Input.GetKey(bas)) {
      return 1;
    } else {
      return 0;
    }
  }

  public override bool GetInGamePause() {
    return Input.GetKeyDown(pause);
  }

  public override bool GetInGameDash() {
    return Input.GetKey(dash);
  }
}
