using UnityEngine;
using System.Collections;

public class TileMapBehaviour : MonoBehaviour {

  public TextAsset jsonMapData;
  public string SpriteSheetPath;
  public float PixelsPerUnit;
  public GameObject tilePrefab;
  public GameObject machinePartPrefab;
  private TileMapInfo mapInfo;
  private GameObject[] tiles;

  private Sprite[] tileSprites;

	void Start () {
    tileSprites = Resources.LoadAll<Sprite> (SpriteSheetPath);
    initTileMapInfo();
    initTiles();
    initObjects ();
    setTileMapPosition ();
	}

  private void initTileMapInfo()
  {
    mapInfo = TileMapInfo.CreateFromJSON (jsonMapData.text);
  }

  private void initTiles()
  {
    tiles = new GameObject[mapInfo.tileData.Length];

    float tileSize = mapInfo.tileHeight / PixelsPerUnit;

    for (int i = 0; i < mapInfo.tileData.Length; i++) 
    {     
      tiles[i] = (GameObject) Instantiate (tilePrefab, transform.position, Quaternion.identity);

      tiles[i].GetComponent<Transform> ().parent = transform;

      tiles [i].GetComponent<TileBehaviour> ().setSpriteSheetIndex (tileSprites[mapInfo.tileData[i] - 1]);

      tiles[i].GetComponent<TileBehaviour> ().setPosition (new Vector2((i%mapInfo.width) * tileSize, (mapInfo.height - ((int)(i/ mapInfo.width))) * tileSize));

      tiles[i].GetComponent<TileBehaviour> ().setSolid (mapInfo.collisionData [i] == 0);
    }
  }

  private void initObjects()
  {
    float tileSize = mapInfo.tileHeight / PixelsPerUnit;

    for (int i = 0; i < mapInfo.tileData.Length; i++) 
    {
      Vector3 itemPosition = new Vector3 ((i % mapInfo.width) * tileSize, (mapInfo.height - ((int)(i / mapInfo.width))) * tileSize, 0);
      if (mapInfo.itemData [i] != 0) {
        GameObject newItem = (GameObject) Instantiate (machinePartPrefab, new Vector3(0,0,0), Quaternion.identity);
        newItem.transform.parent = transform;
        newItem.transform.position = itemPosition;
      }
    }
  }

  private void setTileMapPosition()
  {
    float tileSize = mapInfo.tileHeight / PixelsPerUnit;
    transform.position = new Vector3 (-(mapInfo.width * tileSize)/2, -(mapInfo.height * tileSize)/2,0);
  }
}
