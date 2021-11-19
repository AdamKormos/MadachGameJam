using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileField : MonoBehaviour
{
    [SerializeField] int tilesPerRow = 8;
    [SerializeField] Tile tileSample;
    [SerializeField] Transform tilesBottomLeftCornerPos;
    public static Tile[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        int tilesPerRowWithoutCorners = tilesPerRow - 2;
        int totalTiles = tilesPerRowWithoutCorners * 4 + 4;
        tiles = new Tile[totalTiles];

        for(int i = 0; i < totalTiles; i++)
        {
            GameObject tileObj = Instantiate(tileSample.gameObject);
            Tile tile = tileObj.GetComponent<Tile>();

            if (i % 7 == 0)
            {
                tile.sceneIndex = QuestionsDB.NotSceneRelated;
            }
            else
            {
                tile.sceneIndex = Random.Range(0, 16);
            }

            tile.transform.parent = this.gameObject.transform;
            tile.name = "Tile #" + i.ToString();
            tiles[i] = tile;
            
            // Set position

            tile.LoadArt();
        }

        for(int i = 0; i < tiles.Length; i++)
        {
            if(i < 8)
            {
                tiles[i].transform.position = tilesBottomLeftCornerPos.position + new Vector3(TileOffset().x * 7, TileOffset().y * (i % 8));
            }
            else if(i < 15)
            {
                tiles[i].transform.position = tilesBottomLeftCornerPos.position + new Vector3(TileOffset().x * (6 - (i % 8)), TileOffset().y * 7);
            }
            else if(i < 21)
            {
                tiles[i].transform.position = tilesBottomLeftCornerPos.position + new Vector3(0f, TileOffset().y * 7 + -TileOffset().y * (i % 7));
            }
            else
            {
                tiles[i].transform.position = tilesBottomLeftCornerPos.position + new Vector3(TileOffset().x * (i % 7), 0f);
            }
        }
    }

    private Vector3 TileOffset()
    {
        return tileSample.GetComponent<SpriteRenderer>().size * 1.1f * tileSample.transform.lossyScale;
    }
}
