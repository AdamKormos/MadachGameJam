using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex = 0;
    public int sceneIndex = 0;

    public QuizQuestion(string _question, string[] _answers, int _correctAnswerIndex, int _sceneIndex)
    {
        question = _question;
        answers = _answers;
        correctAnswerIndex = _correctAnswerIndex;
        sceneIndex = _sceneIndex;
    }
}
