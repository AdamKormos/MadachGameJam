using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [HideInInspector] public int currentTileIndex = 0;
    public int playerIndex = 0;
    public bool reachedEnd = false;

    private void Start()
    {
        MoveToTileAt(currentTileIndex);
    }

    private void Update()
    {
        if (transform.position.z != -1)
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }

    public void MoveToTileAt(int tileIndex)
    {
        currentTileIndex = tileIndex;
        if(currentTileIndex >= TileField.tiles.Length) // Reached start again
        {
            transform.position = TileField.tiles[0].transform.position;
            reachedEnd = true;
        }
        else
        {
            transform.position = TileField.tiles[currentTileIndex].transform.position;
        }
    }
}
