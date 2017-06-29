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

namespace ConsoleApplication9
{
   
    public class Program
    {
        #region all the stuff the main part needs

        #region Check the rank
        public static bool WithRank(Stage stage, double playerRank, double stageRank)
        {
            if (!(playerRank >= stageRank))
            {
                return true;
            }
            return false;
        }

        #endregion

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
            MindBody.DataBase = XDocument.Load(@"DebateGame\normalGame\level 2\mind body\mindbody.xml");
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
            Homeopathy.HardcoreRankCondition = 2.25;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "H");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 2\Intelligence\IntelligenceHardcore.xml");
            Intelligence.HardcoreRankCondition = 2.25;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "H");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 2\mind body\mindbody.xml");
            MindBody.HardcoreRankCondition = 2.25;
            stages.Add(MindBody);

            Stage freedom = new Stage("Freedom", 3, 7, "H");
            freedom.KeyForLevel = ConsoleKey.F;
            freedom.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\Freedom\FreedomHardcore.xml");
            freedom.HardcoreRankCondition = 7.25;
            stages.Add(freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "H");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\HowHappy\HowHappyHardcore.xml");
            HowHappy.HardcoreRankCondition = 7.25;
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "H");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 4\Reason\ReasonHardcore.xml");
            Reason.HardcoreRankCondition = 11.9;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "H");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 4\Free will\FreeWillHardcore.xml");
            Freewill.HardcoreRankCondition = 11.9;
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
            Homeopathy.ExplainRankCondition = 2;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "E");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 2\Intelligence\Intelligence.xml");
            Intelligence.ExplainRankCondition = 1;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "E");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 2\mind body\mindbody.xml");
            MindBody.ExplainRankCondition = 1;
            stages.Add(MindBody);

            Stage Freedom = new Stage("Freedom", 3, 7, "E");
            Freedom.KeyForLevel = ConsoleKey.F;
            Freedom.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\Freedom\Freedom.xml");
            Freedom.ExplainRankCondition = 4.25;
            stages.Add(Freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "E");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\HowHappy\HowHappy.xml");
            HowHappy.ExplainRankCondition = 4.25;
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "E");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 4\Reason\Reason.xml");
            Reason.ExplainRankCondition = 7.5;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "E");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 4\FreeWill\FreeWill.xml");
            Freewill.ExplainRankCondition = 7.5;
            stages.Add(Freewill);

            return stages;
        }

        #endregion

        #region Handling interaption level's special case

        #endregion

        #region Interaptions game levels add
        public static List<Stage> InteraptionsForLevels()
        {
            List<Stage> stages = new List<Stage>();

            Stage God = new Stage("God", 1, 1, "I");
            God.KeyForLevel = ConsoleKey.G;
            God.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 1\god\GodInteraptions.xml");
            stages.Add(God);

            Stage Violence = new Stage("Video Games and violence", 1, 2, "I");
            Violence.KeyForLevel = ConsoleKey.V;
            Violence.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 1\Violence\ViolenceInteraptions.xml");
            stages.Add(Violence);

            Stage Lies = new Stage("Lies", 1, 3, "I");
            Lies.KeyForLevel = ConsoleKey.L;
            Lies.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 1\Lies\LiesInteraptions.xml");
            stages.Add(Lies);

            Stage Homeopathy = new Stage("Homeopathy", 2, 4, "I");
            Homeopathy.KeyForLevel = ConsoleKey.H;
            Homeopathy.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 2\Homeopathy\HomeopathyInteraptions.xml");
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "I");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 2\Intelligence\IntelligenceInteraptions.xml");
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "I");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 2\Mind Body\mindbody.xml");
            stages.Add(MindBody);

            Stage freedom = new Stage("Freedom", 3, 7, "I");
            freedom.KeyForLevel = ConsoleKey.F;
            freedom.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 3\Freedom\FreeedomInterpations.xml");
            stages.Add(freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "I");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 3\HowHappy\HowHappyInteraptions.xml");
            stages.Add(HowHappy);

            Stage Reason = new Stage("Reason", 4, 9, "I");
            Reason.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 4\Reason\ReasonInterpations.xml");
            Reason.KeyForLevel = ConsoleKey.R;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 10, "I");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 4\Free will\FreeWillInteraptions.xml");
            stages.Add(Freewill);

            return stages;
        }
        #endregion

        #region writing game levels (based on diffculty and unlocking)
        public static void ChooseGame(List<Stage> lvl, Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions)
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
                if ((stage.mode.ToUpper() == "H"))
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
                    if (!stage.Won)
                    {
                        stage.Locked = false;
                    }
                    else
                    {
                        stage.Locked = true;
                    }
                bool completeNormal = true;
                if (relevant == "explanation game mode" || relevant == "hardcore game mode")
                {
                    foreach (Stage normalStage in NormalLevels)
                    {
                        if (stage.Name == normalStage.Name)
                        {
                            if (!normalStage.Won)
                            {
                                stage.Locked = true;
                                completeNormal = false;
                                if (stage.mode.ToUpper() == "E")
                                {
                                    string[] explains = File.ReadAllLines($@"DebateGame\stages\explainunlock.txt");
                                    explains[stage.Position - 1] = "False";
                                    File.Delete($@"DebateGame\stages\explainunlock.txt");
                                    File.WriteAllLines($@"DebateGame\stages\explainunlock.txt", explains);
                                    stage.unlockable = false;
                                }
                                if (stage.mode.ToUpper() == "H")
                                {
                                    string[] hardcores = File.ReadAllLines($@"DebateGame\stages\hardcoreunlock.txt");
                                    hardcores[stage.Position - 1] = "False";
                                    File.Delete($@"DebateGame\stages\hardcoreunlock.txt");
                                    File.WriteAllLines($@"DebateGame\stages\hardcoreunlock.txt", hardcores);
                                    stage.unlockable = false;
                                }
                            }
                        }
                    }
                }
                bool WonEverything = true;
                Stage interForOthers = new Stage("", 0, 0, "A");
                foreach(Stage inter in Interaptions)
                {
                    if (stage.Name == inter.Name)
                    {
                        interForOthers = new Stage(inter.Name, inter.diffculty, inter.Position, "I");
                    }
                }
                
                    bool checkExplain = false;
                    bool checkHardcore = false;
                    bool EndOfExplain = false;
                    bool EndOfHardcore = false;
                    string[] InterpationsUnlocked = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                if ((stage.mode.ToUpper() == "I"))
                {
                    stage.unlockable = bool.Parse(InterpationsUnlocked[stage.Position - 1]);
                    relevant = "Interaptions";
                }
                else
                {
                    interForOthers.unlockable = bool.Parse(InterpationsUnlocked[interForOthers.Position - 1]);
                }
                    List<List<Stage>> allLevels = new List<List<Stage>>();
                    allLevels.Add(ExplainLevels);
                    allLevels.Add(HardcoreLevels);
                    foreach (List<Stage> anyStage in allLevels)
                    {
                        foreach (Stage checkedStage in anyStage)
                        {
                            if (checkedStage.Name == stage.Name)
                            {
                                if (!checkedStage.Won)
                                {
                                    WonEverything = false;
                                    if ((stage.mode.ToUpper() == "I"))
                                    {
                                    stage.Locked = true;
                                    stage.unlockable = false;
                                    }
                                    else if (interForOthers.mode.ToUpper() == "I")
                                    {
                                    interForOthers.Locked = true;
                                    interForOthers.unlockable = false;
                                    }
                                InterpationsUnlocked[stage.Position - 1] = "False";
                                    File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                                    File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlocked);

                                }
                                if (checkedStage.Won && checkedStage.Locked)
                                {
                                    if (checkedStage.mode == "E")
                                    {
                                        string[] explains = File.ReadAllLines($@"DebateGame\stages\explainunlock.txt");
                                        checkedStage.unlockable = bool.Parse(explains[checkedStage.Position - 1]);

                                        if (checkedStage.unlockable)
                                        {
                                            checkExplain = true;
                                        }

                                    }
                                    if (checkedStage.mode == "H")
                                    {
                                        string[] hardcores = File.ReadAllLines($@"DebateGame\stages\hardcoreunlock.txt");
                                        checkedStage.unlockable = bool.Parse(hardcores[stage.Position - 1]);
                                        if (checkedStage.unlockable)
                                        {
                                            checkHardcore = true;
                                        }
                                    }

                                }
                            }
                        }
                    }

                    if (checkExplain && checkHardcore)
                    {
                    if ((stage.mode.ToUpper() == "I"))
                    {
                        stage.Locked = true;
                        stage.unlockable = true;
                    }
                    else if(interForOthers.mode.ToUpper() == "I")
                    {
                        interForOthers.Locked = true;
                        interForOthers.unlockable = true;
                    }
                        string[] interpations = File.ReadAllLines($@"DebateGame\stages\interaptionsunlock.txt");
                        interpations[stage.Position - 1] = "True";
                        File.Delete($@"DebateGame\stages\interaptionsunlock.txt");
                        File.WriteAllLines($@"DebateGame\stages\interaptionsunlock.txt", interpations);
                    }
                    else
                    {
                    if ((stage.mode.ToUpper() == "I"))
                    {
                        stage.unlockable = false;
                        InterpationsUnlocked[stage.Position - 1] = "False";
                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlocked);
                        stage.Locked = true;
                        if (!checkExplain && !checkHardcore && WonEverything)
                        {
                            stage.Locked = false;
                        }
                    }
                    else
                    {
                        interForOthers.unlockable = false;
                        InterpationsUnlocked[stage.Position - 1] = "False";
                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlocked);
                        interForOthers.Locked = true;
                        if (!checkExplain && !checkHardcore && WonEverything)
                        {
                            interForOthers.Locked = false;
                        }
                    }
                    }
                if (stage.mode.ToUpper() == "I")
                {
                    if (!WonEverything && !stage.unlockable)
                    {
                        stage.Locked = true;
                        Console.WriteLine($"{stage.Name} (Locked)");
                        Console.WriteLine("You need to beat this level in normal, explain and hardcore modes to be able to unlock this level");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                else
                {
                    if (!WonEverything && !interForOthers.unlockable)
                    {
                        interForOthers.Locked = true;
                    }
                }
                if (stage.mode.ToUpper() == "I")
                {
                    if (stage.unlockable)
                    {
                        stage.Locked = true;
                        Console.WriteLine(stage.Name + " (Locked) " + " (You haven't choosen to unlock this level yet)");
                        Console.WriteLine();
                        Console.WriteLine("(press " + stage.KeyForLevel.ToString() + " to unlock this level)");
                        Console.WriteLine();
                        Console.WriteLine();
                        
                    }
                    if (!stage.unlockable && WonEverything)
                    {
                        stage.Locked = false;
                        Console.WriteLine(stage.Name + " (Unlocked) " + "(press " + stage.KeyForLevel.ToString() + " to enter this level)");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                else
                {
                    if(interForOthers.unlockable)
                    {
                        interForOthers.Locked = true;
                    }
                    if(!interForOthers.unlockable && WonEverything)
                    {
                        interForOthers.Locked = false;
                    }
                }

                if(stage.mode.ToUpper() != "I")
                {
                    if (WithRank(stage, playerRank, stageRank))
                    {
                        stage.Locked = true;
                        stage.Won = false;
                        stage.unlockable = false;
                        switch(stage.mode)
                        {
                            case "E":
                                string[] explains = File.ReadAllLines($@"DebateGame\stages\explainunlock.txt");
                                explains[stage.Position - 1] = "False";
                                File.Delete($@"DebateGame\stages\explainunlock.txt");
                                File.WriteAllLines($@"DebateGame\stages\explainunlock.txt", explains);
                                break;
                            case "H":
                                string[] hardcores = File.ReadAllLines($@"DebateGame\stages\hardcoreunlock.txt");
                                hardcores[stage.Position - 1] = "False";
                                File.Delete($@"DebateGame\stages\hardcoreunlock.txt");
                                File.WriteAllLines($@"DebateGame\stages\hardcoreunlock.txt", hardcores);
                                break;
                        }
                    }
                }

                if (stage.Locked && stage.mode.ToUpper() != "I")
                {
                    if (stage.mode.ToUpper() != "G")
                    {
                        
                        if (!stage.Won && completeNormal)
                        {
                            Console.WriteLine($"{stage.Name} (Locked)");
                            Console.WriteLine($"(You need to be ranked at least {stageRank} in {relevant} to enter this level,");
                            Console.WriteLine();
                            Console.WriteLine($"While the highest ranking you ever reached in {relevant} is only {playerRank})");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        if (!stage.Won && !completeNormal)
                        {
                            Console.WriteLine($"{stage.Name} (Locked)");
                            Console.WriteLine("You need to beat this level in normal game mode before playing it here!");
                        }
                        if (stage.Won && completeNormal)
                        {
                                    if (interForOthers.Locked)
                                    {
                                        Console.WriteLine(stage.Name + " (Locked) " + " (You've already beaten this level at this mode)");
                                        Console.WriteLine();
                                        Console.WriteLine("(press " + stage.KeyForLevel.ToString() + " to remove all positive/negative points you gained from this level,");
                                        Console.WriteLine("and re-unlock it");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine(stage.Name + " (Locked) ");
                                        Console.WriteLine("You've unlocked this stage's interaptions");
                                        Console.WriteLine("Therfore, you cannot play this level again,");
                                        Console.WriteLine("Unless you reset your player status");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                    }       
                        }
                    }
                    else
                    {
                        Console.WriteLine(stage.Name + " (Locked) " + " (You've already beaten this level at this mode)");
                        Console.WriteLine();
                        Console.WriteLine("DO NOT TRY TO RE-UNLOCK IT!!! I WILL EXPLODE!!!!!11111");
                        Console.WriteLine("[Well other than by reseting your player status, of course]");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                else if(stage.mode.ToUpper() != "I")
                {
                    Console.WriteLine(stage.Name + " (Unlocked) " + "(press " + stage.KeyForLevel.ToString() + " to enter this level)");
                    Console.WriteLine();
                }
            }
        }

        #endregion

        #region Unlock an interaption stage

        public static void InterpationUnlock()
        {
            Console.WriteLine();
            Console.WriteLine("Congrats for unlocking the interpations of this stage O_o");
            Console.WriteLine();
            Console.WriteLine("Now this stage in normal, explain and hardcore modes will stay locked,");
            Console.WriteLine("Until you reset your player status, that is");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.WriteLine();
            Console.ReadLine();
        }

        #endregion

        #region ExplainAndHardcoreLocked

        public static void AllLocked()
        {
            Console.WriteLine();
            Console.WriteLine("You have unlocked the interaptions of this stage,");
            Console.WriteLine("Which you means, you can never play it again at any mode,");
            Console.WriteLine("Unless you reset your player status, that is");
            Console.WriteLine(" [MUHAHAHAHAHA!!] ");
            Console.WriteLine("Press any key to continue.");
            Console.WriteLine();
            Console.ReadLine();
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

        #region choosing a level and playing it
        public static void levelchoose(Game NewGame, Player player1, List<Stage> Levels, string firstInput, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, string mode)
        {
            // Dictionary<ConsoleKeyInfo, ConsoleKey> aa = new Dictionary<ConsoleKeyInfo, ConsoleKey>();            
            List<Stage> lvlStages = new List<Stage>();
            switch (firstInput)
            {
                case "1":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.diffculty == 1)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                case "2":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.diffculty == 2)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }

                    break;
                case "3":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.diffculty == 3)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                case "4":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.diffculty == 4)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                case "5":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.diffculty == 5)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("enter a number between 1-5 only");
                    string input = Console.ReadLine();
                    Quit(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, input);
                    Return(NewGame, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, input);
                    levelchoose(NewGame, player1, Levels, input, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                    break;
            }
                Console.Clear();
                ChooseGame(lvlStages, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
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
                                foreach (var point in player1.normalGamePositivePoints)
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
                            if (mode == "HardcoreGame")
                            {
                                if (player1.highHardcoreRank == 0)
                                {
                                    Console.Clear();
                                    WritingText(@"DebateGame\hardcoreGame\bestintro.txt");
                                    Console.ReadLine();
                                }

                                List<int> PreviousPositive = new List<int>();
                                foreach (int cell in player1.hardcoreGamePositivePoints)
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
                             string[] AreUnlockForE = File.ReadAllLines(@"DebateGame\stages\explainunlock.txt");
                             stage.unlockable = bool.Parse(AreUnlockForE[stage.Position - 1]);
                             if(stage.unlockable)
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

                                foreach(Stage InteraptioForE in Interaptions)
                                {
                                    if(InteraptioForE.Name == stage.Name)
                                    {
                                        InteraptioForE.unlockable = false;
                                        string[] AreUnlockForI = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                                        AreUnlockForI[stage.Position - 1] = "False";
                                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", AreUnlockForI);
                                    }
                                }

                                stage.Won = false;
                                stage.Locked = false;
                                stage.unlockable = false;
                                AreUnlockForE[stage.Position - 1] = "False";
                                File.Delete(@"DebateGame\stages\explainunlock.txt");
                                File.WriteAllLines(@"DebateGame\stages\explainunlock.txt", AreUnlockForE);
                                Reunlocking();
                            }
                            else
                            {
                                AllLocked();
                            }
                            levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                        }
                        if (mode == "HardcoreGame")
                        {
                            string[] AreUnlockForH = File.ReadAllLines(@"DebateGame\stages\hardcoreunlock.txt");
                            stage.unlockable = bool.Parse(AreUnlockForH[stage.Position - 1]);
                            if (stage.unlockable)
                            {
                                for (int i = 0; i < player1.hardcoreGamePositivePoints.Count(); i++)
                                {
                                    int positivePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"));
                                    player1.hardcoreGamePositivePoints[i] = player1.hardcoreGamePositivePoints[i] - positivePoint;
                                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), "0");
                                    int negativePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"));
                                    player1.hardcoreGameNegativePoints[i] = player1.hardcoreGameNegativePoints[i] - negativePoint;
                                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), "0");
                                }
                                foreach (Stage InteraptioForH in Interaptions)
                                {
                                    if (InteraptioForH.Name == stage.Name)
                                    {
                                        InteraptioForH.unlockable = false;
                                        string[] AreUnlockForI = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                                        AreUnlockForI[stage.Position - 1] = "False";
                                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", AreUnlockForI);
                                    }
                                }
                                stage.unlockable = false;
                                AreUnlockForH[stage.Position - 1] = "False";
                                File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
                                File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", AreUnlockForH);
                                stage.Won = false;
                                stage.Locked = false;
                                Reunlocking();
                            }
                            else
                            {
                                AllLocked();
                            }
                            levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                        }
                        if (mode == "NormalGame")
                        {
                            Console.WriteLine();
                            Console.WriteLine("You can't remove your wins at this mode!");
                            Console.WriteLine("Don't try this shit again, or else.. or else.. nothing.");
                            Console.WriteLine("Anyway, press any key and after that, choose a level again..");
                            Console.ReadLine();
                            levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                        }
                    }
                    else if(!stage.Won && stage.Locked && mode != "Interaptions")
                    {
                        Console.WriteLine();
                        Console.WriteLine("You can't enter this!");
                        Console.WriteLine("Don't try this shit again, or else.. or else.. nothing.");
                        Console.WriteLine("Anyway, press any key and after that, choose a level again..");
                        Console.ReadLine();
                        levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                    }
                else if (!stage.Won && stage.Locked && mode == "Interaptions")
                {
                    string[] unlockForI = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                    stage.unlockable = bool.Parse(unlockForI[stage.Position - 1]);
                    if(stage.unlockable)
                    {
                        string[] unlockForE = File.ReadAllLines(@"DebateGame\stages\explainunlock.txt");
                        unlockForE[stage.Position - 1] = "False";
                        File.Delete(@"DebateGame\stages\explainunlock.txt");
                        File.WriteAllLines(@"DebateGame\stages\explainunlock.txt", unlockForE);

                        string[] unlockForH = File.ReadAllLines(@"DebateGame\stages\hardcoreunlock.txt");
                        unlockForH[stage.Position - 1] = "False";
                        File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
                        File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", unlockForH);

                        unlockForI[stage.Position - 1] = "False";
                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", unlockForI);

                        stage.Locked = false;
                        stage.unlockable = false;
                        InterpationUnlock();
                        levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You haven't unlocked the option to unlock this.");
                        Console.WriteLine("This is becuse you don't have this stage won at explain and hardcore modes");
                        Console.WriteLine("Press any key to continue");
                        Console.WriteLine();
                        Console.ReadLine();
                        levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
                    }
                }
                }
            }
        levelchoose(NewGame, player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);
    }

    #endregion

    #region the main meun (and calling the functions for its mods)
    public static void MainMeun(Game NewGame, Player player1, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions)
    {
        Console.Clear();
        NewGame.position = PlayerPosition.MainMeun.ToString();
        Console.WriteLine();
        #region The finishing game messages and times
        bool unlocking = true;
        bool complete = true;

        List<List<Stage>> check = new List<List<Stage>>();
        check.Add(NormalLevels);
        check.Add(HardcoreLevels);
        check.Add(ExplainLevels);
        foreach (List<Stage> levels in check)
        {
            foreach (Stage stage in levels)
            {
                if (!stage.Won)
                {
                    complete = false;
                }
            }
        }

            unlocking = (player1.highExplanationRank >= 7.5 && player1.highHardcoreRank >= 11.9);

        if ((unlocking) &&
            (!(File.Exists(@"DebateGame\Messages\unlock.txt"))))
        {
            Console.WriteLine("Congrats! You've rankings are high enough to unlock all levels!");
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
                if (File.Exists(@"DebateGame\Messages\unlock.txt"))
                {
                    File.Delete(@"DebateGame\Messages\unlock.txt");
                }
                for(int i = 1; i < 20; i++)
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
                for (int i = 0; i < 6; i++)
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
                        if((stage.NormalRankCondition > 0) || (stage.ExplainRankCondition > 0) || (stage.HardcoreRankCondition > 0))
                        {
                            stage.Won = false;
                        }
                    }
                }
         
            for (int i = 0; i < 6; i++)
            {
                foreach (Stage stage in HardcoreLevels)
                {
                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), "0");
                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), "0");
                    stage.Won = false;
                    stage.unlockable = false;
                }
                foreach (Stage stage in ExplainLevels)
                {
                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), "0");
                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), "0");
                    stage.Won = false;
                    stage.unlockable = false;
                }
                foreach(Stage stage in NormalLevels)
                {
                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt"), "0");
                    File.WriteAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt"), "0");
                    stage.Won = false;
                    stage.unlockable = false;
                }
            }
                WritingStages(NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
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
                WritingStages(NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
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

        public static void WritingStages(List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> InterpationsRightNow)
        {
            string[] normal = new string[NormalLevels.Count()];
            for (int i = 0; i < NormalLevels.Count; i++)
            {
                normal[i] = NormalLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\normal\normal{i}.txt", normal[i]);
            }

            string[] explain = new string[ExplainLevels.Count()];
            string[] isExplainUnlock = new string[ExplainLevels.Count()];
            for (int i = 0; i < ExplainLevels.Count; i++)
            {
                explain[i] = ExplainLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\explain\explain{i}.txt", explain[i]);
                isExplainUnlock[i] = ExplainLevels[i].unlockable.ToString();
            }
            File.Delete(@"DebateGame\stages\explainunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\explainunlock.txt", isExplainUnlock);

            string[] hardcore = new string[HardcoreLevels.Count()];
            string[] isHardcoreUnlock = new string[HardcoreLevels.Count()];
            for (int i = 0; i < HardcoreLevels.Count; i++)
            {
                hardcore[i] = HardcoreLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\hardcore\hardcore{i}.txt", hardcore[i]);
                isHardcoreUnlock[i] = HardcoreLevels[i].unlockable.ToString();
            }
            File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", isHardcoreUnlock);

            string[] IsInteraptionUnlock = new string[InterpationsRightNow.Count()];
            for(int i = 0; i < InterpationsRightNow.Count(); i++)
            {
                IsInteraptionUnlock[i] = InterpationsRightNow[i].unlockable.ToString();
            }
            File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", IsInteraptionUnlock);
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