using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionsDB
{
    public const int NotSceneRelated = 16;

    public static List<QuizQuestion>[] questions = new List<QuizQuestion>[17];


    public static void FillDB()
    {
        AddQuestion(0, "A?", 0, new string[] { "A", "B", "C", "D" });
    }


    private static void AddQuestion(int sceneIndex, string question, int correctAnswerIndex, params string[] answers)
    {
        if(questions[sceneIndex] == null)
        {
            questions[sceneIndex] = new List<QuizQuestion>();
        }

        questions[sceneIndex].Add(new QuizQuestion(question, answers, correctAnswerIndex));
    }


    public static QuizQuestion GetQuestionFor(int sceneIndex)
    {
        return questions[0][0];
        //return questions[sceneIndex][Random.Range(0, questions[sceneIndex].Length)];
    }
}
