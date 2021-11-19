using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionsDB
{
    public static Dictionary<int, QuizQuestion[]> sceneQuestions = new Dictionary<int, QuizQuestion[]>()
    {
        [0] = {},
        [1] = {},
        [2] = {},
        [3] = {},
        [4] = {},
        [5] = {},
        [6] = {},
        [7] = {},
        [8] = {},
        [9] = {},
        [10] = {},
        [11] = {},
        [12] = {},
        [13] = {},
        [14] = {},
        [15] = {}
    };

    public static QuizQuestion GetQuestionFor(int sceneIndex)
    {
        return sceneQuestions[sceneIndex][Random.Range(0, sceneQuestions[sceneIndex].Length)];
    }
}
