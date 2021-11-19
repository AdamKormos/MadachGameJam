using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion
{
    public string[] answers;
    public int correctAnswerIndex = 0;

    public QuizQuestion(string[] _answers, int _correctAnswerIndex)
    {
        answers = _answers;
        correctAnswerIndex = _correctAnswerIndex;
    }
}
