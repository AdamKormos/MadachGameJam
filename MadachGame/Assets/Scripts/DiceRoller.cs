using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    bool isDiceRollingNow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DiceLoop());
    }

    IEnumerator DiceLoop()
    {
        while(GameController.instance.playersToMove.Count > 0)
        {
            foreach(Player player in GameController.instance.playersToMove)
            {
                while(isDiceRollingNow) // To toggle later when dice is added and such. Point is to wait till dice finishes moving, and then move the player.
                {
                    yield return new WaitForEndOfFrame();
                }
                int diceRollResult = 4;

                player.MoveToTileAt(player.currentTileIndex + diceRollResult);
            }
        }

        GameController.EvaluateGame();
    }
}
