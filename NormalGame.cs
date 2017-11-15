using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class NormalGame : Program
    {
        #region ctor

        public NormalGame(Stage currectStage, Player player)
        {
            #region intializing the necessary properties

            isTheStageABonus = false;
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            answers = new XElement(recentScreen.Element("Answers"));
            pointCategoriesToUpdate = new List<XElement>(recentScreen.Elements("pointCategory"));
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
                    Console.WriteLine("Enter any key to continue");
                    Console.WriteLine();
                    Console.ReadLine();
                }
            }

            #endregion
        }

        #endregion

        #region functions (in addition)

        #region opening the next screen

        public void next(Stage stage, Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, List<int> beforepositive, List<int> beforenegative)
        {
            Console.Clear();
            WritingText(path.Value);
            Console.WriteLine();

            Console.WriteLine("Enter the letter (a/b/c/d/e) of the best answer");
            MainMeunMessage();
            input = Console.ReadLine();

            if (ShouldIReturnToMainMeun(input))
            {
                return;
            }

            int result;
            while ((((input.ToUpper() != "A") &&
                (input.ToUpper() != "B") &&
                (input.ToUpper() != "C") &&
                (input.ToUpper() != "D") &&
                (input.ToUpper() != "E") &&
                !(int.TryParse(input.ToUpper(), out result))))
                || (int.TryParse(input.ToUpper(), out result)))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Enter again:");
                Console.WriteLine();
                input = Console.ReadLine();

                if (ShouldIReturnToMainMeun(input))
                {
                    return;
                }
            }

            foreach (XElement answer in anAnswer)
            {
                if (input.ToUpper() == answer.Element("text").Value.ToUpper())
                {
                    Console.Clear();
                    path = answer.Element("NextScreen");

                    foreach (var screen in screens)
                    {
                        if (screen.Element("Path").Value == path.Value)
                        {
                            recentScreen = screen;
                        }
                    }

                    state = recentScreen.Element("State");

                    WritingText(path.Value);

                    if (state.Value == "MiddleGame")
                    {
                        MainMeunMessage();
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter anything to continue");
                        Console.WriteLine();
                    }

                    if (state.Value == "GameOver" || state.Value == "GameWon" || state.Value == "GameSuperWon")
                    {
                        if (isTheStageABonus)
                        {
                            if (state.Value == "GameWon")
                            {
                                player.Knowledge++;
                                player.HighNormalRank = player.RankingCalculation(player.NormalGamePositivePoints, player.NormalGameNegativePoints, player.Knowledge);
                                Console.ReadLine();
                                Tip(player, NormalLevels);
                                isBonusNotPassed = "No";

                                return;
                            }

                            if (state.Value == "GameOver")
                            {
                                input = Console.ReadLine();
                                Tip(player, NormalLevels);
                                isBonusNotPassed = "No";

                                return;
                            }

                            if (state.Value == "GameSuperWon")
                            {
                                player.Knowledge = player.Knowledge + 3;
                                player.HighNormalRank = player.RankingCalculation(player.NormalGamePositivePoints, player.NormalGameNegativePoints, player.Knowledge);
                                input = Console.ReadLine();
                                Tip(player, NormalLevels);
                                isBonusNotPassed = "No";

                                return;
                            }
                        }

                        else
                        {
                            pointCategoriesToUpdate = (recentScreen.Elements("PointCategory"));
                            for (int i = 0; i < pointCategoriesToUpdate.Count(); i++)
                            {
                                if (state.Value == "GameOver")
                                {
                                    if (int.Parse(pointCategoriesToUpdate.ElementAt(i).Value) <= 5)
                                    {
                                        player.NormalGameNegativePoints[int.Parse(pointCategoriesToUpdate.ElementAt(i).Value)]++;
                                        int recent = int.Parse(File.ReadAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt")));
                                        File.WriteAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt"), ((recent + 1).ToString()));
                                    }
                                }
                                if (state.Value == "GameWon")
                                {
                                    int recent = int.Parse(File.ReadAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt")));
                                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt"), ((recent + 1).ToString()));

                                    stage.Won = true;
                                    stage.Locked = true;
                                    player.NormalGamePositivePoints[int.Parse(pointCategoriesToUpdate.ElementAt(i).Value)]++;
                                    player.HighNormalRank = player.RankingCalculation(player.NormalGamePositivePoints, player.NormalGameNegativePoints, player.Knowledge);
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
                                    isTheStageABonus = true;
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
                                    next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, beforenegative);

                                    return;
                                }
                            }

                            if (state.Value == "GameOver")
                            {
                                input = Console.ReadLine();
                                Tip(player, NormalLevels);
                            }

                            return;
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
                        next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, beforenegative);

                        return;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("This answer doesn't exist!");
            Console.WriteLine("Enter anything to return entering an answer");
            Console.WriteLine();
            Console.ReadLine();

            next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions,
                beforepositive, beforenegative);

            return;
        }

        #endregion

        #region Tip

        public void Tip(Player player, List<Stage> normal)
        {
            int count = 0;
            bool isElseWon = false;
            int OneWon = 0;
            bool is3Won = true;
            bool is2Won = true;
            bool isPhilosophyWonEnough = true;
            bool isScienceWonEnough = true;
            
            foreach (Stage stage in normal)
            {
                if(stage.Won)
                {
                    count++;
                }
                if(stage.Won && stage.Diffculty > 1)
                {
                    isElseWon = true;
                }
                if(!stage.Won && stage.Diffculty == 3)
                {
                    is3Won = false;
                }
                if(stage.Won && stage.Diffculty == 1)
                {
                    OneWon = OneWon + 1;
                }
                if(!stage.Won && stage.Diffculty == 2)
                {
                    is2Won = false;
                }
                if (stage.Name == "God" || stage.Name == "The mind-body problem")
                {
                    if(!stage.Won)
                    {
                        isPhilosophyWonEnough = false;
                    }
                }
                if(stage.Name == "Video Games and violence" || stage.Name == "Lies"
                || stage.Name == "Homeopathy" || stage.Name == "Intelligence"
                || stage.Name == "Happiness and suffering")
                {
                    if(!stage.Won)
                    {
                        isScienceWonEnough = false;
                    }
                }
            }
            if (player.HighNormalRank >= 2)
            {
                PrintFile(@"DebateGame\Tips\TIP10.txt", @"DebateGame\Tips\TIP10DONE.txt");
            }
            if (player.HighNormalRank >= 5)
            {
                PrintFile(@"DebateGame\Tips\TIP9.txt", @"DebateGame\Tips\TIP9DONE.txt");
            }
            if ((count / player.HighNormalRank) > 2.5) 
            {
                PrintFile(@"DebateGame\Tips\TIP2.txt", @"DebateGame\Tips\TIP2DONE.txt");
            }
            if(OneWon == 3 && !isElseWon)
            {
                PrintFile(@"DebateGame\Tips\TIP1.txt", @"DebateGame\Tips\TIP1DONE.txt");
            }
            if(is3Won)
            {
                PrintFile(@"DebateGame\Tips\TIP14.txt", @"DebateGame\Tips\TIP14DONE.txt");
            }
            if(is2Won)
            {
                PrintFile(@"DebateGame\Tips\TIP15.txt", @"DebateGame\Tips\TIP15DONE.txt");
            }
            if(isPhilosophyWonEnough)
            {
                PrintFile(@"DebateGame\Tips\TIP17.txt", @"DebateGame\Tips\TIP17DONE.txt");
            }
            if(isScienceWonEnough)
            {
                PrintFile(@"DebateGame\Tips\TIP18.txt", @"DebateGame\Tips\TIP18DONE.txt");
            }
            if(count == 11)
            {
                PrintFile(@"DebateGame\Tips\TIP21.txt", @"DebateGame\Tips\TIP21DONE.txt");
            }
        }

        public void PrintFile(string path, string createPath)
        {
            if (!(File.Exists(createPath)))
            {
                Console.Clear();
                WritingText(path);
                Console.WriteLine();
                Console.WriteLine("Enter any key to continue");
                Console.WriteLine();
                var Myfile = File.Create(createPath);
                Myfile.Close();
                Console.ReadLine();
            }
        }

        #endregion

        #endregion

        #region Properties

        bool isTheStageABonus { get; set; }
        string input { get; set; }
        XDocument DataBase { get; set; }
        IEnumerable<XElement> screens { get; set; }
        XElement path { get; set; }
        XElement state { get; set; }
        IEnumerable<XElement> pointCategoriesToUpdate { get; set; }
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
