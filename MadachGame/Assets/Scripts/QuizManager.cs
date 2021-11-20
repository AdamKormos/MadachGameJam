using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] Text quizQuestionText;
    [SerializeField] Transform quizQuestionsParent;
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
                SubmitAnswer();
                AbortQuiz();
            }
        }
    }

    private void SubmitAnswer()
    {
        int answerIndex = focusedButtonPos.x + focusedButtonPos.y * buttonsInOneRow;
        if(currentQuestion.correctAnswerIndex == answerIndex)
        {
            GameController.UpdatePlayerScore(currentPlayerIndex, GameController.instance.players[currentPlayerIndex].score + 1);
        }
        else
        {

        }
    }

    private void AbortQuiz()
    {
        GameController.isQuizActive = false;
        gameObject.SetActive(false);
    }

    public void ChangeButtonFocus(Vector2Int to)
    {
        if (to.x > -1 && to.y > -1 && to.x < buttonsInOneRow && to.y < buttonRowAmount)
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

        currentPlayerIndex = targetPlayerIndex;
        currentQuestion = QuestionsDB.GetQuestionFor(quizSceneIndex);
        int answerCount = currentQuestion.answers.Length;
        quizQuestionText.text = currentQuestion.answers[currentQuestion.correctAnswerIndex];

        for(int i = 0; i < quizButtons.Length; i++)
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
}
