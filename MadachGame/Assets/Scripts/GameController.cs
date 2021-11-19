using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public QuizManager quizManager;
    public Text[] playerScoreTexts;
    public List<Player> players;
    public List<Player> playersToMove = new List<Player>();
    public bool isDiceRollingNow = false;
    public static bool isQuizActive = false;
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            playersToMove = players;
            StartCoroutine(GameLoop());
        }
    }


    private IEnumerator GameLoop()
    {
        while (instance.playersToMove.Count > 0)
        {
            foreach (Player player in instance.playersToMove)
            {
                while (isDiceRollingNow) // To toggle later when dice is added and such. Point is to wait till dice finishes moving, and then move the player.
                {
                    yield return new WaitForEndOfFrame();
                }
                int diceRollResult = 4;

                player.MoveToTileAt(player.currentTileIndex + diceRollResult);

                quizManager.LoadNextQuiz(TileField.tiles[player.currentTileIndex].sceneIndex, player.playerIndex);
                while(isQuizActive)
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        EvaluateGame();
    }


    public static void UpdatePlayerScore(int playerIndex, int amount)
    {
        instance.players[playerIndex].score = amount;
        instance.playerScoreTexts[playerIndex].text = amount.ToString();
    }

    public static void EvaluateGame()
    {
        if (instance.players[0].score > instance.players[1].score)
        {
            Debug.Log("Ádám");
        }
        else if (instance.players[0].score < instance.players[1].score)
        {
            Debug.Log("Lucifer");
        }
        else
        {
            Debug.Log("Döntetlen");
        }
    }
}
