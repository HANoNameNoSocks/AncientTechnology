using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

  public void setPosition(Vector2 _position)
  {
    transform.position = new Vector3(_position.x, _position.y, 0);
  }

  public void setSolid(bool _solid)
  {
    if (_solid) 
    {
      GetComponent<BoxCollider2D> ().enabled = false;
    }
  }

  public void setSpriteSheetIndex(Sprite sprite)
  {
    GetComponent<SpriteRenderer> ().sprite = sprite;
  }

}
