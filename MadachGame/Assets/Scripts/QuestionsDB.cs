using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionsDB
{
    public const int NotSceneRelated = 0;

    public static List<QuizQuestion>[] questions = new List<QuizQuestion>[17];


    public static void FillDB()
    {
        AddQuestion(1, "Lucifer szembefordul az Úrral", 0, new string[] { "Igaz", "Hamis" });
        AddQuestion(1, "Minek a fáját adta Isten Lucifernek?", 2, new string[] { "Kételkedés és halhatatlanság", "Tudás és tagadás", "Tudás és halhatatlanság", "Becsmérlés és tagadás" });
        AddQuestion(1, "Mit hajt végre ebben a színben Lucifer?", 1, new string[] { "Csatlakozik az angyalokhoz", "Kiválik az angyaloktól", "Behódol Istennek" });
        
        AddQuestion(2, "Ki talál rá Lucifer fájára a Paradicsomban?", 2, new string[] { "Mózes", "Jézus és Ádám", "Ádám és Éva", "Az egyik angyal" });
        AddQuestion(2, "Miben részesülnek Ádámék, miután esznek Lucifer fájáról?", 2, new string[] { "Fenyegetés", "Halálbüntetés", "Kiűzetés" });
        AddQuestion(2, "Mi jellemzi leginkább a Paradicsomot?", 0, new string[] { "Idill világ", "Szörnyű életkörülmények", "Túlnépesedett tömeg", "Istentől független" });
        
        AddQuestion(3, "Mi jelenik meg ebben a színben?", 1, new string[] { "Hedonizmus", "A magántulajdon", "Kapitalizmus" });
        AddQuestion(3, "Mit szeretne látni Ádám?", 1, new string[] { "Az Évával való közös jövőjüket", "Az emberiség jövőjét", "A jövőbeli fiát", "A teremtőt" });
        AddQuestion(3, "A szín végén Isten álmot bocsát Ádámékra", 2, new string[] { "Hamis, maguktól alszanak el", "Igaz", "Hamis, Lucifer altatja el őket", "Hamis, nem alszanak el" });
        
        AddQuestion(4, "Ádám az elnyomott, elégedetlen nép hatására szabadítja fel a rabszolgákat", 1, new string[] { "Igaz", "Hamis" });
        AddQuestion(4, "Milyen eszme található meg a színben?", 2, new string[] { "Deizmus", "Liberalizmus", "Egyeduralom", "Idealizmus" });
        AddQuestion(4, "Ádám elégedett azzal, hogy fáraóként uralkodik", 2, new string[] { "Igaz", "Hamis, nagyobb hatalomra vágyna", "Hamis, a lelkét üresnek érzi", "Hamis, túl sok tennivalója van" });
        
        AddQuestion(5, "Mit mutat be a szín?", 3, new string[] { "Igazi demokráciát", "Forradalmat", "Egyeduralmat", "Elcsorbított demokráciát" });
        AddQuestion(5, "Mi a baj a néppel a színben?", 0, new string[] { "Túl könnyen befolyásolható", "Sok az írástudatlan", "Túl fejlett a korhoz", "Semmi" });
        AddQuestion(5, "Kinek a formájában jelenik meg Ádám?", 2, new string[] { "Periklész", "Platón", "Miltiádész", "Danton" });
        AddQuestion(5, "Milyen sorsa jut Ádám?", 1, new string[] { "Boldogság a családjával", "Lefejezés", "Levágják a kezét", "A nép dicsőíti" });

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
        sceneIndex = Random.Range(1, 6);
        return questions[sceneIndex][Random.Range(0, questions[sceneIndex].Count)];
    }
}
