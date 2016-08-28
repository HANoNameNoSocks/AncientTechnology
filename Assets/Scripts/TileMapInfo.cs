using UnityEngine;

[System.Serializable]
public class TileMapInfo
{
  public int height;
  public int width;
  public int tileHeight;
  public int tileWidth;
  public int[] tileData;
  public int[] collisionData;

  public static TileMapInfo CreateFromJSON(string jsonString)
  {
    return JsonUtility.FromJson<TileMapInfo>(jsonString);
  }
}
