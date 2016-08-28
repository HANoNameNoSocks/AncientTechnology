using UnityEngine;
using System.Collections;

public class TileMapBehaviour : MonoBehaviour {

  public TextAsset jsonMapData;
  public GameObject tilePrefab;
  private TileMapInfo mapInfo;
  private GameObject[] tiles;

  private Sprite[] tileSprites;

	void Start () {
    tileSprites = Resources.LoadAll<Sprite> ("Textures/HHA_tiles");
    initTileMapInfo();
    initTiles();
	}

  private void initTileMapInfo()
  {
    mapInfo = TileMapInfo.CreateFromJSON (jsonMapData.text);
  }

  private void initTiles()
  {
    tiles = new GameObject[mapInfo.tileData.Length];
    for (int i = 0; i < mapInfo.tileData.Length; i++) 
    {      
      tiles[i] = (GameObject) Instantiate (tilePrefab, transform.position, Quaternion.identity);

      tiles [i].GetComponent<TileBehaviour> ().setSpriteSheetIndex (tileSprites[mapInfo.tileData[i] - 1]);

      tiles[i].GetComponent<TileBehaviour> ().setPosition (new Vector2((i%mapInfo.width) * mapInfo.tileWidth, mapInfo.tileHeight - ((i/ mapInfo.height) * mapInfo.tileHeight)));

      tiles[i].GetComponent<TileBehaviour> ().setSolid (mapInfo.collisionData [i] == 0);
    }
  }
}
