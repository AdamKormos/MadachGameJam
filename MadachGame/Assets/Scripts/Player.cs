using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int currentTileIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RollDice()
    {
        int diceResult = 5;
        OnTileEnter(currentTileIndex + diceResult);
    }

    private void OnTileEnter(int tileIndex)
    {
        currentTileIndex = tileIndex;
        if(currentTileIndex > TileField.tiles.Length)
        {
            // Reached start again
        }
    }
}
