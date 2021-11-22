using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionsDB
{
    public const int GeneralQuestion = 0;
    public const int Memoriter = 16;

    public static List<QuizQuestion>[] questions = new List<QuizQuestion>[17];
    public static List<QuizQuestion>[] usableQuestions = new List<QuizQuestion>[17];


    public static void FillDB()
    {
        AddQuestion(GeneralQuestion, "Körülbelül mennyi idő alatt írta meg Madách a művet?", 1, new string[] { "3 év", "1 év", "1 évtized", "5 év" });
        AddQuestion(GeneralQuestion, "Mihez hasonlította Arany elhamarkodottan a művet?", 0, new string[] { "Faust", "Rómeó és Júlia", "Egri Csillagok", "Antigoné" });
        AddQuestion(GeneralQuestion, "Melyik NEM jelenik meg a műben?", 3, new string[] { "Eleve elrendeltség", "Hegeli dialektika", "Fagyhalál elmélet", "Ateizmus" });
        AddQuestion(GeneralQuestion, "Mire szánta Madách a művet?", 1, new string[] { "Színdarabokra", "Olvasásra" });
        AddQuestion(GeneralQuestion, "Mi a mű műfaja?", 0, new string[] { "Drámai költemény", "Eposz", "Epikus dráma", "Elégia" });
        
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

        AddQuestion(8, "Mit kell Ádámnak csinálnia a csillagászat helyett?", 2, new string[] { "Pásztorkodás", "Cigánykártya", "Horoszkóptudományok", "MBTI-típusok kutatása" });
        AddQuestion(8, "Kinek a bőrébe bújik Ádám?", 0, new string[] { "Kepler", "Kopernikusz", "Newton", "Galileo" });
        AddQuestion(8, "Kije ebben a színben Éva Ádámnak?", 3, new string[] { "Rabszolga", "Munkatárs", "Barát", "Feleség" });

        AddQuestion(9, "Hogy kezdődik a szín?", 2, new string[] { "Lucifer átvezeti őt", "Megunja az előző helyszínt", "Elalszik az előző színben", "Elkábítja Éva" });
        AddQuestion(9, "Mik az első szavai?", 0, new string[] { "Egyenlőség, szabadság, testvériség!", "Egy darab mennyország szállt le a vérpadra.", "Pokolnak gőze undorítja el.", "Kétséges rang -e hát szellem, tudás?" });

        AddQuestion(10, "Mit gondol Ádám az eszmékről?", 2, new string[] { "Visszafejlődnek", "Állnak", "Fejlődnek" });
        AddQuestion(10, "Hova tért vissza álmából Ádám?", 0, new string[] { "Prágába", "Egyiptomba", "Athénébe" });

        AddQuestion(11, "Madách ... ez a szín.", 1, new string[] { "múltja", "jelene", "jövője" });
        AddQuestion(11, "Honnan szemlélődik Ádám?", 2, new string[] { "A Big Ben-ről", "A Buckingham Palace-ről", "A Tower-ről", "A Bandi-ról" });
        AddQuestion(11, "Ki éli egyedül túl a szín végét?", 0, new string[] { "Éva", "Ádám", "Polgárok" });

        AddQuestion(12, "Mi uralkodik?", 1, new string[] { "Szerelem", "Tudományok" });
        AddQuestion(12, "Teret ad a helyszín az egyéniségnek?", 1, "Igen", "Nem");
        AddQuestion(12, "Milyen eszmerendszer elemei figyelhetők meg ebben?", 0, "Utópista szocializmus", "Hedonizmus", "Liberalizmus");

        AddQuestion(13, "Diadalmaskodik ebben a színben Lucifer?", 1, new string[] { "Igen", "Nem" });
        AddQuestion(13, "Hogy jut új erőre Ádám?", 1, new string[] { "Éva szavaira", "A Föld szellemének bíztató hangjára" });

        AddQuestion(14, "Segítettek az emberiségnek végezetül a tudományok?", 1, new string[] { "Igen", "Nem" });
        AddQuestion(14, "Mi történt az emberiséggel?", 1, new string[] { "Győzedelmeskedtek", "Elállatiasodtak" });

        AddQuestion(15, "Miért különleges ez a szín?", 2, new string[] { "történelmi", "Ádám Lucifer szerepét tölti be", "Keretszín" });
        AddQuestion(15, "Hogyan végződik a mű?", 1, new string[] { "Lucifer elcsábítja Évát", "Éva teherbe esik, beteljesül az emberiség végzete" });

        AddQuestion(Memoriter, "Egészítsd ki: „Be van fejezve a nagy mű, igen. A ___ forog, az alkotó pihen.\"", 2, new string[] { "kép", "mű", "gép", "masina" });
        AddQuestion(Memoriter, "Egészítsd ki: „Hiányzik az összhangzó ___.\"", 1, new string[] { "érzelem", "értelem", "lételem", "életem" });
        AddQuestion(Memoriter, "Egészítsd ki: „___, de terhes önlábunkon élni.\"", 2, new string[] { "Helyes", "Feszes", "Nemes", "Rendes" });
        AddQuestion(Memoriter, "Egészítsd ki: „A __ voltaképp mi is?\"", 0, new string[] { "cél", "vég", "lét", "nép" });
        AddQuestion(Memoriter, "Egészítsd ki: „___ majdan fajzatom,\"", 3, new string[] { "Halad-e tovább", "Hívő lesz-e", "Hanyatlik-é egyszer", "Megy-é előbbre" });
        AddQuestion(Memoriter, "Egészítsd ki: „Mondottam ember: küzdj és bízva ___!\"", 1, new string[] { "hívjál", "bízzál", "bírjál" });


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

        questions[sceneIndex].Add(new QuizQuestion(question, answers, correctAnswerIndex, sceneIndex));
    }


    public static QuizQuestion GetQuestion()
    {
        int sceneIndex = Random.Range(0, 17);
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
