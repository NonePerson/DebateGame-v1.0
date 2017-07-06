using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class NormalGame : Program
    {
        #region ctor
        public NormalGame(Stage currectStage, Player player, Game NewGame)
        {
            #region intializing the necessary properties
            isBonus = false;
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            answers = new XElement(recentScreen.Element("Answers"));
            pointCategory = new List<XElement>(recentScreen.Elements("pointCategory"));
            state = new XElement(recentScreen.Element("State"));
            charAnswerA = new XElement(answers.Element("a"));
            charAnswerB = new XElement(answers.Element("b"));
            charAnswerC = new XElement(answers.Element("c"));
            charAnswerD = new XElement(answers.Element("d"));
            charAnswerE = new XElement(answers.Element("e"));
            anAnswer = new List<XElement>();
            anAnswer.Add(charAnswerA);
            anAnswer.Add(charAnswerB);
            anAnswer.Add(charAnswerC);
            anAnswer.Add(charAnswerD);
            anAnswer.Add(charAnswerE);
            foreach(var screen in screens)
            {
                if(screen.Element("State").Value == "GameWon")
                {
                   isBonusNotPassed = screen.Element("Bonus").Value;
                }
                if(screen.Element("State").Value == "Plot")
                {
                    Console.Clear();
                    WritingText(screen.Element("Path").Value);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }
            }
            #endregion
        }
        #endregion

        #region functions (in addition)

        #region opening the next screen
        public void next(Stage stage, Player player, Game NewGame, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, List<int> beforepositive, List<int> beforenegative)
        {
            Console.Clear();
            WritingText(path.Value);
            Console.WriteLine();
            
            Console.WriteLine("Press the letter (a/b/c/d/e) of the best answer");
            MainMeunMessage();
            input = Console.ReadLine();
            Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, input);
            int result;
            if((((input.ToUpper() != "A") &&
                (input.ToUpper() != "B") &&
                (input.ToUpper() != "C") &&
                (input.ToUpper() != "D") &&
                (input.ToUpper() != "E") &&
                !(int.TryParse(input.ToUpper(), out result))))
                || (int.TryParse(input.ToUpper(), out result))){
                next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, beforenegative);
            }
            foreach (XElement answer in anAnswer)
            {
                if(input.ToUpper() == answer.Element("text").Value.ToUpper())
                {
                    Console.Clear();
                    path = answer.Element("NextScreen");
                    // which screen the player is at now?
                    foreach(var screen in screens)
                    {
                        if(screen.Element("Path").Value == path.Value)
                        {
                            recentScreen = screen;
                        }
                    }
                    state = recentScreen.Element("State");
                    WritingText(path.Value);
                    MainMeunMessage();
                    if (state.Value == "GameOver" || state.Value == "GameWon" || state.Value == "GameSuperWon")
                    {
                        if (isBonus)
                        {
                            if (state.Value == "GameWon")
                            {
                                player.knowledge++;
                                player.highNormalRank = player.RankingCalculation(player.normalGamePositivePoints, player.normalGameNegativePoints, player.knowledge);
                                input = Console.ReadLine();
                                isBonusNotPassed = "No";
                                Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
                            }
                            if (state.Value == "GameOver")
                            {
                                input = Console.ReadLine();
                                isBonusNotPassed = "No";
                                Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
                            }
                            if(state.Value == "GameSuperWon")
                            {
                                player.knowledge = player.knowledge + 3;
                                player.highNormalRank = player.RankingCalculation(player.normalGamePositivePoints, player.normalGameNegativePoints, player.knowledge);
                                input = Console.ReadLine();
                                isBonusNotPassed = "No";
                                Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
                            }
                        }
                        else
                        {
                            pointCategory = (recentScreen.Elements("PointCategory"));
                            /*
                            if (state.Value == "GameWon")
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    player.normalGameNegativePoints[i] = player.normalGameNegativePoints[i] - int.Parse(File.ReadAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt")));
                                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt"), "0");
                                }
                            }
                            */
                            for(int i = 0; i < pointCategory.Count(); i++)
                            {
                                if (state.Value == "GameOver")
                                {
                                    if (int.Parse(pointCategory.ElementAt(i).Value) <= 5)
                                    {
                                        player.normalGameNegativePoints[int.Parse(pointCategory.ElementAt(i).Value)]++;
                                        int recent = int.Parse(File.ReadAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt")));
                                        File.WriteAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt"), ((recent+1).ToString()));
                                        
                                    }
                                }
                                if (state.Value == "GameWon")
                                {
                                    int recent = int.Parse(File.ReadAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt")));
                                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt"), ((recent + 1).ToString()));

                                    stage.Won = true;
                                    stage.Locked = true;
                                    player.normalGamePositivePoints[int.Parse(pointCategory.ElementAt(i).Value)]++;
                                    player.highNormalRank = player.RankingCalculation(player.normalGamePositivePoints, player.normalGameNegativePoints, player.knowledge);                                    
                                }
                            }
                            if (state.Value == "GameWon")
                            {
                                Console.ReadLine();
                                Tip(player, NormalLevels);
                                if (isBonusNotPassed == "Yes")
                                {
                                    Console.Clear();
                                    path.Value = @"DebateGame\BonusGame\intro.txt";
                                    WritingText(path.Value);
                                    Console.ReadLine();
                                    path = recentScreen.Element("BonusPath");
                                    isBonus = true;
                                    XDocument BonusDataBase = new XDocument(XDocument.Load(path.Value));
                                    screens = BonusDataBase.Root.Elements("Screen");
                                    recentScreen = screens.First();
                                    path = recentScreen.Element("Path");
                                    answers = recentScreen.Element("Answers");
                                    state = recentScreen.Element("State");
                                    charAnswerA = answers.Element("a");
                                    charAnswerB = answers.Element("b");
                                    charAnswerC = answers.Element("c");
                                    charAnswerD = answers.Element("d");
                                    charAnswerE = answers.Element("e");
                                    anAnswer.RemoveRange(0, 5);
                                    anAnswer.Add(charAnswerA);
                                    anAnswer.Add(charAnswerB);
                                    anAnswer.Add(charAnswerC);
                                    anAnswer.Add(charAnswerD);
                                    anAnswer.Add(charAnswerE);
                                    next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, beforenegative);
                                }
                            }
                            if (state.Value == "GameOver")
                            {
                                input = Console.ReadLine();
                            }
                        Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
                    }
                    }
                    else
                    {
                        answers = recentScreen.Element("Answers");
                        anAnswer.RemoveRange(0, 5);
                        anAnswer.Add(answers.Element("a"));
                        anAnswer.Add(answers.Element("b"));
                        anAnswer.Add(answers.Element("c"));
                        anAnswer.Add(answers.Element("d"));
                        anAnswer.Add(answers.Element("e"));
                        next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, beforenegative);
                    }
                }
            }
            next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, beforenegative);
        }
        #endregion
        #region Tip
        public void Tip(Player player, List<Stage> normal)
        {
            if (player.highNormalRank >= 2)
            {
                PrintFile(@"DebateGame\Tips\TIP10.txt", @"DebateGame\Tips\TIP10DONE.txt");
            }
            if (player.highNormalRank >= 5)
            {
                PrintFile(@"DebateGame\Tips\TIP9.txt", @"DebateGame\Tips\TIP9DONE.txt");
            }
            int count = 0;
            bool isElseWon = false;
            int OneWon = 0;
            bool is3Won = true;
            foreach(Stage stage in normal)
            {
                if(stage.Won)
                {
                    count++;
                }
                if(stage.Won && stage.diffculty > 1)
                {
                    isElseWon = true;
                }
                if(!stage.Won && stage.diffculty == 3)
                {
                    is3Won = false;
                }
                if(stage.Won && stage.diffculty == 1)
                {
                    OneWon = OneWon + 1;
                }
            }
            if ((count / player.highNormalRank) > 2.5) 
            {
                PrintFile(@"DebateGame\Tips\TIP2.txt", @"DebateGame\Tips\TIP2DONE.txt");
            }
            if(OneWon == 3 && !isElseWon)
            {
                PrintFile(@"DebateGame\Tips\TIP1.txt", @"DebateGame\Tips\TIP1DONE.txt");
            }
            if(is3Won)
            {
                PrintFile(@"DebateGame\Tips\TIP15.txt", @"DebateGame\Tips\TIP15DONE.txt");
            }
        }
        public void PrintFile(string path, string createPath)
        {
            if (!(File.Exists(createPath)))
            {
                Console.Clear();
                WritingText(path);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                
                var Myfile = File.Create(createPath);
                Myfile.Close();
                Console.ReadLine();
            }
        }
        #endregion
        #endregion

        #region Properties
        bool isBonus { get; set; }
        string input { get; set; }
        XDocument DataBase { get; set; }
        IEnumerable<XElement> screens { get; set; }
        XElement path { get; set; }
        XElement state { get; set; }
        IEnumerable<XElement> pointCategory { get; set; }
        XElement answers { get; set; }
        XElement recentScreen { get; set; }
        List<XElement> anAnswer { get; set; }
        XElement charAnswerA { get; set; }
         XElement charAnswerB { get; set; }
         XElement charAnswerC { get; set; }
         XElement charAnswerD { get; set; }
         XElement charAnswerE { get; set; }
        string isBonusNotPassed { get; set; }
        #endregion
    }
}
