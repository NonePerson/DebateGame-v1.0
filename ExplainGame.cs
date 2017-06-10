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
    public class ExplainGame : Program
    {
        #region ctor
        public ExplainGame(Stage currectStage, Player player, Game NewGame)
        {
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            answerElement = new XElement(recentScreen.Element("Answers"));
            answers = new List<XElement>(answerElement.Elements("Answer"));
            state = new XElement(recentScreen.Element("State"));
            ANum = new XElement(recentScreen.Element("ANum"));
            apply = new HardcoreGameAnswers();
            input = new List<int>();
            theTrue = new List<int>();
            RecentPositive = new List<int>();
            RecentNegative = new List<int>();
            foreach (int cell in player.ExplanationGamePositive)
            {
                RecentPositive.Add(cell);
            }
            foreach (int cell in player.ExplanationGameNegative)
            {
                RecentNegative.Add(cell);
            }
            comment = recentScreen.Element("Comment");
            SecretPath = recentScreen.Element("SecretPath");
        }

        #endregion ctor
        #region the function
        public void next(Stage stage, Player player, Game NewGame, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, List<int> PreviousPositive2, List<int> PreviousNegative2)
        {
            Console.Clear();
            WritingText(path.Value);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("In order to view the list of moves, press L as an answer");
            Console.WriteLine();
            Console.WriteLine("press C as an answer, to go one screen back (and fix mistakes)");
            Console.WriteLine();
            Console.WriteLine($"For this screen, there are {ANum.Value} answers.");
            Console.WriteLine();
            MainMeunMessage();
            input.RemoveRange(0, input.Count);
            theTrue.RemoveRange(0, theTrue.Count);
            if(int.Parse(ANum.Value) == 0)
            {
                Console.WriteLine("No answers - press any key to continue");
                Console.ReadLine();
            }
            if (comment.Value != "No")
            {
                Console.WriteLine();
                WritingText(comment.Value);
                Console.WriteLine();
            }
            for (int i = 0; i < int.Parse(ANum.Value); i++)
            {
                /*
                string Secret = "S";
                bool SecretUnlocked = false;
                if(SecretPath.Value != "No")
                {
                    Console.WriteLine();
                    Console.WriteLine("Press S to enter a secret path");
                    Console.WriteLine();
                    SecretUnlocked = true;
                }
                */
                int result;
                Console.WriteLine();
                Console.WriteLine($"Answer {i+1}:");
                Console.WriteLine();
                oneInput = Console.ReadLine();
                if (oneInput.ToUpper() == "M")
                {
                    player.ExplanationGamePositive = PreviousPositive2;
                    player.ExplanationGameNegative = PreviousNegative2;
                    Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, oneInput);
                }
                if (oneInput.ToUpper() == "L")
                {
                    Console.Clear();
                    WritingText(@"DebateGame\ExplainGame\list.txt");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the stage");
                    Console.WriteLine();
                    Console.ReadLine();
                    next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);
                }
                if (oneInput.ToUpper() == "C")
                {

                    for (int cell = 0; cell < RecentPositive.Count(); cell++)
                    {
                        player.ExplanationGamePositive[cell] = RecentPositive[cell];
                    }
                    for (int cell = 0; cell < RecentNegative.Count(); cell++)
                    {
                        player.ExplanationGameNegative[cell] = RecentNegative[cell];
                    }

                    path = recentScreen.Element("PreviousScreen");
                    foreach (var screen in screens)
                    {
                        if (screen.Element("Path").Value == path.Value)
                        {
                            recentScreen = screen;
                        }
                    }
                    answerElement = recentScreen.Element("Answers");
                    answers = answerElement.Elements("Answer");
                    state = recentScreen.Element("State");
                    ANum = recentScreen.Element("ANum");
                    next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);

                }
                if (!(int.TryParse(oneInput, out result)))
                {
                    next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);
                }
                input.Add(int.Parse(oneInput));
            }
            foreach (XElement answer in answers)
            {
                theTrue.Add(int.Parse(answer.Value));
            }
            for (int cell = 0; cell < player.ExplanationGamePositive.Count(); cell++)
            {
                RecentPositive[cell] = player.ExplanationGamePositive[cell];
            }
            for (int cell = 0; cell < player.ExplanationGameNegative.Count(); cell++)
            {
                RecentNegative[cell] = player.ExplanationGameNegative[cell];
            }
            if (int.Parse(ANum.Value) > 0)
            {
                player.ExplanationGamePositive = apply.UpdatingPositivePoints(input, theTrue, player.ExplanationGamePositive, player.ExplanationGameNegative, "E");
                player.ExplanationGameNegative = apply.UpdatingNegativePoints(input, theTrue, player.ExplanationGamePositive, player.ExplanationGameNegative, "E");
            }
            #region loading the next screen
            if (state.Value == "MiddleGame")
            {
                path = recentScreen.Element("NextScreen");
                foreach (var screen in screens)
                {
                    if (screen.Element("Path").Value == path.Value)
                    {
                        recentScreen = screen;
                    }
                }
                answerElement = recentScreen.Element("Answers");
                answers = answerElement.Elements("Answer");
                state = recentScreen.Element("State");
                ANum = recentScreen.Element("ANum");
                comment = recentScreen.Element("Comment");
                SecretPath = recentScreen.Element("SecretPath");
                next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);
                #endregion
            }
            if (state.Value == "GameSet")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You've passed all the screens for this level in this mode.");
                Console.WriteLine();
                XElement ranking = new XElement(recentScreen.Element("Ranking"));
                double gap = player.RankingCalculation(player.ExplanationGamePositive, player.ExplanationGameNegative, 0) -
                    player.RankingCalculation(PreviousPositive2, PreviousNegative2, 0);
                Console.WriteLine();
                Console.WriteLine($"To win, you need to increase your ranking from this level");
                Console.WriteLine($"by at least {ranking.Value} points.");
                Console.WriteLine($"While you've increased your ranking by {gap} points.");
                if (gap >= double.Parse(ranking.Value))
                {
                    player.highExplanationRank = player.RankingCalculation(player.ExplanationGamePositive, player.ExplanationGameNegative, 0);
                    stage.Won = true;
                    stage.Locked = true;
                    Console.WriteLine();
                    Console.WriteLine("You've increased your ranking enough to win this level! You can keep your points");
                    Console.WriteLine();
                    Console.WriteLine("You can reset the points you've gotten in this level");
                    Console.WriteLine("if you want and keep this level unlocked, thought. Press R to do so.");
                    Console.WriteLine();
                    Console.WriteLine("Press M to return to the main meun");
                    string reset = Console.ReadLine();
                    if (reset.ToUpper() == "R")
                    {
                        stage.Won = false;
                        stage.Locked = false;
                        Console.WriteLine();
                        player.ExplanationGamePositive = PreviousPositive2;
                        player.ExplanationGameNegative = PreviousNegative2;
                        Console.WriteLine("Your points have been reseted.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the main meun");
                        Console.ReadLine();
                    }
                    List<int> PositiveGap = new List<int>();
                    List<int> NegativeGap = new List<int>();
                    for (int i = 0; i < player.ExplanationGamePositive.Count(); i++)
                    {
                        PositiveGap.Add(player.ExplanationGamePositive[i] - PreviousPositive2[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), PositiveGap[i].ToString());
                        NegativeGap.Add(player.ExplanationGameNegative[i] - PreviousNegative2[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), NegativeGap[i].ToString());
                    }
                    Tip(player);
                    Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, you haven't increased your ranking enough to win here.");
                    Console.WriteLine();
                    Console.WriteLine("Your explanation status will return to what they were before this level.");
                    player.ExplanationGamePositive = PreviousPositive2;
                    player.ExplanationGameNegative = PreviousNegative2;
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the main meun");
                    string reset = Console.ReadLine();
                    Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "M");
                }
            }
            }
        #endregion

        #region Tip
        public void Tip(Player player)
        {
            if (player.highExplanationRank >= 8)
            {
                PrintFile(@"DebateGame\Tips\TIP3.txt", @"DebateGame\Tips\TIP3DONE.txt");
            }
            if(player.highExplanationRank >= 22)
            {
                PrintFile(@"DebateGame\Tips\TIP4.txt", @"DebateGame\Tips\TIP4DONE.txt");
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

        #region Properties

        List<int> input { get; set; }
        XDocument DataBase { get; set; }
        IEnumerable<XElement> screens { get; set; }
        XElement path { get; set; }
        XElement state { get; set; }
        XElement answerElement { get; set; }
        XElement recentScreen { get; set; }
        IEnumerable<XElement> answers { get; set; }
        XElement ANum { get; set; }
        XElement comment { get; set; }
        XElement SecretPath { get; set; }
        string oneInput { get; set; }
        List<int> theTrue { get; set; }
        HardcoreGameAnswers apply { get; set; }
        List<int> RecentPositive { get; set; }
        List<int> RecentNegative { get; set; }
        #endregion
    }
}
