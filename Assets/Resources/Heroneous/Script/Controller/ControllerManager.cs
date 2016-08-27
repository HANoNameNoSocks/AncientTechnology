
public class ControllerManager {
  #region Singleton

  // SINGLETON

  private static ControllerManager instance = null;

  public static ControllerManager Instance {
    get {
      if (instance == null)
        instance = new ControllerManager();

      return instance;
    }
  }

  #endregion

  Controller[] controllers = new Controller[4];

  public Controller[] Controllers { get { return controllers; } }

  private ControllerManager() {
    
    for (int i = 0; i < 4; i++) {
      controllers[i] = new Xbox360Joypad(i+1);
    }
  }
}
