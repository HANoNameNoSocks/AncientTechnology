
public abstract class Controller {

    // MENUS
    public abstract bool GetMenuHaut();
    public abstract bool GetMenuBas();
    public abstract bool GetMenuGauche();
    public abstract bool GetMenuDroite();
    public abstract bool GetMenuConfirm();
    public abstract bool GetMenuBack();

    // IN-GAME
    public abstract float GetInGameHorizontal();
    public abstract float GetInGameVertical();
    public abstract bool GetInGamePause();
    public abstract bool GetInGameDash();
}
