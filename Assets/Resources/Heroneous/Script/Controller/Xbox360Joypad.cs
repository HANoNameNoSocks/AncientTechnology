using UnityEngine;

public class Xbox360Joypad : Controller {

  private int padNumber;

  public Xbox360Joypad(int padNumber) {
    this.padNumber = padNumber;
  }

  // MENUS
  public override bool GetMenuHaut() {
    return Input.GetAxis("L_YAxis_" + padNumber) < 0 || Input.GetAxis("DPad_YAxis_" + padNumber) > 0;
  }

  public override bool GetMenuBas() {
    return Input.GetAxis("L_YAxis_" + padNumber) > 0 || Input.GetAxis("DPad_YAxis_" + padNumber) < 0;
  }

  public override bool GetMenuGauche() {
    return Input.GetAxis("L_XAxis_" + padNumber) < 0 || Input.GetAxis("DPad_XAxis_" + padNumber) < 0;
  }

  public override bool GetMenuDroite() {
    return Input.GetAxis("L_XAxis_" + padNumber) > 0 || Input.GetAxis("DPad_XAxis_" + padNumber) > 0;
  }

  public override bool GetMenuConfirm() {
    return Input.GetButtonDown("A_" + padNumber);
  }

  public override bool GetMenuStart() {
    return Input.GetButtonDown("Start_" + padNumber);
  }

  public override bool GetMenuBack() {
    return Input.GetButtonDown("B_" + padNumber) || Input.GetButtonDown("Back_" + padNumber);
  }

  // IN-GAME
  public override float GetInGameHorizontal() {
    return Input.GetAxis("L_XAxis_" + padNumber);
  }

  public override float GetInGameVertical() {
    return Input.GetAxis("L_YAxis_" + padNumber);
  }

  public override bool GetInGamePause() {
    return Input.GetButtonDown("Start_" + padNumber);
  }

  public override bool GetInGameDash() {
    return Input.GetButton("RB_" + padNumber) || Input.GetButton("LB_" + padNumber);
  }
}
