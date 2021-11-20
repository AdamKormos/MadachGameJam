using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public enum Names { Ádám, Lucifer};

    public QuizManager quizManager;
    public Text gameEvaluationText;
    public GameObject gameStartPanelParent;
    public Text[] playerScoreTexts;
    public List<Player> players;
    public bool isDiceRollingNow = false, isEvaluationPanelOn = false, isGameStartPanelOn = false;
    public static bool isQuizActive = false;
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        instance.gameEvaluationText.transform.parent.gameObject.SetActive(false);

        isGameStartPanelOn = (PlayerPrefs.GetInt("SessionMatchCount", 0) == 0);
        gameStartPanelParent.SetActive(isGameStartPanelOn);

        for(int i = 0; i < players.Count; i++)
        {
            players[i].playerIndex = i;
        }

        QuestionsDB.FillDB();
        StartCoroutine(GameLoop());
    }

    private void Update()
    {
        if(isEvaluationPanelOn)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                PlayerPrefs.SetInt("SessionMatchCount", 0);
            }
            else if(Input.GetKeyDown(KeyCode.Return))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                PlayerPrefs.SetInt("SessionMatchCount", PlayerPrefs.GetInt("SessionMatchCount", 0) + 1);
                Destroy(this.gameObject);
            }
        }
        else if(isGameStartPanelOn)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isGameStartPanelOn = false;
                gameStartPanelParent.SetActive(false);
            }
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SessionMatchCount", 0);
    }

    private IEnumerator GameLoop()
    {
        while(isGameStartPanelOn)
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.3f);

        int activePlayerCount = players.Count;
        while (activePlayerCount > 0)
        {
            activePlayerCount = players.Count;
            foreach (Player player in players)
            {
                if(player.reachedEnd)
                {
                    activePlayerCount--;
                    continue;
                }

                while (isDiceRollingNow) // To toggle later when dice is added and such. Point is to wait till dice finishes moving, and then move the player.
                {
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(0.3f);

                int diceRollResult = Random.Range(1, 7);
                // Debug.Log(diceRollResult);

                StartCoroutine(player.MoveToTileAt(player.currentTileIndex + diceRollResult));
                while(player.isMoving)
                {
                    yield return new WaitForSeconds(0.1f);
                }

                if (!player.reachedEnd)
                {
                    // quizManager.LoadNextQuiz(TileField.tiles[player.currentTileIndex].sceneIndex, player.playerIndex);
                    quizManager.LoadNextQuiz(Random.Range(0, 18), player.playerIndex);
                    while (isQuizActive)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    yield return new WaitForSeconds(0.3f);
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
        instance.gameEvaluationText.transform.parent.gameObject.SetActive(true);
        instance.isEvaluationPanelOn = true;

        if (instance.players[0].score > instance.players[1].score)
        {
            instance.gameEvaluationText.text = "Ádám nyert!";
        }
        else if (instance.players[0].score < instance.players[1].score)
        {
            instance.gameEvaluationText.text = "Lucifer nyert!";
        }
        else
        {
            instance.gameEvaluationText.text = "A játszma döntetlen";
        }
    }
}
