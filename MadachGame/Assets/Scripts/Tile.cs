using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int sceneIndex = 0;

    public void LoadArt()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load("test-tile", typeof(Sprite)) as Sprite;
    }
}
