using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    [HideInInspector] public int currentTileIndex = 0;
    public int playerIndex = 0;
    public bool reachedEnd = false, isMoving = false;

    private void Start()
    {
        StartCoroutine(MoveToTileAt(currentTileIndex));
    }

    private void Update()
    {
        if (transform.position.z != -1)
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }

    public IEnumerator MoveToTileAt(int tileIndex)
    {
        int distance = tileIndex - currentTileIndex;
        isMoving = true;

        if(tileIndex >= TileField.tiles.Length) // Reached start again
        {
            distance = TileField.tiles.Length - tileIndex;
        }

        for (int i = 0; i < distance; i++)
        {
            currentTileIndex++;
            transform.position = TileField.tiles[currentTileIndex].transform.position;
            yield return new WaitForSeconds(0.5f);
        }

        if (tileIndex >= TileField.tiles.Length)
        {
            reachedEnd = true;
        }
        isMoving = false;
    }
}
