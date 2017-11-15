using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class ExplainGame : Program
    {
        #region ctor

        public ExplainGame(Stage currectStage, Player player)
        {
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            answerElement = new XElement(recentScreen.Element("Answers"));
            answers = new List<XElement>(answerElement.Elements("Answer"));
            state = new XElement(recentScreen.Element("State"));
            numOfAnswers = new XElement(recentScreen.Element("ANum"));
            apply = new UpdatingPointsInExplainingModes();
            input = new List<int>();
            theTruth = new List<int>();
            RecentPositive = new List<int>();
            RecentNegative = new List<int>();
            DefaultPositive = new List<int>();
            DefaultNegative = new List<int>();
            RecentDefaultPositive = new List<int>();
            RecentDefaultNegative = new List<int>();

            foreach (int cell in player.ExplainGamePositivePoints)
            {
                RecentPositive.Add(cell);
                DefaultPositive.Add(0);
                RecentDefaultPositive.Add(0);
            }

            foreach (int cell in player.ExplainGameNegativePoints)
            {
                RecentNegative.Add(cell);
                DefaultNegative.Add(0);
                RecentDefaultNegative.Add(0);
            }

            comment = recentScreen.Element("Comment");
        }

        #endregion ctor

        #region the function

        public void next(Stage stage, Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, List<int> PreviousPositive2, List<int> PreviousNegative2)
        {
            Console.Clear();
            WritingText(path.Value);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("In order to view the list of moves, enter L as an answer");
            Console.WriteLine();
            Console.WriteLine("Enter C as an answer, to go one screen back (and fix mistakes)");
            Console.WriteLine();
            Console.WriteLine($"For this screen, there are {numOfAnswers.Value} answers.");
            Console.WriteLine();
            MainMeunMessage();
            input.RemoveRange(0, input.Count);
            theTruth.RemoveRange(0, theTruth.Count);

            if (int.Parse(numOfAnswers.Value) == 0)
            {
                CommentWriting(comment);
                Console.WriteLine("No answers - Enter any key to continue");
                Console.ReadLine();
            }

            CommentWriting(comment);

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
                    player.ExplainGamePositivePoints = PreviousPositive2;
                    player.ExplainGameNegativePoints = PreviousNegative2;

                    return;
                }

                if (oneInput.ToUpper() == "L")
                {
                    Console.Clear();
                    WritingText(@"DebateGame\ExplainGame\list.txt");
                    Console.WriteLine();
                    Console.WriteLine("Enter any key to go back to the stage");
                    Console.WriteLine();
                    Console.ReadLine();
                    next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);

                    return;
                }

                if (oneInput.ToUpper() == "C")
                {

                    for (int cell = 0; cell < RecentPositive.Count(); cell++)
                    {
                        player.ExplainGamePositivePoints[cell] = RecentPositive[cell];
                        DefaultPositive[cell] = RecentDefaultPositive[cell];
                    }
                    for (int cell = 0; cell < RecentNegative.Count(); cell++)
                    {
                        player.ExplainGameNegativePoints[cell] = RecentNegative[cell];
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
                    next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);

                    return;
                }

                input.Add(int.Parse(oneInput));
            }

            foreach (XElement answer in answers)
            {
                theTruth.Add(int.Parse(answer.Value));
            }

            for (int cell = 0; cell < player.ExplainGamePositivePoints.Count(); cell++)
            {
                RecentPositive[cell] = player.ExplainGamePositivePoints[cell];
                RecentDefaultPositive[cell] = DefaultPositive[cell];
            }

            for (int cell = 0; cell < player.ExplainGameNegativePoints.Count(); cell++)
            {
                RecentNegative[cell] = player.ExplainGameNegativePoints[cell];
                RecentDefaultNegative[cell] = DefaultNegative[cell];
            }

            if (int.Parse(numOfAnswers.Value) > 0)
            {
                player.ExplainGamePositivePoints = apply.UpdatingPositivePoints(input, theTruth, player.ExplainGamePositivePoints, player.ExplainGameNegativePoints, "E");
                player.ExplainGameNegativePoints = apply.UpdatingNegativePoints(input, theTruth, player.ExplainGamePositivePoints, player.ExplainGameNegativePoints, "E");
                DefaultPositive = apply.UpdatingPositivePoints(input, theTruth, DefaultPositive, DefaultNegative, "E");
                DefaultNegative = apply.UpdatingNegativePoints(input, theTruth, DefaultPositive, DefaultNegative, "E");
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
                numOfAnswers = recentScreen.Element("ANum");
                comment = recentScreen.Element("Comment");
                next(stage, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);

                return;

            }

            #endregion

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
                    double supposedNewRank = player.RankingCalculation(player.ExplainGamePositivePoints, player.ExplainGameNegativePoints, 0);
                    if (player.HighExplanationRank < supposedNewRank)
                    {
                        player.HighExplanationRank = supposedNewRank;
                    }
                    stage.Won = true;
                    stage.Locked = true;

                    stage = UpdatingUnlocking(stage, "TRUE");

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
                        stage = UpdatingUnlocking(stage, "FALSE");
                        Console.WriteLine();
                        player.ExplainGamePositivePoints = PreviousPositive2;
                        player.ExplainGameNegativePoints = PreviousNegative2;
                        Console.WriteLine("Your points have been reseted.");
                        Console.WriteLine();
                        Console.WriteLine("Enter any key to return to the main meun");
                        Console.WriteLine();
                        Console.ReadLine();
                    }

                    List<int> PositiveGap = new List<int>();
                    List<int> NegativeGap = new List<int>();
                    for (int i = 0; i < player.ExplainGamePositivePoints.Count(); i++)
                    {
                        PositiveGap.Add(player.ExplainGamePositivePoints[i] - PreviousPositive2[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), PositiveGap[i].ToString());
                        NegativeGap.Add(player.ExplainGameNegativePoints[i] - PreviousNegative2[i]);
                        File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), NegativeGap[i].ToString());
                    }

                    Tip(player, ExplainLevels);
                    return;

                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, you haven't increased your ranking enough to win here.");
                    Console.WriteLine();
                    Console.WriteLine("Your explanation status will return to what they were before this level.");
                    player.ExplainGamePositivePoints = PreviousPositive2;
                    player.ExplainGameNegativePoints = PreviousNegative2;
                    Console.WriteLine();
                    Console.WriteLine("Enter anything to return to the main meun");
                    Console.WriteLine();
                    string reset = Console.ReadLine();

                    return;
                }
            }
        }

        #endregion

        #region updating unlocking ability

        private Stage UpdatingUnlocking(Stage stage, string TrueOrFalse)
        {
            string[] ExplainUnlock = File.ReadAllLines(@"DebateGame\stages\explainunlock.txt");
            string[] InterpationsUnlock = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");

            if (TrueOrFalse.ToUpper() == "TRUE")
            {
                stage.Unlockable = true;
                ExplainUnlock[stage.Position - 1] = "True";
                InterpationsUnlock[stage.Position - 1] = "True";
            }
            else if (TrueOrFalse.ToUpper() == "FALSE")
            {
                stage.Unlockable = false;
                ExplainUnlock[stage.Position - 1] = "False";
                InterpationsUnlock[stage.Position - 1] = "False";
            }

            File.Delete(@"DebateGame\stages\explainunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\explainunlock.txt", ExplainUnlock);

            File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlock);

            return stage;
        }

        #endregion

        #region Tip

        public void Tip(Player player, List<Stage> stages)
        {
            int count = 0;
            bool firstStages = true;
            bool secondStages = true;
            bool isScienceWonEnough = true;

            foreach (Stage stageE in stages)
            {
                if(stageE.Won)
                {
                    count++;
                }
                if(stageE.Won && stageE.Diffculty > 2)
                {
                    secondStages = false;
                }
                if(stageE.Won && stageE.Diffculty > 1)
                {
                    firstStages = false;
                }
                if(!stageE.Won && stageE.Diffculty <= 2)
                {
                    secondStages = false;
                }
                if(!stageE.Won && stageE.Diffculty == 1)
                {
                    firstStages = false;
                }
                if (stageE.Name == "Video Games and violence" || stageE.Name == "Lies"
                || stageE.Name == "Homeopathy" || stageE.Name == "Intelligence"
                || stageE.Name == "Happiness and suffering")
                {
                    if (!stageE.Won)
                    {
                        isScienceWonEnough = false;
                    }
                }
            }
            if(count == 1)
            {
                PrintFile(@"DebateGame\Tips\TIP7.txt", @"DebateGame\Tips\TIP7DONE.txt");
            }
            if (secondStages)
            {
                PrintFile(@"DebateGame\Tips\TIP3.txt", @"DebateGame\Tips\TIP3DONE.txt");
            }
            if(player.HighExplanationRank >= 6)
            {
                PrintFile(@"DebateGame\Tips\TIP4.txt", @"DebateGame\Tips\TIP4DONE.txt");
            }
            if(count == stages.Count)
            {
                PrintFile(@"DebateGame\Tips\TIP6.txt", @"DebateGame\Tips\TIP6DONE.txt");
            }
            if(firstStages)
            {
                PrintFile(@"DebateGame\Tips\TIP13.txt", @"DebateGame\Tips\TIP13DONE.txt");
            }
            if(player.ExplainGameNegativePoints[5] + player.HardcoreGameNegativePoints[5] > 2)
            {
                PrintFile(@"DebateGame\Tips\TIP16.txt", @"DebateGame\Tips\TIP16DONE.txt");
            }
            if(isScienceWonEnough)
            {
                PrintFile(@"DebateGame\Tips\TIP19.txt", @"DebateGame\Tips\TIP19DONE.txt");
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

        #region comment

        void CommentWriting(XElement comment)
        {
            if (comment.Value != "No")
            {
                Console.WriteLine();
                Console.WriteLine("Author's comment:");
                Console.WriteLine();
                WritingText(comment.Value);
                Console.WriteLine();
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
