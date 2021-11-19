using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [HideInInspector] public int currentTileIndex = 0;
    static int playerCounter = 0;
    public int playerIndex = 0;

    private void Start()
    {
        playerIndex = playerCounter;
        playerCounter++;
    }

    public void MoveToTileAt(int tileIndex)
    {
        currentTileIndex = tileIndex;
        if(currentTileIndex > TileField.tiles.Length)
        {
            // Reached start again
            transform.position = TileField.tiles[0].transform.position;
            GameController.instance.playersToMove.Remove(this);
        }
        else
        {
            transform.position = TileField.tiles[currentTileIndex].transform.position;
        }
    }
}
