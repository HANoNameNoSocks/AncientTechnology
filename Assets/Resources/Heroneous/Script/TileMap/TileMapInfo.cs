using UnityEngine;

[System.Serializable]
public class TileMapInfo
{
  public float width;
  public float height;
  public float tileHeight;
  public float tileWidth;
  public int[] tileData;
  public int[] collisionData;

  public static TileMapInfo CreateFromJSON(string jsonString)
  {
    return JsonUtility.FromJson<TileMapInfo>(jsonString);
  }
}
