using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class HardcoreGame : Program
    {
        #region ctor
        public HardcoreGame(Stage currectStage, Player player)
        {
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            answerElement = new XElement(recentScreen.Element("Answers"));
            answers = new List<XElement>(answerElement.Elements("Answer"));
            state = new XElement(recentScreen.Element("State"));
            numOfAnswers = new XElement(recentScreen.Element("ANum"));
            input = new List<int>();
            theTruth = new List<int>();
            apply = new UpdatingPointsInExplainingModes();
            RecentPositive = new List<int>();
            RecentNegative = new List<int>();
            DefaultPositive = new List<int>();
            DefaultNegative = new List<int>();
            RecentDefaultPositive = new List<int>();
            RecentDefaultNegative = new List<int>();
            foreach (int cell in player.HardcoreGamePositivePoints)
            {
                RecentPositive.Add(cell);
                DefaultPositive.Add(0);
                RecentDefaultPositive.Add(0);
            }
            foreach (int cell in player.HardcoreGameNegativePoints)
            {
                RecentNegative.Add(cell);
                DefaultNegative.Add(0);
                RecentDefaultNegative.Add(0);
            }
            comment = new XElement(recentScreen.Element("Comment"));
        }
        #endregion

        #region opening the next screen and updating points

        public void next(Stage stage, Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, List<int> PreviousPositive, List<int> PreviousNegative)
        {
            Console.Clear();
            WritingText(path.Value);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("In order to view the list of moves, enter L as an answer");
            Console.WriteLine();
            Console.WriteLine("enter C as an answer, to go one screen back (and fix mistakes)");
            Console.WriteLine();

            if (answers.ElementAt(0).Value == "0")
            {
                Console.WriteLine("No answer - enter '0' to continue");
            }
            else
            {
                Console.WriteLine($"For this screen, there are {numOfAnswers.Value} answers.");
            }

            Console.WriteLine();
            MainMeunMessage();
            input.RemoveRange(0, input.Count);
            theTruth.RemoveRange(0, theTruth.Count);

            if (comment.Value != "No")
            {
               Console.WriteLine();
               Console.WriteLine("Author's comment:");
               Console.WriteLine();
               WritingText(comment.Value);
               Console.WriteLine();
            }

            for (int i = 0; i < int.Parse(numOfAnswers.Value); i++)
            {
                int result;
                Console.WriteLine();
                Console.WriteLine($"Answer {i + 1}:");
                Console.WriteLine();
                oneInput = Console.ReadLine();

                while ((!(int.TryParse(oneInput, out result)))
                    && oneInput.ToUpper() != "M" && oneInput.ToUpper() != "L"
                    && oneInput.ToUpper() != "C")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Enter again:");
                    Console.WriteLine();
                    oneInput = Console.ReadLine();
                }

                if (ShouldIReturnToMainMeun(oneInput))
                {
                    player.HardcoreGamePositivePoints = PreviousPositive;
                    player.HardcoreGameNegativePoints = PreviousNegative;

                    return;
                }

                if (oneInput.ToUpper() == "L")
                {
                    Console.Clear();
                    WritingText(@"DebateGame\hardcoreGame\intro.txt");
                    Console.WriteLine();
                    Console.WriteLine("enter any key to go back to the stage");
                    Console.WriteLine();
                    Console.ReadLine();
                    next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);

                    return;
                }

                if (oneInput.ToUpper() == "C")
                {
                    for (int cell = 0; cell < RecentPositive.Count(); cell++)
                    {
                        player.HardcoreGamePositivePoints[cell] = RecentPositive[cell];
                        DefaultPositive[cell] = RecentDefaultPositive[cell];
                    }
                    for (int cell = 0; cell < RecentNegative.Count(); cell++)
                    {
                        player.HardcoreGameNegativePoints[cell] = RecentNegative[cell];
                        DefaultNegative[cell] = RecentDefaultNegative[cell];
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
                    numOfAnswers = recentScreen.Element("ANum");
                    comment = recentScreen.Element("Comment");
                    next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);

                    return;
                }

                input.Add(int.Parse(oneInput));
            }

            foreach (XElement answer in answers)
            {
                theTruth.Add(int.Parse(answer.Value));
            }

            for (int cell = 0; cell < player.HardcoreGamePositivePoints.Count(); cell++)
            {
                RecentPositive[cell] = player.HardcoreGamePositivePoints[cell];
                RecentDefaultPositive[cell] = DefaultPositive[cell];
            }

            for (int cell = 0; cell < player.HardcoreGameNegativePoints.Count(); cell++)
            {
                RecentNegative[cell] = player.HardcoreGameNegativePoints[cell];
                RecentDefaultNegative[cell] = DefaultNegative[cell];
            }

            player.HardcoreGamePositivePoints = apply.UpdatingPositivePoints(input, theTruth, player.HardcoreGamePositivePoints, player.HardcoreGameNegativePoints, "H");
            player.HardcoreGameNegativePoints = apply.UpdatingNegativePoints(input, theTruth, player.HardcoreGamePositivePoints, player.HardcoreGameNegativePoints, "H");
            DefaultPositive = apply.UpdatingPositivePoints(input, theTruth, DefaultPositive, DefaultNegative, "H");
            DefaultNegative = apply.UpdatingNegativePoints(input, theTruth, DefaultPositive, DefaultNegative, "H");

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
                numOfAnswers = recentScreen.Element("ANum");
                comment = recentScreen.Element("Comment");
                SecretPath = recentScreen.Element("SecretPath");
                next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);

                return;
            }

            #endregion

            #region loading the end

            if (state.Value == "GameSet")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You've passed all the screens for this stage in this mode.");
                Console.WriteLine();
                XElement ranking = new XElement(recentScreen.Element("Ranking"));
                double gap = player.RankingCalculation(DefaultPositive, DefaultNegative, 0);
                Console.WriteLine();
                Console.WriteLine($"To win, you need to get a ranking from this stage");
                Console.WriteLine($"of at least {ranking.Value} points.");
                Console.WriteLine($"While you've got a ranking here of {gap} points.");
                if (gap >= double.Parse(ranking.Value))
                {
                    double supposedNewRank = player.RankingCalculation(player.HardcoreGamePositivePoints, player.HardcoreGameNegativePoints, 0);
                    if (player.HighHardcoreRank < supposedNewRank)
                    {
                        player.HighHardcoreRank = supposedNewRank;
                    }
                    stage.Won = true;
                    stage.Locked = true;
                    stage = UpdatingUnlocking2(stage, "TRUE", Interaptions);
                    Console.WriteLine();
                    Console.WriteLine("You've gotten a ranking high enough to win this stage! You can keep your points");
                    Console.WriteLine();
                    Console.WriteLine("You can reset the points you've gotten in this stage");
                    Console.WriteLine("if you want and keep this stage unlocked, thought. Enter R to do so.");
                    Console.WriteLine();
                    Console.WriteLine("Enter anything else to return to the main meun");

                    string reset = Console.ReadLine();
                    if (reset.ToUpper() == "R")
                    {
                        stage.Won = false;
                        stage.Locked = false;
                        stage = UpdatingUnlocking2(stage, "FALSE", Interaptions);
                        Console.WriteLine();
                        player.HardcoreGamePositivePoints = PreviousPositive;
                        player.HardcoreGameNegativePoints = PreviousNegative;
                        Console.WriteLine("Your points have been reseted.");
                        Console.WriteLine();
                        Console.WriteLine("enter any key to return to the main meun");
                        Console.ReadLine();
                    }

                    List<int> PositiveGap = new List<int>();
                    List<int> NegativeGap = new List<int>();
                    for (int i = 0; i < player.HardcoreGamePositivePoints.Count(); i++)
                    {
                        PositiveGap.Add(player.HardcoreGamePositivePoints[i] - PreviousPositive[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), PositiveGap[i].ToString());
                        NegativeGap.Add(player.HardcoreGameNegativePoints[i] - PreviousNegative[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), NegativeGap[i].ToString());
                    }

                    Tip(player, HardcoreLevels, NormalLevels, ExplainLevels, Interaptions, stage);
                    return;

                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, you haven't increased your ranking enough to win here.");
                    Console.WriteLine();
                    Console.WriteLine("Your hardcore status will return to what they were before this level.");
                    player.HardcoreGamePositivePoints = PreviousPositive;
                    player.HardcoreGameNegativePoints = PreviousNegative;
                    Console.WriteLine();
                    Console.WriteLine("Enter any key to return to the main meun");
                    string reset = Console.ReadLine();

                    return;
                }
            }
        }

        #endregion

        #region Updating Unlocking

        private Stage UpdatingUnlocking2(Stage stage, string TrueOrFalse, List<Stage> Interpating)
        {
            string[] HardCoreUnlock = File.ReadAllLines(@"DebateGame\stages\hardcoreunlock.txt");
            string[] InterpationsUnlock = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");

            if (TrueOrFalse.ToUpper() == "TRUE")
            {
                stage.Unlockable = true;
                HardCoreUnlock[stage.Position - 1] = "True";
                InterpationsUnlock[stage.Position - 1] = "True";
            }
            else if (TrueOrFalse.ToUpper() == "FALSE")
            {
                stage.Unlockable = false;
                HardCoreUnlock[stage.Position - 1] = "False";
                InterpationsUnlock[stage.Position - 1] = "False";
            }

            File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", HardCoreUnlock);
            File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlock);

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
            bool isGodWon = true;

            foreach(Stage stageH in stages)
            {
                if(stageH.Won && stageH.Diffculty > 1)
                {
                    isOneWon = false;
                }
                if(!stageH.Won && stageH.Diffculty == 1)
                {
                    isOneWon = false;
                }
                if(stageH.Won && stageH.Diffculty > 3)
                {
                    isThirdWon = false;
                }
                if(!stageH.Won && stageH.Diffculty <= 3)
                {
                    isThirdWon = false;
                }
                if(!stageH.Won && stageH.Name == "God")
                {
                    isGodWon = false;
                }
                  
            }
            foreach (Stage stageE in Explain)
            {
                if ((stageE.Name == currectStage.Name) && (stageE.Won && stageE.Unlockable))
                {
                    if(currectStage.Won && currectStage.Unlockable)
                    {
                        InteraptUnlocked = true;
                    }
                }
                if(!stageE.Won && stageE.Name == "God")
                {
                    isGodWon = false;
                }
            }

            if (player.HighHardcoreRank >= 9)
            {
                PrintFile(@"DebateGame\Tips\TIP5.txt", @"DebateGame\Tips\TIP5DONE.txt");
            }
            if(isOneWon)
            {
                PrintFile(@"DebateGame\Tips\TIP8.txt", @"DebateGame\Tips\TIP8DONE.txt");
            }
            if(isThirdWon)
            {
                PrintFile(@"DebateGame\Tips\TIP11.txt", @"DebateGame\Tips\TIP11DONE.txt");
            }
            if(InteraptUnlocked)
            {
                PrintFile(@"DebateGame\Tips\TIP12.txt", @"DebateGame\Tips\TIP12DONE.txt");
            }
            if (player.ExplainGameNegativePoints[5] + player.HardcoreGameNegativePoints[5] > 2)
            {
                PrintFile(@"DebateGame\Tips\TIP16.txt", @"DebateGame\Tips\TIP16DONE.txt");
            }
            if(isGodWon)
            {
                PrintFile(@"DebateGame\Tips\TIP20.txt", @"DebateGame\Tips\TIP20DONE.txt");
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

        #region Properties

        List<int> input { get; set; }
        XDocument DataBase { get; set; }
        IEnumerable<XElement> screens { get; set; }
        XElement path { get; set; }
        XElement state { get; set; }
        XElement answerElement { get; set; }
        XElement recentScreen { get; set; }
        IEnumerable<XElement> answers { get; set; }
        XElement numOfAnswers { get; set; }
        XElement comment { get; set; }
        XElement SecretPath { get; set; }
        string oneInput { get; set; }
        List<int> theTruth { get; set; }
        UpdatingPointsInExplainingModes apply { get; set; }
        List<int> RecentPositive { get; set; }
        List<int> RecentNegative { get; set; }
        List<int> DefaultPositive { get; set; }
        List<int> DefaultNegative { get; set; }
        List<int> RecentDefaultPositive { get; set; }
        List<int> RecentDefaultNegative { get; set; }
        #endregion
    }
}