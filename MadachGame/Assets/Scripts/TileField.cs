using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileField : MonoBehaviour
{
    [SerializeField] int tilesPerRow = 8;
    [SerializeField] Tile tileSample;
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
            tile.sceneIndex = Random.Range(0, 16);
            tile.transform.parent = this.gameObject.transform;
            tiles[i] = tile;
            
            // Set position

            tile.LoadArt();
        }
    }
}
