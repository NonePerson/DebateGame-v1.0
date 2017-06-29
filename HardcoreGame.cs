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
    public class HardcoreGame : Program
    {
        #region ctor
        public HardcoreGame(Stage currectStage, Player player, Game NewGame)
        {
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            answerElement = new XElement(recentScreen.Element("Answers"));
            answers = new List<XElement>(answerElement.Elements("Answer"));
            state = new XElement(recentScreen.Element("State"));
            ANum = new XElement(recentScreen.Element("ANum"));
            input = new List<int>();
            theTrue = new List<int>();
            apply = new HardcoreGameAnswers();
            RecentPositive = new List<int>();
            RecentNegative = new List<int>();
            foreach (int cell in player.hardcoreGamePositivePoints)
            {
                RecentPositive.Add(cell);
            }
            foreach (int cell in player.hardcoreGameNegativePoints)
            {
                RecentNegative.Add(cell);
            }
            comment = new XElement(recentScreen.Element("Comment"));
        }
        #endregion

        #region opening the next screen and updating points
        public void next(Stage stage, Player player, Game NewGame, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, List<int> PreviousPositive, List<int> PreviousNegative)
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
            if (comment.Value != "No")
            {
                Console.WriteLine();
                WritingText(comment.Value);
                Console.WriteLine();
            }
            for (int i = 0; i < int.Parse(ANum.Value); i++)
            {
                int result;
                Console.WriteLine();
                Console.WriteLine($"Answer {i + 1}:");
                Console.WriteLine();
                oneInput = Console.ReadLine();
                if (oneInput.ToUpper() == "M")
                {
                    player.hardcoreGamePositivePoints = PreviousPositive;
                    player.hardcoreGameNegativePoints = PreviousNegative;
                    Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, oneInput);
                }
                if (oneInput.ToUpper() == "L")
                {
                    Console.Clear();
                    WritingText(@"DebateGame\hardcoreGame\intro.txt");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the stage");
                    Console.WriteLine();
                    Console.ReadLine();
                    next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);
                }

                if (oneInput.ToUpper() == "C")
                {
                        for (int cell = 0; cell < RecentPositive.Count(); cell++)
                        {
                            player.hardcoreGamePositivePoints[cell] = RecentPositive[cell];
                        }
                        for (int cell = 0; cell < RecentNegative.Count(); cell++)
                        {
                            player.hardcoreGameNegativePoints[cell] = RecentNegative[cell];
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
                        comment = recentScreen.Element("Comment");
                        next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);
                    
                }
                if (!(int.TryParse(oneInput, out result)))
                {
                    next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);
                }
                input.Add(int.Parse(oneInput));
            }
                foreach (XElement answer in answers)
                {
                    theTrue.Add(int.Parse(answer.Value));
                }
                for (int cell = 0; cell < player.hardcoreGamePositivePoints.Count(); cell++)
                {
                    RecentPositive[cell] = player.hardcoreGamePositivePoints[cell];
                }
                for (int cell = 0; cell < player.hardcoreGameNegativePoints.Count(); cell++)
                {
                    RecentNegative[cell] = player.hardcoreGameNegativePoints[cell];
                }
                player.hardcoreGamePositivePoints = apply.UpdatingPositivePoints(input, theTrue, player.hardcoreGamePositivePoints, player.hardcoreGameNegativePoints, "H");
                player.hardcoreGameNegativePoints = apply.UpdatingNegativePoints(input, theTrue, player.hardcoreGamePositivePoints, player.hardcoreGameNegativePoints, "H");
                #endregion
            
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
                        next(stage, player, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);
                    }
                    #endregion

                    #region loading the end
                    if (state.Value == "GameSet")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You've passed all the screens for this level in this mode.");
                        Console.WriteLine();
                        XElement ranking = new XElement(recentScreen.Element("Ranking"));
                        double gap = player.RankingCalculation(player.hardcoreGamePositivePoints, player.hardcoreGameNegativePoints, 0) -
                            player.RankingCalculation(PreviousPositive, PreviousNegative, 0);
                        Console.WriteLine();
                        Console.WriteLine($"To win, you need to increase your ranking from this level");
                        Console.WriteLine($"by at least {ranking.Value} points.");
                        Console.WriteLine($"While you've increased your ranking by {gap} points.");
                        if (gap >= double.Parse(ranking.Value))
                        {
                            player.highHardcoreRank = player.RankingCalculation(player.hardcoreGamePositivePoints, player.hardcoreGameNegativePoints, 0);
                            stage.Won = true;
                            stage.Locked = true;
                            stage = UpdatingUnlocking2(stage, "TRUE", Interaptions);
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
                                stage = UpdatingUnlocking2(stage, "FALSE", Interaptions);
                                Console.WriteLine();
                                player.hardcoreGamePositivePoints = PreviousPositive;
                                player.hardcoreGameNegativePoints = PreviousNegative;
                                Console.WriteLine("Your points have been reseted.");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to the main meun");
                                Console.ReadLine();
                            }
                    List<int> PositiveGap = new List<int>();
                    List<int> NegativeGap = new List<int>();
                    for(int i = 0; i < player.hardcoreGamePositivePoints.Count(); i++)
                    {
                        PositiveGap.Add(player.hardcoreGamePositivePoints[i] - PreviousPositive[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), PositiveGap[i].ToString());
                        NegativeGap.Add(player.hardcoreGameNegativePoints[i] - PreviousNegative[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), NegativeGap[i].ToString());
                    }
                    Tip(player, HardcoreLevels, NormalLevels, ExplainLevels, Interaptions, stage);
                    Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry, you haven't increased your ranking enough to win here.");
                            Console.WriteLine();
                            Console.WriteLine("Your hardcore status will return to what they were before this level.");
                            player.hardcoreGamePositivePoints = PreviousPositive;
                            player.hardcoreGameNegativePoints = PreviousNegative;
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main meun");
                            string reset = Console.ReadLine();
                            Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "M");
                        }
                    }
                
        }

        #endregion

        #region Updating Unlocking

        Stage UpdatingUnlocking2(Stage stage, string TrueOrFalse, List<Stage> Interpating)
        {
            if (TrueOrFalse.ToUpper() == "TRUE")
            {
                stage.unlockable = true;
                string[] HardCoreUnlock = File.ReadAllLines(@"DebateGame\stages\hardcoreunlock.txt");
                HardCoreUnlock[stage.Position - 1] = "True";
                File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
                File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", HardCoreUnlock);

                string[] InterpationsUnlock = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                InterpationsUnlock[stage.Position - 1] = "True";
                File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlock);

                return stage;
            }
            else if (TrueOrFalse.ToUpper() == "FALSE")
            {
                stage.unlockable = false;
                string[] HardCoreUnlock = File.ReadAllLines(@"DebateGame\stages\hardcoreunlock.txt");
                HardCoreUnlock[stage.Position - 1] = "False";
                File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
                File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", HardCoreUnlock);

                string[] InterpationsUnlock = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                InterpationsUnlock[stage.Position - 1] = "False";
                File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlock);
            }
            return stage;
        }

        #endregion

        #region Tips

        public void Tip(Player player, List<Stage> stages, List<Stage> Normal, List<Stage> Explain, List<Stage> Interapt, Stage currectStage)
        {
            ChooseGame(stages, player, Normal, Explain, stages, Interapt);
            Console.Clear();
            bool InteraptUnlocked = false;
            bool isOneWon = true;
            bool isThirdWon = true;
            foreach(Stage stageH in stages)
            {
                if(stageH.Won && stageH.diffculty > 1)
                {
                    isOneWon = false;
                }
                if(!stageH.Won && stageH.diffculty == 1)
                {
                    isOneWon = false;
                }
                if(stageH.Won && stageH.diffculty > 3)
                {
                    isThirdWon = false;
                }
                if(!stageH.Won && stageH.diffculty <= 3)
                {
                    isThirdWon = false;
                }
                  
            }
            foreach (Stage stageE in Explain)
            {
                if ((stageE.Name == currectStage.Name) && (stageE.Won && stageE.unlockable))
                {
                    if(currectStage.Won && currectStage.unlockable)
                    {
                        InteraptUnlocked = true;
                    }
                }
            }
            if (player.highHardcoreRank >= 9)
            {
                PrintFile(@"DebateGame\Tips\TIP5.txt", @"DebateGame\Tips\TIP5DONE.txt");
            }
            if(isOneWon)
            {
                PrintFile(@"DebateGame\Tips\TIP8.txt", @"DebateGame\Tips\TIP8DONE.txt");
            }
            if(isThirdWon)
            {
                PrintFile(@"DebateGame\Tips\TIP12.txt", @"DebateGame\Tips\TIP12DONE.txt");
            }
            if(InteraptUnlocked)
            {
                PrintFile(@"DebateGame\Tips\TIP13.txt", @"DebateGame\Tips\TIP13DONE.txt");
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