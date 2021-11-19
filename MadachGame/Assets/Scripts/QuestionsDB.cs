using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionsDB
{
    public const int NotSceneRelated = 16;

    public static Dictionary<int, QuizQuestion[]> questions = new Dictionary<int, QuizQuestion[]>()
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
        [15] = {},
        [NotSceneRelated] = { }
    };

    public static QuizQuestion GetQuestionFor(int sceneIndex)
    {
        return questions[sceneIndex][Random.Range(0, questions[sceneIndex].Length)];
    }
}
