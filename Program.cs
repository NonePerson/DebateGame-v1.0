using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Input;

namespace ConsoleApplication9
{
   
    public class Program
    {
        #region all the stuff the main part needs
              
        #region intializing the normal games
        public static List<Stage> NormalGames()
        {
            List<Stage> stages = new List<Stage>();
            /*Stage easiest = new Stage("easiest", 1);
            easiest.KeyForLevel = ConsoleKey.E;
            easiest.DataBase = XDocument.Load(@"DebateGame\normalGame\level 1\easiest\TestStage.xml");
            stages.Add(easiest);
            */
            Stage God = new Stage("God", 1, 1, "G");
            God.KeyForLevel = ConsoleKey.G;
            God.DataBase = XDocument.Load(@"DebateGame\normalGame\level 1\god\God.xml");
            stages.Add(God);

            Stage Violence = new Stage("Video Games and violence", 1, 2, "G");
            Violence.KeyForLevel = ConsoleKey.V;
            Violence.DataBase = XDocument.Load(@"DebateGame\normalGame\level 1\video game violence\ViolenceNormal.xml");
            stages.Add(Violence);

            Stage Lies = new Stage("Lies", 1, 3, "G");
            Lies.KeyForLevel = ConsoleKey.L;
            Lies.DataBase = XDocument.Load(@"DebateGame\normalGame\level 1\Lies\Lies.xml");
            stages.Add(Lies);

            Stage Homeopathy = new Stage("Homeopathy", 2, 4, "G");
            Homeopathy.KeyForLevel = ConsoleKey.H;
            Homeopathy.DataBase = XDocument.Load(@"DebateGame\normalGame\level 2\Homeopathy\Homeopathy.xml");
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "G");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\normalGame\level 2\Intelligence\IntelligenceNormal.xml");
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "G");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"C:\Users\work\Desktop\DebateGameUpdated\bin\Debug\DebateGame\normalGame\level 2\mind body\mindbody.xml");
            stages.Add(MindBody);

            Stage Freedom = new Stage("Freedom", 3, 7, "G");
            Freedom.KeyForLevel = ConsoleKey.F;
            Freedom.DataBase = XDocument.Load(@"DebateGame\normalGame\level 3\Freedom\Freedom.xml");
            stages.Add(Freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "G");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\normalGame\level 3\How to be happy\HowHappy.xml");
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "G");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\normalGame\level 4\Reason\Reason.xml");
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "G");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\normalGame\level 4\Psychology of free will\FreeWill.xml");
            stages.Add(Freewill);

            return stages;
        }
        #endregion

        #region Hardcore game levels add
        public static List<Stage> HardcoreGames()
        {
            List<Stage> stages = new List<Stage>();

            Stage God = new Stage("God", 1, 1, "H");
            God.KeyForLevel = ConsoleKey.G;
            God.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 1\God\GodHardcore.xml");

            stages.Add(God);

            Stage Violence = new Stage("Video Games and violence", 1, 2, "H");
            Violence.KeyForLevel = ConsoleKey.V;
            Violence.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 1\Violence\ViolenceHardcore.xml");
            stages.Add(Violence);

            Stage Lies = new Stage("Lies", 1, 3, "H");
            Lies.KeyForLevel = ConsoleKey.L;
            Lies.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 1\Lies\LiesHardcore.xml");
            stages.Add(Lies);

            Stage Homeopathy = new Stage("Homeopathy", 2, 4, "H");
            Homeopathy.KeyForLevel = ConsoleKey.H;
            Homeopathy.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 2\Homeopathy\HomeopathyHardcore.xml");
            Homeopathy.HardcoreRankCondition = 1;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "H");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 2\Intelligence\IntelligenceHardcore.xml");
            Homeopathy.HardcoreRankCondition = 1.1;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind body problem", 2, 6, "H");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"C:\Users\work\Desktop\DebateGameUpdated\bin\Debug\DebateGame\hardcoreGame\level 2\mind body\mindbody.xml");
            MindBody.HardcoreRankCondition = 1.25;
            stages.Add(MindBody);

            Stage freedom = new Stage("Freedom", 3, 7, "H");
            freedom.KeyForLevel = ConsoleKey.F;
            freedom.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\Freedom\FreedomHardcore.xml");
            freedom.HardcoreRankCondition = 2.5;
            stages.Add(freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "H");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\HowHappy\HowHappyHardcore.xml");
            HowHappy.HardcoreRankCondition = 2.75;
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "H");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 4\Reason\ReasonHardcore.xml");
            Reason.HardcoreRankCondition = 4.5;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "H");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 4\Free will\FreeWillHardcore.xml");
            Freewill.HardcoreRankCondition = 4;
            stages.Add(Freewill);
            
            return stages;
        }

        #endregion

        #region adding explain game levels

        public static List<Stage> ExplanationGames()
        {
            List<Stage> stages = new List<Stage>();

            Stage God = new Stage("God", 1, 1, "E");
            God.KeyForLevel = ConsoleKey.G;
            God.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 1\God\GodExplain.xml");
            stages.Add(God);

            Stage Violence = new Stage("Video Games and violence", 1, 2, "E");
            Violence.KeyForLevel = ConsoleKey.V;
            Violence.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 1\Violence\Violence.xml");
            stages.Add(Violence);

            Stage Lies = new Stage("Lies", 1, 3, "E");
            Lies.KeyForLevel = ConsoleKey.L;
            Lies.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 1\Lies\Lies.xml");
            stages.Add(Lies);

            Stage Homeopathy = new Stage("Homeopathy", 2, 4, "E");
            Homeopathy.KeyForLevel = ConsoleKey.H;
            Homeopathy.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 2\Homeopathy\Homeopathy.xml");
            Homeopathy.ExplainRankCondition = 1;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "E");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 2\Intelligence\Intelligence.xml");
            Homeopathy.ExplainRankCondition = 1.2;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "E");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"C:\Users\work\Desktop\DebateGameUpdated\bin\Debug\DebateGame\ExplainGame\level 2\mind body\mindbody.xml");
            MindBody.ExplainRankCondition = 1.5;
            stages.Add(MindBody);

            Stage Freedom = new Stage("Freedom", 3, 7, "E");
            Freedom.KeyForLevel = ConsoleKey.F;
            Freedom.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\Freedom\Freedom.xml");
            Freedom.ExplainRankCondition = 3;
            stages.Add(Freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "E");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\HowHappy\HowHappy.xml");
            Freedom.ExplainRankCondition = 3.5;
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "E");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 4\Reason\Reason.xml");
            Reason.ExplainRankCondition = 5.5;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "E");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 4\FreeWill\FreeWill.xml");
            Reason.ExplainRankCondition = 6.15;
            stages.Add(Freewill);

            return stages;
        }

        #endregion

        #region Interaptions game levels add
        public static List<Stage> InteraptionsForLevels()
        {
            List<Stage> stages = new List<Stage>();

            Stage God = new Stage("God", 1, 1, "I");
            God.KeyForLevel = ConsoleKey.G;
            God.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 1\god\GodInteraptions.xml");
            God.HardcoreRankCondition = 10;
            stages.Add(God);

            Stage Violence = new Stage("Video Games and violence", 1, 2, "I");
            Violence.KeyForLevel = ConsoleKey.V;
            Violence.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 1\Violence\ViolenceInteraptions.xml");
            Violence.HardcoreRankCondition = 10;
            stages.Add(Violence);

            Stage Lies = new Stage("Lies", 1, 3, "I");
            Lies.KeyForLevel = ConsoleKey.L;
            Lies.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 1\Lies\LiesInteraptions.xml");
            Lies.HardcoreRankCondition = 10;
            stages.Add(Lies);

            Stage Homeopathy = new Stage("Homeopathy", 2, 4, "I");
            Homeopathy.KeyForLevel = ConsoleKey.H;
            Homeopathy.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 2\Homeopathy\HomeopathyInteraptions.xml");
            Homeopathy.HardcoreRankCondition = 20;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "I");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 2\Intelligence\IntelligenceInteraptions.xml");
            Intelligence.HardcoreRankCondition = 20;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "I");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"C:\Users\work\Desktop\DebateGameUpdated\bin\Debug\DebateGame\Interaptions\level 2\Mind Body\mindbody.xml");
            MindBody.HardcoreRankCondition = 20;
            stages.Add(MindBody);

            Stage freedom = new Stage("Freedom", 3, 7, "I");
            freedom.KeyForLevel = ConsoleKey.F;
            freedom.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 3\Freedom\FreeedomInterpations.xml");
            freedom.HardcoreRankCondition = 29;
            stages.Add(freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "I");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 3\HowHappy\HowHappyInteraptions.xml");
            HowHappy.HardcoreRankCondition = 29;
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "I");
            Reason.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 4\Reason\ReasonInterpations.xml");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.HardcoreRankCondition = 43;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "I");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 4\Free will\FreeWillInteraptions.xml");
            Freewill.HardcoreRankCondition = 43;
            stages.Add(Freewill);

            return stages;
        }
        #endregion

        #region writing game levels (based on diffculty and unlocking)
        public static void ChooseGame(List<Stage> lvl, Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of levels:");
            Console.WriteLine();
            foreach (Stage stage in lvl)
            {
                Console.WriteLine();
                double playerRank = 0;
                double stageRank = 0;
                string relevant = "";
                if((stage.mode.ToUpper() == "H"))
                {
                    stageRank = stage.HardcoreRankCondition;
                    playerRank = player.highHardcoreRank;
                    relevant = "hardcore game mode";
                }
                if ((stage.mode.ToUpper() == "E"))
                {
                    stageRank = stage.ExplainRankCondition;
                    playerRank = player.highExplanationRank;
                    relevant = "explanation game mode";
                }
                if ((stage.mode.ToUpper() == "G"))
                {
                    stageRank = stage.NormalRankCondition;
                    playerRank = player.highNormalRank;
                    relevant = "normal game mode";
                }
                if (!(playerRank >= stageRank))
                {
                    stage.Locked = true;
                }
                else
                {
                    if (!stage.Won)
                    {
                        stage.Locked = false;
                    }
                    else
                    {
                        stage.Locked = true;
                    }
                }
                bool completeNormal = true;
                if (relevant == "explanation game mode" || relevant == "hardcore game mode")
                {
                    foreach (Stage normalStage in NormalLevels)
                    {
                        if (stage.Name == normalStage.Name && stage.diffculty == normalStage.diffculty)
                        {
                            if(!normalStage.Won)
                            {
                                stage.Locked = true;
                                completeNormal = false;
                            }
                            
                        }
                    }
                }

                if ((stage.mode.ToUpper() == "I"))
                {
                    stage.Won = false;
                    stage.Locked = false;
                    relevant = "Interaptions";
                    List<List<Stage>> allLevels = new List<List<Stage>>();
                    allLevels.Add(NormalLevels);
                    allLevels.Add(ExplainLevels);
                    allLevels.Add(HardcoreLevels);
                    foreach(List<Stage> anyStage in allLevels)
                    {
                        foreach(Stage checkedStage in anyStage)
                        {
                            if(stage.diffculty == checkedStage.diffculty)
                            {
                                if(checkedStage.Name == stage.Name)
                                {
                                    if (!checkedStage.Won)
                                    {
                                        stage.Locked = true;
                                    }
                                }
                                
                            }
                        }
                    }
                }

                if (stage.Locked)
                {
                    if (stage.mode.ToUpper() == "I")
                    {
                        Console.WriteLine($"{stage.Name} (Locked)");
                        Console.WriteLine("You need to beat this level in normal, explain and hardcore modes to unlock this level");
                    }
                    else if (!stage.Won && completeNormal)
                    {
                        Console.WriteLine($"{stage.Name} (Locked)");
                        Console.WriteLine($"(You need to be ranked at least {stageRank} in {relevant} to enter this level,");
                        Console.WriteLine();
                        Console.WriteLine($"While the highest ranking you ever reached in {relevant} is only {playerRank})");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    else if(stage.Won && completeNormal)
                    {
                        Console.WriteLine(stage.Name + " (Locked) " + " (You've already beaten this level at this mode)");
                        Console.WriteLine();
                        Console.WriteLine("(press " + stage.KeyForLevel.ToString() + " to remove all positive/negative points you gained from this level,");
                        Console.WriteLine("and re-unlock it");
                        Console.WriteLine();
                    }
                    else if(!stage.Won && !completeNormal)
                    {
                        Console.WriteLine($"{stage.Name} (Locked)");
                        Console.WriteLine("You need to beat this level in normal game mode before playing it here!");
                    }
                }
                else
                {
                    Console.WriteLine(stage.Name + " (Unlocked) " + "(press " + stage.KeyForLevel.ToString() + " to enter this level)");
                    Console.WriteLine();
                }
            }
        }
        #endregion

        #region post-reunlocking a level

        public static void Reunlocking()
        {
            Console.WriteLine("The update is finished.");
            Console.WriteLine("Your highest ranking at the moment stays equal as before,");
            Console.WriteLine("But it will not increase any further until your currect ranking suppressed it.");
            Console.WriteLine();
            Console.WriteLine("Now, press any key, and then choose a level, maybe the level you just re-unlocked");
            Console.WriteLine();
            Console.ReadLine();
        }

        #endregion

        #region writing any text
        public static void WritingText(string path/*, FileMode filemode*/)
        {
            /*FileStream Write = new FileStream(path, filemode);*/
            string[] entireFile = File.ReadAllLines(path);
            foreach(string line in entireFile)
            {
                Console.WriteLine(line);
            }
        }
        #endregion

        #region return to main meun

        public static void MainMeunMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Press M to return to the main meun");
            Console.WriteLine();
        }
        public static void Return(Game NewGame, Player player1, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, string input)
        {
            if (input.ToUpper() == "M")
            {
                Console.Clear();
                NewGame.position = PlayerPosition.MainMeun.ToString();
                MainMeun(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
            }
        }
        #endregion

        #region enum for possible positions
        public enum PlayerPosition
        {

            MainMeun, // main meun
            Diffculty, // choosing diffculty level
            GameChoose, // Choosing a game to play/read
            MiddleGame, // being in the middle of a game
            GameOver, // being in a dead end
            GameWon, // winning a game
            Reading // reading something

        }
        #endregion

        #region viewing player status
        public static void ViewPlayerStatus(Player player)
        {
            Console.Clear();
            List<string> pointCategories = new List<string>();
            pointCategories = player.getPointCategories();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Normal Game points: ");
            Console.WriteLine();         
            for (int i = 0; i < pointCategories.Count; i++)
            {
                Console.Write(pointCategories[i]);
                Console.Write(player.normalGamePositivePoints[i]);
                Console.Write(" positive points, ");
                Console.Write(player.normalGameNegativePoints[i]);
                Console.Write(" negative points");
                Console.WriteLine();
                Console.WriteLine();        
            }
            Console.WriteLine($"Knowledge points: {player.knowledge}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Explanations game points: ");
            Console.WriteLine();
            for (int i = 0; i < pointCategories.Count; i++)
            {
                Console.Write(pointCategories[i]);
                Console.Write(player.ExplanationGamePositive[i]);
                Console.Write(" positive points, ");
                Console.Write(player.ExplanationGameNegative[i]);
                Console.Write(" negative points");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Hardcore Game points: ");
            Console.WriteLine();
            for (int i = 0; i < pointCategories.Count; i++)
            {
                Console.Write(pointCategories[i]);
                Console.Write(player.hardcoreGamePositivePoints[i]);
                Console.Write(" positive points, ");
                Console.Write(player.hardcoreGameNegativePoints[i]);
                Console.Write(" negative points");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Overall ranking for normal game mode: {player.RankingCalculation(player.normalGamePositivePoints, player.normalGameNegativePoints, player.knowledge)}");
            Console.WriteLine();
            Console.WriteLine($"Overall ranking for explanation game mode: {player.RankingCalculation(player.ExplanationGamePositive, player.ExplanationGameNegative, 0)}");
            Console.WriteLine();
            Console.WriteLine($"Overall ranking for hardcore game mode: {player.RankingCalculation(player.hardcoreGamePositivePoints, player.hardcoreGameNegativePoints, 0)}");
            Console.WriteLine();
            Console.WriteLine($"Higtest ranking acheived for normal game mode: {player.highNormalRank}");
            Console.WriteLine();
            Console.WriteLine($"Hightest ranking acheived for explanation game mode: {player.highExplanationRank}");
            Console.WriteLine();
            Console.WriteLine($"Hightest ranking acheived for hardcore game mode: {player.highHardcoreRank}");
            
        }

        #endregion

        #region old unused stuff (that should proably get removed)
        /*
        public static void TooString(IEnumerable<Stage> aa)
        {
            //             
            foreach (Stage ab in aa)
            {
                Console.WriteLine(ab.Name);
            }
        }
        
        public static List<Stage> UpdateList(List<Stage> lastList)
        {
            foreach (Stage stage in lastList)
            {
                if (!stage.IsPassed)
                {
                    if (!stage.IsAccesiable)
                    {
                        Console.WriteLine(stage.Name += " " + "(You can't enter this)");
                    }
                    else
                    {
                        Console.WriteLine(stage.Name);
                    }
                }
                else
                {
                    lastList.Remove(stage);
                }
            }
            return lastList;
        }
        
        public static void printResult(bool input)
        {
            if (input)
            {
                Console.WriteLine("good!");
            }
            else
            {
                Console.WriteLine("Fuck you!");
            }
        }
        */
        #endregion

        #region choosing a level and playing it
        public static void levelchoose(Game NewGame, Player player1, List<Stage> Levels, string firstInput, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, string mode)
        {
            // Dictionary<ConsoleKeyInfo, ConsoleKey> aa = new Dictionary<ConsoleKeyInfo, ConsoleKey>();            
            List<Stage> lvlStages = new List<Stage>();
            switch (firstInput)
            {
                case "1":
                    foreach (Stage stage in Levels)
                    {
                        if (stage.diffculty == 1)
                        {
                            lvlStages.Add(stage);
                        }
                    }
                    break;
                case "2":
                    foreach (Stage stage in Levels)
                    {
                        if (stage.diffculty == 2)
                        {
                            lvlStages.Add(stage);
                        }
                    }
                    break;
                case "3":
                    foreach (Stage stage in Levels)
                    {
                        if (stage.diffculty == 3)
                        {
                            lvlStages.Add(stage);
                        }
                    }
                    break;
                case "4":
                    foreach (Stage stage in Levels)
                    {
                        if (stage.diffculty == 4)
                        {
                            lvlStages.Add(stage);
                        }
                    }
                    break;
                case "5":
                    foreach (Stage stage in Levels)
                    {
                        if (stage.diffculty == 5)
                        {
                            lvlStages.Add(stage);
                        }
                    }
                    break;
            }
            Console.Clear();
            ChooseGame(lvlStages, player1, NormalLevels, HardcoreLevels, ExplainLevels);
            MainMeunMessage();
            QuitMessage();
            string mainInput = Console.ReadLine();
            Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
            Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
            foreach (Stage stage in lvlStages)
            {
                if (mainInput.ToUpper() == stage.KeyForLevel.ToString().ToUpper())
                {
                    if (!stage.Locked && !stage.Won)
                    {
                        if (mode == "NormalGame")
                        {
                            if (player1.highNormalRank == 0)
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\normalGame\intro.txt");
                                Console.ReadLine();
                            }
                            List<int> beforepositive = new List<int>();
                            List<int> befrenegative = new List<int>();
                            foreach(var point in player1.normalGamePositivePoints)
                            {
                                beforepositive.Add(point);
                            }
                            foreach (var point in player1.normalGameNegativePoints)
                            {
                                befrenegative.Add(point);
                            }
                            NormalGame normalGame = new NormalGame(stage, player1, NewGame);
                            normalGame.next(stage, player1, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, befrenegative);
                        }
                        if(mode == "HardcoreGame")
                        {
                            if (player1.highHardcoreRank == 0)
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\hardcoreGame\bestintro.txt");
                                Console.ReadLine();
                            }
                           
                            List<int> PreviousPositive = new List<int>();
                            foreach(int cell in player1.hardcoreGamePositivePoints)
                            {
                                PreviousPositive.Add(cell);
                            }
                            List<int> PreviousNegative = new List<int>();
                            foreach (int cell in player1.hardcoreGameNegativePoints)
                            {
                                PreviousNegative.Add(cell);
                            }
                            HardcoreGame hardcoregame = new HardcoreGame(stage, player1, NewGame);
                            hardcoregame.next(stage, player1, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);
                        }
                        if (mode == "ExplanationGame")
                        {
                            if (player1.highExplanationRank == 0)
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\ExplainGame\intro.txt");
                                Console.ReadLine();
                            }

                            List<int> PreviousPositive2 = new List<int>();
                            foreach (int cell in player1.ExplanationGamePositive)
                            {
                                PreviousPositive2.Add(cell);
                            }
                            List<int> PreviousNegative2 = new List<int>();
                            foreach (int cell in player1.ExplanationGameNegative)
                            {
                                PreviousNegative2.Add(cell);
                            }
                            ExplainGame explaingame = new ExplainGame(stage, player1, NewGame);
                            explaingame.next(stage, player1, NewGame, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);
                            // add the explain list to the above line
                        }
                        if (mode == "Interaptions")
                        {
                            // you can add a condition here that checks if the player already saw the intro text file
                            Console.Clear();
                            WritingText(@"DebateGame\Interaptions\intro.txt");
                            Console.ReadLine();
                            InterpationsScroll interaptionsScroll = new InterpationsScroll(stage, player1, NewGame);
                            interaptionsScroll.next(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
                        }
                    }
                    if ((stage.Locked) && (stage.Won))
                    {
                        if (mode == "ExplanationGame")
                        {
                            for (int i = 0; i < player1.ExplanationGamePositive.Count(); i++)
                            {
                                int positivePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"));
                                player1.ExplanationGamePositive[i] = player1.ExplanationGamePositive[i] - positivePoint;
                                File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), "0");
                                int negativePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"));
                                player1.ExplanationGameNegative[i] = player1.ExplanationGameNegative[i] - negativePoint;
                                File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), "0");
                                
                            }
                            stage.Won = false;
                            stage.Locked = false;
                            Reunlocking();
                            levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                        }
                        if (mode == "HardcoreGame")
                        {
                            for (int i = 0; i < player1.hardcoreGamePositivePoints.Count(); i++)
                            {
                                int positivePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"));
                                player1.hardcoreGamePositivePoints[i] = player1.hardcoreGamePositivePoints[i] - positivePoint;
                                File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), "0");
                                int negativePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"));
                                player1.hardcoreGamePositivePoints[i] = player1.hardcoreGameNegativePoints[i] - negativePoint;
                                File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), "0");
                            }
                            stage.Won = false;
                            stage.Locked = false;
                            Reunlocking();
                            levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                        }
                        if (mode == "NormalGame")
                        {
                            Console.WriteLine("You can't remove your wins at this mode!");
                            Console.WriteLine("Don't try this shit again, or else.. or else.. nothing.");
                            Console.WriteLine("Anyway, press any key and after that, choose a level again..");
                            Console.ReadLine();
                            levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You can't enter this!");
                        Console.WriteLine("Don't try this shit again, or else.. or else.. nothing.");
                        Console.WriteLine("Anyway, press any key and after that, choose a level again..");
                        Console.ReadLine();
                        levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                    }
                }
            }
            Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
        }
        #endregion

        #region the main meun (and calling the functions for its mods)
        public static void MainMeun(Game NewGame, Player player1, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions)
        {
            Console.Clear();
            NewGame.position = PlayerPosition.MainMeun.ToString();
            Console.WriteLine();
            #region The finishing game messages and times
            bool complete = true;
            if ((player1.highNormalRank >= 11.3) &&
                (player1.highHardcoreRank >= 17.15) &&
                (player1.highExplanationRank >= 18.05) &&
                (!(File.Exists(@"DebateGame\Messages\unlock.txt"))))
            {
                Console.WriteLine("Congrats! You've unlocked all levels!");
                Console.WriteLine();
                string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                int num2 = int.Parse(num);
                Console.WriteLine($"It took you {num2} attempts!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
                var unlockGame = File.Create(@"DebateGame\Messages\unlock.txt");
                unlockGame.Close();
            }
            List<List<Stage>> check = new List<List<Stage>>();
            check.Add(NormalLevels);
            check.Add(HardcoreLevels);
            check.Add(ExplainLevels);
            foreach(List<Stage> levels in check)
            {
                foreach(Stage stage in levels)
                {
                    if(!stage.Won)
                    {
                        complete = false;
                    }
                }
            }
            if ((complete) && ((!(File.Exists(@"DebateGame\Messages\complete.txt")))))
            {
                Console.WriteLine("Congrats! You've beaten all levels!");
                Console.WriteLine();
                string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                int num2 = int.Parse(num);                
                Console.WriteLine($"It took you {num2} attempts!");
                num2 = 0;
                File.WriteAllText(@"DebateGame\attempts\attempt.txt", (num2.ToString()));
                Console.WriteLine();
                Console.WriteLine("You finished with the following status:");
                Console.WriteLine();
                Console.WriteLine($"Normal game mode rank: {player1.RankingCalculation(player1.normalGamePositivePoints, player1.normalGameNegativePoints, player1.knowledge)}");
                Console.WriteLine();
                Console.WriteLine($"Explanation game mode rank: {player1.RankingCalculation(player1.ExplanationGamePositive, player1.ExplanationGameNegative, 0)}");
                Console.WriteLine();
                Console.WriteLine($"Hardcore game mode rank: {player1.RankingCalculation(player1.hardcoreGamePositivePoints, player1.hardcoreGameNegativePoints, 0)}");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
                var completeGame = File.Create(@"DebateGame\Messages\complete.txt");
                completeGame.Close();
            }

            #endregion
            WritingText(@"DebateGame\MainMeun.txt");
            string mainInput = Console.ReadLine();
            if (mainInput.ToUpper() == "G")
            {
                string mode = "NormalGame";
                Console.Clear();
                NewGame.position = PlayerPosition.Diffculty.ToString();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                QuitMessage();
                mainInput = Console.ReadLine();
                Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                levelchoose(NewGame, player1, NormalLevels, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
            }                                                                                                                     

            else if (mainInput.ToUpper() == "H")
            {
                string mode = "HardcoreGame";
                Console.Clear();
                NewGame.position = PlayerPosition.Diffculty.ToString();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                QuitMessage();
                mainInput = Console.ReadLine();
                Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                levelchoose(NewGame, player1, HardcoreLevels, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
            }
            else if (mainInput.ToUpper() == "E")
            {
                string mode = "ExplanationGame";
                Console.Clear();
                NewGame.position = PlayerPosition.Diffculty.ToString();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                QuitMessage();
                mainInput = Console.ReadLine();
                Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                levelchoose(NewGame, player1, ExplainLevels, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
            }

            else if (mainInput.ToUpper() == "I")
            {
                string mode = "Interaptions";
                Console.Clear();
                NewGame.position = PlayerPosition.Diffculty.ToString();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                QuitMessage();
                mainInput = Console.ReadLine();
                Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                levelchoose(NewGame, player1, Interaptions, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
            }

            else if (mainInput.ToUpper() == "V")
            {
                Console.Clear();
                NewGame.position = PlayerPosition.Reading.ToString();
                ViewPlayerStatus(player1);
                MainMeunMessage();
                QuitMessage();
                mainInput = Console.ReadLine();
                Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mainInput);
                Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
            }
            else if(mainInput.ToUpper() == "R")
            {
                /* counting the number of resets - 
                remember that the propeties addressed
                here will be the text files,
                and might reset autmatically (or by choice?) when the player
                wins in all levels
                */
                if (File.Exists(@"DebateGame\Messages\complete.txt"))
                {
                    File.Delete(@"DebateGame\Messages\complete.txt");
                }
                if (File.Exists(@"DebateGame\Messages\unlock.text"))
                {
                    File.Delete(@"DebateGame\Messages\unlock.text");
                }
                for(int i = 1; i < 6; i++)
                {
                    if(File.Exists($@"DebateGame\Tips\TIP{i}DONE.txt"))
                    {
                        File.Delete($@"DebateGame\Tips\TIP{i}DONE.txt");
                    }
                }
                string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                int num2 = int.Parse(num);
                num2 = num2 + 1;
                File.WriteAllText(@"DebateGame\attempts\attempt.txt", (num2.ToString()));
                for (int i = 0; i < player1.ExplanationGamePositive.Count(); i++)
                {
                    player1.normalGamePositivePoints[i] = 0;
                    player1.normalGameNegativePoints[i] = 0;
                    player1.ExplanationGamePositive[i] = 0;
                    player1.ExplanationGameNegative[i] = 0;
                    player1.hardcoreGamePositivePoints[i] = 0;
                    player1.hardcoreGameNegativePoints[i] = 0;
                }
                player1.knowledge = 0;
                player1.highNormalRank = 0;
                player1.highExplanationRank = 0;
                player1.highHardcoreRank = 0;
                WritingPlayer(player1);
                List<List<Stage>> dont = new List<List<Stage>>();
                dont.Add(NormalLevels);
                dont.Add(HardcoreLevels);
                dont.Add(ExplainLevels);
                foreach (List<Stage> levels in dont)
                {
                    foreach (Stage stage in levels)
                    {
                        if((stage.NormalRankCondition > 0) || (stage.ExplainRankCondition > 0))
                        {
                            for(int i = 0; i < 6; i++)
                            {

                            }
                        }
                        stage.Won = false;
                    }
                }
                WritingStages(NormalLevels, ExplainLevels, HardcoreLevels);
         
            for (int i = 0; i < 6; i++)
            {
                foreach (Stage stage in HardcoreLevels)
                {
                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), "0");
                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), "0");
                }
                foreach (Stage stage in ExplainLevels)
                {
                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), "0");
                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), "0");
                }
                foreach(Stage stage in NormalLevels)
                {
                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt"), "0");
                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt"), "0");
                }
            }
        
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Your player status had reseted.");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the main meun");
                Console.ReadLine();
                string[] args = new string[0];
                Main(args);
            }
            else if (mainInput.ToUpper() == "M")
            {
                Stage stage = new Stage("", 0, 1, "A");
                stage.DataBase = XDocument.Load(@"DebateGame\Manual.xml");
                NewGame.position = PlayerPosition.Reading.ToString();
                InterpationsScroll manual = new InterpationsScroll(stage, player1, NewGame);
                manual.next(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
            }
            else if (mainInput.ToUpper() == "T")
            {
                Stage stage = new Stage("", 0, 1, "A");
                stage.DataBase = XDocument.Load(@"DebateGame\Turtorial.xml");
                NewGame.position = PlayerPosition.Reading.ToString();
                InterpationsScroll turtorial = new InterpationsScroll(stage, player1, NewGame);
                turtorial.next(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
            }
            else if(mainInput.ToUpper() == "QUIT")
            {
                Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "QUIT");
            }

            else
            {
                Console.Clear();
                MainMeun(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
            }
        }
        #endregion

        #endregion

        #region console exit
        
        public static void Quit(Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, string input)
        {
            if (input.ToUpper() == "QUIT")
            {
                string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                File.WriteAllText(@"DebateGame\attempts\attempt.txt", (num.ToString()));
                WritingPlayer(player);
                WritingStages(NormalLevels, ExplainLevels, HardcoreLevels);
                Console.Clear();
                Console.WriteLine("Your advancement in the game has been saved");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        public static void QuitMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Input 'quit' to exit the game without losing your progres");
            Console.WriteLine();
        }

        public static void WritingPlayer(Player player)
        {
            string[] normalGamePositive = new string[player.normalGamePositivePoints.Count()];
            for (int i = 0; i < player.normalGamePositivePoints.Count(); i++)
            {
                normalGamePositive[i] = player.normalGamePositivePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\normalpositive\normalpositive{i}.txt", normalGamePositive[i]);
            }
            
            string[] normalGameNegative = new string[player.normalGameNegativePoints.Count()];
            for (int i = 0; i < player.normalGameNegativePoints.Count(); i++)
            {
                normalGameNegative[i] = player.normalGameNegativePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\normalnegative\normalnegative{i}.txt", normalGameNegative[i]);
            }

            string[] hardcoreGamePositive = new string[player.hardcoreGamePositivePoints.Count()];
            for (int i = 0; i < player.hardcoreGamePositivePoints.Count(); i++)
            {
                hardcoreGamePositive[i] = player.hardcoreGamePositivePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\hardcorepositive\hardcorepositive{i}.txt", hardcoreGamePositive[i]);
            }

            string[] hardcoreGameNegative = new string[player.hardcoreGameNegativePoints.Count()];
            for (int i = 0; i < player.hardcoreGameNegativePoints.Count(); i++)
            {
                hardcoreGameNegative[i] = player.hardcoreGameNegativePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\hardcorenegative\hardcorenegative{i}.txt", hardcoreGameNegative[i]);
            }

            string[] ExplainGamePositive = new string[player.ExplanationGamePositive.Count()];
            for (int i = 0; i < player.ExplanationGamePositive.Count(); i++)
            {
                ExplainGamePositive[i] = player.ExplanationGamePositive[i].ToString();
                File.WriteAllText($@"DebateGame\player\explainpositive\explainpositive{i}.txt", ExplainGamePositive[i]);
            }

            string[] ExplainGameNegative = new string[player.ExplanationGameNegative.Count()];
            for (int i = 0; i < player.ExplanationGameNegative.Count(); i++)
            {
                ExplainGameNegative[i] = player.ExplanationGameNegative[i].ToString();
                File.WriteAllText($@"DebateGame\player\explainnegative\explainnegative{i}.txt", ExplainGameNegative[i]);
            }

            string knowledge = player.knowledge.ToString();
            File.WriteAllText(@"DebateGame\player\knowledge.txt", knowledge);

            string highNormal = player.highNormalRank.ToString();
            File.WriteAllText(@"DebateGame\player\highnormal.txt", highNormal);

            string highHardcore = player.highHardcoreRank.ToString();
            File.WriteAllText(@"DebateGame\player\highhardcore.txt", highHardcore);

            string highExplain = player.highExplanationRank.ToString();
            File.WriteAllText(@"DebateGame\player\highexplain.txt", highExplain);
        }

        public static void WritingStages(List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels)
        {
            string[] normal = new string[NormalLevels.Count()];
            for(int i = 0; i < NormalLevels.Count; i++)
            {
                normal[i] = NormalLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\normal\normal{i}.txt", normal[i]);
            }
            

            string[] explain = new string[ExplainLevels.Count()];
            for (int i = 0; i < ExplainLevels.Count; i++)
            {
                explain[i] = ExplainLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\explain\explain{i}.txt", explain[i]);
            }
            

            string[] hardcore = new string[HardcoreLevels.Count()];
            for (int i = 0; i < HardcoreLevels.Count; i++)
            {
                hardcore[i] = HardcoreLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\hardcore\hardcore{i}.txt", hardcore[i]);
            }
            
        }

        #endregion

        #region the actual main of the program
        public static void Main(string[] args)
        {            
            /*explanations:
            1. when the player starts his 1st attempt,
            the datatime will enter a textfile
            2. you can add a time trial mode,
            which for it,
            the start datatime will be set when the player returns to the main meun
            and stop when the player reaches a certain point
            (you will a "time trial" property as well as properties
            for the player's best times, all archeived in text files)
            3. Otherwise, simply stop the datatime when the 
            player "finishes the game". You will stil need a property
            for his times in a text file
            
            string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
            if (int.Parse(num) == 1)
            {
                DateTime Start = DateTime.Now;
                File.WriteAllText(@"DebateGame\start.txt", Start.ToString());
            }

            if (int.Parse(num) == 1)
            {
                DateTime and = DateTime.Parse(File.ReadAllText(@"DebateGame\start.txt"));
                DateTime end = DateTime.Now;
                TimeSpan a = and - end;
                int miliseconds = a.Milliseconds * -1;
                int seconds = a.Seconds * -1;
                int minutes = a.Minutes * -1;
                int hours = a.Hours * -1;
                Console.WriteLine($"{hours}:{minutes}:{seconds}:{miliseconds}");
                Console.WriteLine();
            }
            */

            List<Stage> NormalLevels = new List<Stage>();
            List<Stage> HardcoreLevels = new List<Stage>();
            List<Stage> Interaptions = new List<Stage>();
            List<Stage> ExplainLevels = new List<Stage>();
            NormalLevels = NormalGames();
            HardcoreLevels = HardcoreGames();
            Interaptions = InteraptionsForLevels();
            ExplainLevels = ExplanationGames();
            Game NewGame = new Game();
            Player player1 = new Player();
            
            MainMeun(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
        }
        #endregion
    }
}