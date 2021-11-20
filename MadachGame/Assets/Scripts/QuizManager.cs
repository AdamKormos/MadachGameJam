using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] Text quizQuestionText;
    [SerializeField] Transform quizQuestionsParent;
    [SerializeField] Text playerNameAboveQuizText;
    [SerializeField] Button[] quizButtons;
    [SerializeField] int buttonsInOneRow = 2, buttonRowAmount = 2;
    QuizQuestion currentQuestion = null;
    
    int currentPlayerIndex = 0;

    public void Start()
    {
        AbortQuiz();
        ChangeButtonFocus(focusedButtonPos);
    }


    Vector2Int focusedButtonPos = new Vector2Int(0, 0);

    private void Update()
    {
        if (GameController.isQuizActive) // Temp false
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeButtonFocus(focusedButtonPos + new Vector2Int(1, 0));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeButtonFocus(focusedButtonPos + new Vector2Int(-1, 0));
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ChangeButtonFocus(focusedButtonPos + new Vector2Int(0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangeButtonFocus(focusedButtonPos + new Vector2Int(0, 1));
            }
            else if(Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(SubmitAnswer());
            }
        }
    }

    private IEnumerator SubmitAnswer()
    {
        int answerIndex = focusedButtonPos.x + focusedButtonPos.y * buttonsInOneRow;
        bool gotCorrectAnswer = (currentQuestion.correctAnswerIndex == answerIndex);

        if(!gotCorrectAnswer)
        {
            quizButtons[answerIndex].GetComponent<Image>().color = Color.red;
        }

        for (int i = 0; i < 7; i++)
        {
            quizButtons[currentQuestion.correctAnswerIndex].GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(0.15f);
            quizButtons[currentQuestion.correctAnswerIndex].GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(0.15f);
        }

        if (gotCorrectAnswer)
        {
            GameController.UpdatePlayerScore(currentPlayerIndex, GameController.instance.players[currentPlayerIndex].score + 1);
        }
        else
        {

        }

        foreach(Button button in quizButtons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
        AbortQuiz();
    }

    private void AbortQuiz()
    {
        GameController.isQuizActive = false;
        gameObject.SetActive(false);
    }

    public void ChangeButtonFocus(Vector2Int to)
    {
        if (to.x > -1 && to.y > -1 && to.x < buttonsInOneRow && to.y < buttonRowAmount 
            && quizButtons[to.x + to.y * buttonsInOneRow].gameObject.activeSelf)
        {
            quizButtons[focusedButtonPos.x + focusedButtonPos.y * buttonsInOneRow].GetComponent<Image>().color = Color.white;
            focusedButtonPos = to;
            quizButtons[focusedButtonPos.x + focusedButtonPos.y * buttonsInOneRow].GetComponent<Image>().color = Color.green;
        }
    }


    public void LoadNextQuiz(int quizSceneIndex, int targetPlayerIndex)
    {
        GameController.isQuizActive = true;
        gameObject.SetActive(true);
        ChangeButtonFocus(new Vector2Int(0, 0));

        currentPlayerIndex = targetPlayerIndex;
        currentQuestion = QuestionsDB.GetQuestionFor(quizSceneIndex);
        int answerCount = currentQuestion.answers.Length;
        quizQuestionText.text = currentQuestion.question;

        playerNameAboveQuizText.text = ((GameController.Names)targetPlayerIndex).ToString() + " kérdése:";
        playerNameAboveQuizText.color = new Color(playerNameAboveQuizText.color.r, playerNameAboveQuizText.color.g, playerNameAboveQuizText.color.b, 1f);
        StartCoroutine(NameTextFadeInAndOut());

        for (int i = 0; i < quizButtons.Length; i++)
        {
            if(i < answerCount)
            {
                quizButtons[i].gameObject.SetActive(true);
                quizButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];
            }
            else
            {
                quizButtons[i].gameObject.SetActive(false);
            }
        }
    }
    
    private IEnumerator NameTextFadeInAndOut()
    {
        while (GameController.isQuizActive)
        {
            for(int i = 0; i < 15; i++)
            {
                playerNameAboveQuizText.color -= new Color(0f, 0f, 0f, 1f / 20);
                yield return new WaitForSeconds(0.05f);
            }

            for (int i = 0; i < 15; i++)
            {
                playerNameAboveQuizText.color += new Color(0f, 0f, 0f, 1f / 20);
                yield return new WaitForSeconds(0.05f);
            }
        }
        playerNameAboveQuizText.gameObject.SetActive(false);
    }
}
