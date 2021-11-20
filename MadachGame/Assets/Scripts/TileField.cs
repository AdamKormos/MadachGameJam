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
        tileSample.gameObject.SetActive(false);

        for(int i = 0; i < tiles.Length; i++)
        {
            Vector3 additionalOffset = new Vector3();
            float rotationAngle = 0f;
            if(i < 8)
            {
                additionalOffset = new Vector3(TileOffset().x * (tilesPerRow - 1), TileOffset().y * (i % tilesPerRow));
                rotationAngle = 90f;
            }
            else if(i < 15)
            {
                int tempI = i - (tilesPerRow - 1);
                additionalOffset = (TileOffset() * (tilesPerRow - 1)) - new Vector3(TileOffset().x * tempI, 0f);
                rotationAngle = 180f;
            }
            else if(i < 21)
            {
                additionalOffset = new Vector3(0f, (TileOffset().y * (tilesPerRow - 1)) - TileOffset().y * (i % (tilesPerRow - 1)));
                rotationAngle = 270f;
            }
            else
            {
                additionalOffset = new Vector3(TileOffset().x * (i % (tilesPerRow - 1)), 0f);
            }

            tiles[i].transform.position = tilesBottomLeftCornerPos.position + additionalOffset;
            tiles[i].transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }
    }

    private Vector3 TileOffset()
    {
        return tileSample.GetComponent<SpriteRenderer>().size * 1.1f * tileSample.transform.lossyScale;
    }
}
