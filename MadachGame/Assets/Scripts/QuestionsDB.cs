using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionsDB
{
    public const int NotSceneRelated = 0;
    public const int Memoriter = 16;

    public static List<QuizQuestion>[] questions = new List<QuizQuestion>[17];
    public static List<QuizQuestion>[] usableQuestions = new List<QuizQuestion>[17];


    public static void FillDB()
    {
        AddQuestion(0, "Körülbelül mennyi idő alatt írta meg Madách a művet?", 1, new string[] { "3 év", "1 év", "1 évtized", "5 év" });
        AddQuestion(0, "Mihez hasonlította Arany elhamarkodottan a művet?", 0, new string[] { "Faust", "Rómeó és Júlia", "Egri Csillagok", "Antigoné" });
        AddQuestion(0, "Melyik NEM jelenik meg a műben?", 3, new string[] { "Eleve elrendeltség", "Hegeli dialektika", "Fagyhalál elmélet", "Ateizmus" });
        AddQuestion(0, "Mire szánta Madách a művet?", 1, new string[] { "Színdarabokra", "Olvasásra" });
        AddQuestion(0, "Mi a mű műfaja?", 0, new string[] { "Drámai költemény", "Eposz", "Epikus dráma", "Elégia" });
        
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

        AddQuestion(6, "Mit érez Ádám és Éva a színben?", 0, new string[] { "Boldogtalanság", "Semleges hangulat", "Elégedettség", "Öröm" });
        AddQuestion(6, "Ki kezd el új eszméket hirdetni a szín végén?", 1, new string[] { "Szent Péter", "Péter apostol", "Pál apostol", "Ádám" });
        AddQuestion(6, "Mit jelent a hedonizmus?", 0, new string[] { "Eszmék nélküli világ", "Több eszmével teli világ", "Vallásiasság", "Népuralom" });

        AddQuestion(7, "Milyen szerepet tölt be Ádám a színben?", 0, new string[] { "Kereszteslovag", "Bérmunkás", "Jobbágy", "Uralkodó" });
        AddQuestion(7, "Mi lesz Évából a színben?", 1, new string[] { "Hadvezér", "Apáca", "Családanya", "Tanító" });
        AddQuestion(7, "Mit gondol Ádám az itt bemutatott keresztény egyházról?", 3, new string[] { "Támogatja", "Elítéli, mert más vallásban hisz", "Semlegesen áll hozzá", "Elítéli, mert elkorcsosult" });



        for (int i = 0; i < questions.Length; i++)
        {
            if (questions[i] == null) continue;
            usableQuestions[i] = new List<QuizQuestion>();
            foreach(QuizQuestion question in questions[i])
            {
                usableQuestions[i].Add(question);
            }
        }
    }


    private static void AddQuestion(int sceneIndex, string question, int correctAnswerIndex, params string[] answers)
    {
        if(questions[sceneIndex] == null)
        {
            questions[sceneIndex] = new List<QuizQuestion>();
        }

        questions[sceneIndex].Add(new QuizQuestion(question, answers, correctAnswerIndex));
    }


    public static QuizQuestion GetQuestion()
    {
        int sceneIndex = Random.Range(0, 8); // Temporary -- will be Random.Range(0, 17)
        if (usableQuestions[sceneIndex].Count == 0)
        {
            foreach (QuizQuestion q in questions[sceneIndex])
            {
                usableQuestions[sceneIndex].Add(q);
            }
        }

        int questionIndex = Random.Range(0, usableQuestions[sceneIndex].Count);
        QuizQuestion question = usableQuestions[sceneIndex][questionIndex];
        usableQuestions[sceneIndex].Remove(question);
        return question;
    }
}
