using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class Program
    {
        #region all the stuff the main part needs

        #region Normal game levels add
        private static List<Stage> NormalGames()
        {
            List<Stage> stages = new List<Stage>();
           
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

            Stage NLP = new Stage("NLP", 3, 9, "G");
            NLP.KeyForLevel = ConsoleKey.N;
            NLP.DataBase = XDocument.Load(@"DebateGame\normalGame\level 3\NLP\nlp.xml");
            stages.Add(NLP);

            Stage Reason = new Stage("Reason", 4, 10, "G");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\normalGame\level 4\Reason\Reason.xml");
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 11, "G");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\normalGame\level 4\Psychology of free will\FreeWill.xml");
            stages.Add(Freewill);

            return stages;
        }
        #endregion

        #region Hardcore game levels add
        private static List<Stage> HardcoreGames()
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
            Homeopathy.HardcoreRankCondition = 1.8;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "H");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 2\Intelligence\IntelligenceHardcore.xml");
            Intelligence.HardcoreRankCondition = 1.8;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "H");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 2\mind body\mindbody.xml");
            MindBody.HardcoreRankCondition = 1.8;
            stages.Add(MindBody);

            Stage freedom = new Stage("Freedom", 3, 7, "H");
            freedom.KeyForLevel = ConsoleKey.F;
            freedom.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\Freedom\FreedomHardcore.xml");
            freedom.HardcoreRankCondition = 4.8;
            stages.Add(freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "H");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\HowHappy\HowHappyHardcore.xml");
            HowHappy.HardcoreRankCondition = 4.8;
            stages.Add(HowHappy);

            Stage NLP = new Stage("NLP", 3, 9, "H");
            NLP.KeyForLevel = ConsoleKey.N;
            NLP.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 3\NLP\NLP.xml");
            stages.Add(NLP);

            Stage Reason = new Stage("Reason", 4, 10, "H");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 4\Reason\ReasonHardcore.xml");
            Reason.HardcoreRankCondition = 7.6;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 11, "H");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\hardcoreGame\level 4\Free will\FreeWillHardcore.xml");
            Freewill.HardcoreRankCondition = 7.6;
            stages.Add(Freewill);
            
            return stages;
        }

        #endregion

        #region Explain game levels add

        private static List<Stage> ExplanationGames()
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
            Homeopathy.ExplainRankCondition = 0.95;
            stages.Add(Homeopathy);

            Stage Intelligence = new Stage("Intelligence", 2, 5, "E");
            Intelligence.KeyForLevel = ConsoleKey.I;
            Intelligence.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 2\Intelligence\Intelligence.xml");
            Intelligence.ExplainRankCondition = 0.95;
            stages.Add(Intelligence);

            Stage MindBody = new Stage("The mind-body problem", 2, 6, "E");
            MindBody.KeyForLevel = ConsoleKey.T;
            MindBody.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 2\mind body\mindbody.xml");
            MindBody.ExplainRankCondition = 0.95;
            stages.Add(MindBody);

            Stage Freedom = new Stage("Freedom", 3, 7, "E");
            Freedom.KeyForLevel = ConsoleKey.F;
            Freedom.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\Freedom\Freedom.xml");
            Freedom.ExplainRankCondition = 3;
            stages.Add(Freedom);

            Stage HowHappy = new Stage("Happiness and suffering", 3, 8, "E");
            HowHappy.KeyForLevel = ConsoleKey.H;
            HowHappy.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\HowHappy\HowHappy.xml");
            HowHappy.ExplainRankCondition = 3;
            stages.Add(HowHappy);

            Stage NLP = new Stage("NLP", 3, 9, "E");
            NLP.KeyForLevel = ConsoleKey.N;
            NLP.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 3\NLP\nlp.xml");
            stages.Add(NLP);

            Stage Reason = new Stage("Reason", 4, 10, "E");
            Reason.KeyForLevel = ConsoleKey.R;
            Reason.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 4\Reason\Reason.xml");
            Reason.ExplainRankCondition = 5;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 11, "E");
            Freewill.KeyForLevel = ConsoleKey.P;
            Freewill.DataBase = XDocument.Load(@"DebateGame\ExplainGame\level 4\FreeWill\FreeWill.xml");
            Freewill.ExplainRankCondition = 5;
            stages.Add(Freewill);

            return stages;
        }

        #endregion

        #region Interaptions game levels add
        private static List<Stage> InteraptionsForLevels()
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

            Stage NLP = new Stage("NLP", 3, 9, "I");
            NLP.KeyForLevel = ConsoleKey.N;
            NLP.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 3\NLP\NLP.xml");
            stages.Add(NLP);

            Stage Reason = new Stage("Reason", 4, 10, "I");
            Reason.DataBase = XDocument.Load(@"DebateGame\Interaptions\level 4\Reason\ReasonInterpations.xml");
            Reason.KeyForLevel = ConsoleKey.R;
            stages.Add(Reason);

            Stage Freewill = new Stage("Psychology of free will", 4, 11, "I");
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
                if ((stage.Mode.ToUpper() == "H"))
                {
                    stageRank = stage.HardcoreRankCondition;
                    playerRank = player.HighHardcoreRank;
                    relevant = "hardcore game mode";
                }
                if ((stage.Mode.ToUpper() == "E"))
                {
                    stageRank = stage.ExplainRankCondition;
                    playerRank = player.HighExplanationRank;
                    relevant = "explanation game mode";
                }
                if ((stage.Mode.ToUpper() == "G"))
                {
                    stageRank = stage.NormalRankCondition;
                    playerRank = player.HighNormalRank;
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
                                if (stage.Mode.ToUpper() == "E")
                                {
                                    string[] explains = File.ReadAllLines($@"DebateGame\stages\explainunlock.txt");
                                    explains[stage.Position - 1] = "False";
                                    File.Delete($@"DebateGame\stages\explainunlock.txt");
                                    File.WriteAllLines($@"DebateGame\stages\explainunlock.txt", explains);
                                    stage.Unlockable = false;
                                }
                                if (stage.Mode.ToUpper() == "H")
                                {
                                    string[] hardcores = File.ReadAllLines($@"DebateGame\stages\hardcoreunlock.txt");
                                    hardcores[stage.Position - 1] = "False";
                                    File.Delete($@"DebateGame\stages\hardcoreunlock.txt");
                                    File.WriteAllLines($@"DebateGame\stages\hardcoreunlock.txt", hardcores);
                                    stage.Unlockable = false;
                                }
                            }
                        }
                    }
                }
                bool WonEverything = true;
                Stage interForOthers = new Stage("", 0, 0, "A");
                foreach (Stage inter in Interaptions)
                {
                    if (stage.Name == inter.Name)
                    {
                        interForOthers = new Stage(inter.Name, inter.Diffculty, inter.Position, "I");
                    }
                }

                bool checkExplain = false;
                bool checkHardcore = false;
                bool EndOfExplain = false;
                bool EndOfHardcore = false;
                string[] InterpationsUnlocked = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                if ((stage.Mode.ToUpper() == "I"))
                {
                    stage.Unlockable = bool.Parse(InterpationsUnlocked[stage.Position - 1]);
                    relevant = "Interaptions";
                }
                else
                {
                    interForOthers.Unlockable = bool.Parse(InterpationsUnlocked[interForOthers.Position - 1]);
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
                                if ((stage.Mode.ToUpper() == "I"))
                                {
                                    stage.Locked = true;
                                    stage.Unlockable = false;
                                }
                                else if (interForOthers.Mode.ToUpper() == "I")
                                {
                                    interForOthers.Locked = true;
                                    interForOthers.Unlockable = false;
                                }
                                InterpationsUnlocked[stage.Position - 1] = "False";
                                File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                                File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", InterpationsUnlocked);

                            }
                            if (checkedStage.Won && checkedStage.Locked)
                            {
                                if (checkedStage.Mode == "E")
                                {
                                    string[] explains = File.ReadAllLines($@"DebateGame\stages\explainunlock.txt");
                                    checkedStage.Unlockable = bool.Parse(explains[checkedStage.Position - 1]);

                                    if (checkedStage.Unlockable)
                                    {
                                        checkExplain = true;
                                    }

                                }
                                if (checkedStage.Mode == "H")
                                {
                                    string[] hardcores = File.ReadAllLines($@"DebateGame\stages\hardcoreunlock.txt");
                                    checkedStage.Unlockable = bool.Parse(hardcores[stage.Position - 1]);
                                    if (checkedStage.Unlockable)
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
                    if ((stage.Mode.ToUpper() == "I"))
                    {
                        stage.Locked = true;
                        stage.Unlockable = true;
                    }
                    else if (interForOthers.Mode.ToUpper() == "I")
                    {
                        interForOthers.Locked = true;
                        interForOthers.Unlockable = true;
                    }
                    string[] interpations = File.ReadAllLines($@"DebateGame\stages\interaptionsunlock.txt");
                    interpations[stage.Position - 1] = "True";
                    File.Delete($@"DebateGame\stages\interaptionsunlock.txt");
                    File.WriteAllLines($@"DebateGame\stages\interaptionsunlock.txt", interpations);
                }
                else
                {
                    if ((stage.Mode.ToUpper() == "I"))
                    {
                        stage.Unlockable = false;
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
                        interForOthers.Unlockable = false;
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
                if (stage.Mode.ToUpper() == "I")
                {
                    if (!WonEverything && !stage.Unlockable)
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
                    if (!WonEverything && !interForOthers.Unlockable)
                    {
                        interForOthers.Locked = true;
                    }
                }
                if (stage.Mode.ToUpper() == "I")
                {
                    if (stage.Unlockable)
                    {
                        stage.Locked = true;
                        Console.WriteLine(stage.Name + " (Locked) " + " (You haven't choosen to unlock this level yet)");
                        Console.WriteLine();
                        Console.WriteLine("(enter " + stage.KeyForLevel.ToString() + " to unlock this level)");
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    if (!stage.Unlockable && WonEverything)
                    {
                        stage.Locked = false;
                        Console.WriteLine(stage.Name + " (Unlocked) " + "(enter " + stage.KeyForLevel.ToString() + " to enter this level)");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                else
                {
                    if (interForOthers.Unlockable)
                    {
                        interForOthers.Locked = true;
                    }
                    if (!interForOthers.Unlockable && WonEverything)
                    {
                        interForOthers.Locked = false;
                    }
                }

                if (stage.Mode.ToUpper() != "I")
                {
                    if (!(playerRank >= stageRank))
                    {
                        stage.Locked = true;
                        stage.Won = false;
                        stage.Unlockable = false;
                        switch (stage.Mode)
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

                if (stage.Locked && stage.Mode.ToUpper() != "I")
                {
                    if (stage.Mode.ToUpper() != "G")
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
                                Console.WriteLine("(enter " + stage.KeyForLevel.ToString() + " to remove all positive/negative points you gained from this level,");
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
                else if (stage.Mode.ToUpper() != "I")
                {
                    Console.WriteLine(stage.Name + " (Unlocked) " + "(enter " + stage.KeyForLevel.ToString() + " to enter this level)");
                    Console.WriteLine();
                }
            }
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
            Console.WriteLine("Enter any key to continue.");
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
            Console.WriteLine("Now, enter any key, and then choose a level, maybe the level you just re-unlocked");
            Console.WriteLine();
            Console.ReadLine();
        }

        #endregion

        #region writing any text

        public static void WritingText(string path)
        {
            string[] entireFile = File.ReadAllLines(path);
            foreach(string line in entireFile)
            {
                Console.WriteLine(line);
            }
        }

        #endregion

        #region return to main meun

        public static bool ShouldIReturnToMainMeun(string input)
        {
            if(input.ToUpper() == "M")
            {
                return true;
            }

            return false;
        }

        public static void MainMeunMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Enter M to return to the main meun");
            Console.WriteLine();
        }

        #endregion

        #region choosing a level and playing it

        public static void levelchoose(Player player1, List<Stage> Levels, string firstInput, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, string mode)
        {
            while (firstInput != "1" && firstInput != "2" && firstInput != "3"
                && firstInput != "4" && firstInput != "5")
            {
                Console.WriteLine();
                Console.WriteLine("enter a number between 1-5 only");
                firstInput = Console.ReadLine();

                if (ShouldIReturnToMainMeun(firstInput))
                {
                    return;
                }
            }

            List<Stage> lvlStages = new List<Stage>();
            switch (firstInput)
            {
                case "1":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.Diffculty == 1)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                case "2":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.Diffculty == 2)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }

                    break;
                case "3":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.Diffculty == 3)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                case "4":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.Diffculty == 4)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
                case "5":
                    foreach (Stage choosenStage in Levels)
                    {
                        if (choosenStage.Diffculty == 5)
                        {
                            lvlStages.Add(choosenStage);
                        }
                    }
                    break;
            }

            Console.Clear();

            ChooseGame(lvlStages, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);

            MainMeunMessage();
            string mainInput = Console.ReadLine();

            if (ShouldIReturnToMainMeun(mainInput))
            {
                return;
            }

            foreach (Stage stage in lvlStages)
            {
                if (mainInput.ToUpper() == stage.KeyForLevel.ToString().ToUpper())
                {
                    if (!stage.Locked && !stage.Won)
                    {
                        if (mode == "NormalGame")
                        {
                            if (player1.HighNormalRank == 0)
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\normalGame\intro.txt");
                                Console.ReadLine();
                            }

                            List<int> beforepositive = new List<int>();
                            List<int> befrenegative = new List<int>();
                            foreach (var point in player1.NormalGamePositivePoints)
                            {
                                beforepositive.Add(point);
                            }
                            foreach (var point in player1.NormalGameNegativePoints)
                            {
                                befrenegative.Add(point);
                            }

                            NormalGame normalGame = new NormalGame(stage, player1);
                            normalGame.next(stage, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, beforepositive, befrenegative);

                            return;
                        }
                        if (mode == "HardcoreGame")
                        {
                            if (player1.HighHardcoreRank == 0)
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\hardcoreGame\bestintro.txt");
                                Console.ReadLine();
                            }

                            List<int> PreviousPositive = new List<int>();
                            foreach (int cell in player1.HardcoreGamePositivePoints)
                            {
                                PreviousPositive.Add(cell);
                            }

                            List<int> PreviousNegative = new List<int>();
                            foreach (int cell in player1.HardcoreGameNegativePoints)
                            {
                                PreviousNegative.Add(cell);
                            }

                            HardcoreGame hardcoregame = new HardcoreGame(stage, player1);
                            hardcoregame.next(stage, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive, PreviousNegative);

                            return;
                        }

                        if (mode == "ExplanationGame")
                        {
                            if (player1.HighExplanationRank == 0)
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\ExplainGame\intro.txt");
                                Console.ReadLine();
                            }

                            List<int> PreviousPositive2 = new List<int>();
                            foreach (int cell in player1.ExplainGamePositivePoints)
                            {
                                PreviousPositive2.Add(cell);
                            }
                            List<int> PreviousNegative2 = new List<int>();
                            foreach (int cell in player1.ExplainGameNegativePoints)
                            {
                                PreviousNegative2.Add(cell);
                            }
                            ExplainGame explaingame = new ExplainGame(stage, player1);
                            explaingame.next(stage, player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, PreviousPositive2, PreviousNegative2);

                            return;
                        }

                        if (mode == "Interaptions")
                        {
                            if (File.Exists(@"DebateGame\InterpationFirstTime.txt"))
                            {
                                Console.Clear();
                                WritingText(@"DebateGame\Interaptions\intro.txt");
                                Console.ReadLine();
                                File.Delete(@"DebateGame\InterpationFirstTime.txt");
                            }

                            TextBookScroll interaptionsScroll = new TextBookScroll(stage, player1);
                            interaptionsScroll.next(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, stage);

                            return;
                        }
                    }

                    if ((stage.Locked) && (stage.Won))
                    {
                        if (mode == "ExplanationGame")
                        {
                            string[] AreUnlockForE = File.ReadAllLines(@"DebateGame\stages\explainunlock.txt");
                            stage.Unlockable = bool.Parse(AreUnlockForE[stage.Position - 1]);
                            if (stage.Unlockable)
                            {
                                for (int i = 0; i < player1.ExplainGamePositivePoints.Count(); i++)
                                {
                                    int positivePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"));
                                    player1.ExplainGamePositivePoints[i] = player1.ExplainGamePositivePoints[i] - positivePoint;
                                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), "0");
                                    int negativePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"));
                                    player1.ExplainGameNegativePoints[i] = player1.ExplainGameNegativePoints[i] - negativePoint;
                                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), "0");
                                }

                                foreach (Stage InteraptioForE in Interaptions)
                                {
                                    if (InteraptioForE.Name == stage.Name)
                                    {
                                        InteraptioForE.Unlockable = false;
                                        string[] AreUnlockForI = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                                        AreUnlockForI[stage.Position - 1] = "False";
                                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", AreUnlockForI);
                                    }
                                }

                                stage.Won = false;
                                stage.Locked = false;
                                stage.Unlockable = false;
                                AreUnlockForE[stage.Position - 1] = "False";
                                File.Delete(@"DebateGame\stages\explainunlock.txt");
                                File.WriteAllLines(@"DebateGame\stages\explainunlock.txt", AreUnlockForE);
                                Reunlocking();
                            }

                            else
                            {
                                AllLocked();
                            }

                            levelchoose(player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                            return;
                        }

                        if (mode == "HardcoreGame")
                        {
                            string[] AreUnlockForH = File.ReadAllLines(@"DebateGame\stages\hardcoreunlock.txt");
                            stage.Unlockable = bool.Parse(AreUnlockForH[stage.Position - 1]);
                            if (stage.Unlockable)
                            {
                                for (int i = 0; i < player1.HardcoreGamePositivePoints.Count(); i++)
                                {
                                    int positivePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"));
                                    player1.HardcoreGamePositivePoints[i] = player1.HardcoreGamePositivePoints[i] - positivePoint;
                                    File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), "0");
                                    int negativePoint = int.Parse(File.ReadAllText($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"));
                                    player1.HardcoreGameNegativePoints[i] = player1.HardcoreGameNegativePoints[i] - negativePoint;
                                    File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), "0");
                                }
                                foreach (Stage InteraptioForH in Interaptions)
                                {
                                    if (InteraptioForH.Name == stage.Name)
                                    {
                                        InteraptioForH.Unlockable = false;
                                        string[] AreUnlockForI = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                                        AreUnlockForI[stage.Position - 1] = "False";
                                        File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
                                        File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", AreUnlockForI);
                                    }
                                }
                                stage.Unlockable = false;
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

                            levelchoose(player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                            return;
                        }

                        if (mode == "NormalGame")
                        {
                            Console.WriteLine();
                            Console.WriteLine("You can't remove your wins at this mode!");
                            Console.WriteLine("Don't try this shit again, or else.. or else.. nothing.");
                            Console.WriteLine("Anyway, enter any key and after that, choose a level again..");
                            Console.WriteLine();
                            Console.ReadLine();

                            levelchoose(player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                            return;
                        }
                    }

                    else if (!stage.Won && stage.Locked && mode != "Interaptions")
                    {
                        Console.WriteLine();
                        Console.WriteLine("You can't enter this!");
                        Console.WriteLine("Don't try this shit again, or else.. or else.. nothing.");
                        Console.WriteLine("Anyway, enter any key and after that, choose a level again..");
                        Console.ReadLine();
                        levelchoose(player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                        return;
                    }

                    else if (!stage.Won && stage.Locked && mode == "Interaptions")
                    {
                        string[] unlockForI = File.ReadAllLines(@"DebateGame\stages\interaptionsunlock.txt");
                        stage.Unlockable = bool.Parse(unlockForI[stage.Position - 1]);
                        if (stage.Unlockable)
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
                            stage.Unlockable = false;

                            Console.WriteLine();
                            Console.WriteLine("Congrats for unlocking the interpations of this stage O_o");
                            Console.WriteLine();
                            Console.WriteLine("Now this stage in normal, explain and hardcore modes will stay locked,");
                            Console.WriteLine("Until you reset your player status, that is");
                            Console.WriteLine();
                            Console.WriteLine("Enter any key to continue");
                            Console.WriteLine();
                            Console.ReadLine();

                            levelchoose(player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                            return;
                        }

                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You haven't unlocked the option to unlock this.");
                            Console.WriteLine("This is becuse you don't have this stage won at explain and hardcore modes");
                            Console.WriteLine("Enter any key to continue");
                            Console.WriteLine();
                            Console.ReadLine();
                            levelchoose(player1, Levels, firstInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                            return;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("That doesn't match any level..");
            Console.WriteLine();
            Console.WriteLine("Enter anything to return to the main meun.");
            Console.ReadLine();

            return;
        }

        #endregion

        #region the main meun (and calling the functions for its mods)

        public static void MainMeun(Player player1, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions)
        {
            Console.Clear();
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

            unlocking = (player1.HighExplanationRank >= 5 && player1.HighHardcoreRank >= 7.6);

            if ((unlocking) &&
                (!(File.Exists(@"DebateGame\Messages\unlock.txt"))))
            {
                Console.WriteLine("Congrats! You've rankings are high enough to unlock all stages!");
                Console.WriteLine();
                string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                int num2 = int.Parse(num);
                Console.WriteLine($"It took you {num2} attempts!");
                Console.WriteLine();
                Console.WriteLine("Enter any key to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
                var unlockGame = File.Create(@"DebateGame\Messages\unlock.txt");
                unlockGame.Close();
            }

            if ((complete) && ((!(File.Exists(@"DebateGame\Messages\complete.txt")))))
            {
                Console.WriteLine("Congrats! You've beaten all stages!");
                Console.WriteLine();
                string num = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                int num2 = int.Parse(num);
                Console.WriteLine($"It took you {num2} attempts!");
                num2 = 0;
                File.WriteAllText(@"DebateGame\attempts\attempt.txt", (num2.ToString()));
                Console.WriteLine();
                Console.WriteLine("You finished with the following status:");
                Console.WriteLine();
                Console.WriteLine($"Normal game mode rank: {player1.RankingCalculation(player1.NormalGamePositivePoints, player1.NormalGameNegativePoints, player1.Knowledge)}");
                Console.WriteLine();
                Console.WriteLine($"Explanation game mode rank: {player1.RankingCalculation(player1.ExplainGamePositivePoints, player1.ExplainGameNegativePoints, 0)}");
                Console.WriteLine();
                Console.WriteLine($"Hardcore game mode rank: {player1.RankingCalculation(player1.HardcoreGamePositivePoints, player1.HardcoreGameNegativePoints, 0)}");
                Console.WriteLine();
                Console.WriteLine("Enter any key to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
                var completeGame = File.Create(@"DebateGame\Messages\complete.txt");
                completeGame.Close();
            }

            #endregion

            WritingText(@"DebateGame\MainMeun.txt");
            string mainInput = Console.ReadLine();

            while(mainInput.ToUpper() != "G" && mainInput.ToUpper() != "H"
                && mainInput.ToUpper() != "E" && mainInput.ToUpper() != "I"
                && mainInput.ToUpper() != "V" && mainInput.ToUpper() != "R"
                && mainInput.ToUpper() != "M" && mainInput.ToUpper() != "S")
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Enter again:");
                Console.WriteLine();
                mainInput = Console.ReadLine();
            }

            if (mainInput.ToUpper() == "G")
            {
                string mode = "NormalGame";
                Console.Clear();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                mainInput = Console.ReadLine();

                if(ShouldIReturnToMainMeun(mainInput))
                {
                    return;
                }

                levelchoose(player1, NormalLevels, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                return;
            }

            else if (mainInput.ToUpper() == "H")
            {
                string mode = "HardcoreGame";
                Console.Clear();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                mainInput = Console.ReadLine();

                if (ShouldIReturnToMainMeun(mainInput))
                {
                    return;
                }

                levelchoose(player1, HardcoreLevels, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                return;
            }
            else if (mainInput.ToUpper() == "E")
            {
                string mode = "ExplanationGame";
                Console.Clear();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                mainInput = Console.ReadLine();

                if (ShouldIReturnToMainMeun(mainInput))
                {
                    return;
                }

                levelchoose(player1, ExplainLevels, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                return;
            }

            else if (mainInput.ToUpper() == "I")
            {
                string mode = "Interaptions";
                Console.Clear();
                WritingText(@"DebateGame\diffculty.txt");
                MainMeunMessage();
                mainInput = Console.ReadLine();

                if (ShouldIReturnToMainMeun(mainInput))
                {
                    return;
                }

                levelchoose(player1, Interaptions, mainInput, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, mode);

                return;
            }

            else if (mainInput.ToUpper() == "V")
            {
                Console.Clear();
                List<string> pointCategories = new List<string>();
                pointCategories = player1.getPointCategories();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Normal Game points: ");
                Console.WriteLine();
                for (int i = 0; i < pointCategories.Count; i++)
                {
                    Console.Write(pointCategories[i]);
                    Console.Write(player1.NormalGamePositivePoints[i]);
                    Console.Write(" positive points, ");
                    Console.Write(player1.NormalGameNegativePoints[i]);
                    Console.Write(" negative points");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine($"Knowledge points: {player1.Knowledge}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Explanations game points: ");
                Console.WriteLine();

                for (int i = 0; i < pointCategories.Count; i++)
                {
                    Console.Write(pointCategories[i]);
                    Console.Write(player1.ExplainGamePositivePoints[i]);
                    Console.Write(" positive points, ");
                    Console.Write(player1.ExplainGameNegativePoints[i]);
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
                    Console.Write(player1.HardcoreGamePositivePoints[i]);
                    Console.Write(" positive points, ");
                    Console.Write(player1.HardcoreGameNegativePoints[i]);
                    Console.Write(" negative points");
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Overall ranking for normal game mode: {player1.RankingCalculation(player1.NormalGamePositivePoints, player1.NormalGameNegativePoints, player1.Knowledge)}");
                Console.WriteLine();
                Console.WriteLine($"Overall ranking for explanation game mode: {player1.RankingCalculation(player1.ExplainGamePositivePoints, player1.ExplainGameNegativePoints, 0)}");
                Console.WriteLine();
                Console.WriteLine($"Overall ranking for hardcore game mode: {player1.RankingCalculation(player1.HardcoreGamePositivePoints, player1.HardcoreGameNegativePoints, 0)}");
                Console.WriteLine();
                Console.WriteLine($"Higtest ranking acheived for normal game mode: {player1.HighNormalRank}");
                Console.WriteLine();
                Console.WriteLine($"Hightest ranking acheived for explanation game mode: {player1.HighExplanationRank}");
                Console.WriteLine();
                Console.WriteLine($"Hightest ranking acheived for hardcore game mode: {player1.HighHardcoreRank}");

                Console.WriteLine();
                Console.WriteLine("Enter anything to return to the main meun.");
                Console.WriteLine();
                mainInput = Console.ReadLine();

                return;
            }

            else if (mainInput.ToUpper() == "R")
            {
                Console.WriteLine();
                Console.WriteLine("Reseting, please wait..");
                Console.WriteLine();

                if (File.Exists(@"DebateGame\Messages\complete.txt"))
                {
                    File.Delete(@"DebateGame\Messages\complete.txt");
                }
                if (File.Exists(@"DebateGame\Messages\unlock.txt"))
                {
                    File.Delete(@"DebateGame\Messages\unlock.txt");
                }
                if (!(File.Exists(@"DebateGame\InterpationFirstTime.txt")))
                {
                    var creation = File.Create(@"DebateGame\InterpationFirstTime.txt");
                    creation.Close();
                }

                int tipNum = 1;
                while (File.Exists($@"DebateGame\Tips\TIP{tipNum}.txt"))
                {
                    tipNum++;
                }
                for (int i = 0; i < tipNum; i++)
                {
                    if (File.Exists($@"DebateGame\Tips\TIP{i}DONE.txt"))
                    {
                        File.Delete($@"DebateGame\Tips\TIP{i}DONE.txt");
                    }
                }

                string recentAttempsNum = File.ReadAllText(@"DebateGame\attempts\attempt.txt");
                int currectAttempsNum = int.Parse(recentAttempsNum);
                currectAttempsNum = currectAttempsNum + 1;
                File.WriteAllText(@"DebateGame\attempts\attempt.txt", (currectAttempsNum.ToString()));

                for (int i = 0; i < 6; i++)
                {
                    player1.NormalGamePositivePoints[i] = 0;
                    player1.NormalGameNegativePoints[i] = 0;
                    player1.ExplainGamePositivePoints[i] = 0;
                    player1.ExplainGameNegativePoints[i] = 0;
                    player1.HardcoreGamePositivePoints[i] = 0;
                    player1.HardcoreGameNegativePoints[i] = 0;
                }

                player1.Knowledge = 0;
                player1.HighNormalRank = 0;
                player1.HighExplanationRank = 0;
                player1.HighHardcoreRank = 0;

                WritingPlayer(player1);

                List<List<Stage>> allLevelsInAllModes = new List<List<Stage>>();
                allLevelsInAllModes.Add(NormalLevels);
                allLevelsInAllModes.Add(HardcoreLevels);
                allLevelsInAllModes.Add(ExplainLevels);

                foreach (List<Stage> levels in allLevelsInAllModes)
                {
                    foreach (Stage stage in levels)
                    {
                        stage.Won = false;
                    }
                }

                for (int i = 0; i < player1.HardcoreGamePositivePoints.Count; i++)
                {
                    foreach (Stage stage in HardcoreLevels)
                    {
                        File.WriteAllText(($@"DebateGame\player\previouspoints\positiveHardcore{stage.Name}{i}.txt"), "0");
                        File.WriteAllText(($@"DebateGame\player\previouspoints\negativeHardcore{stage.Name}{i}.txt"), "0");
                        stage.Won = false;
                        stage.Unlockable = false;
                    }
                }
                for (int i = 0; i < player1.ExplainGamePositivePoints.Count; i++)
                {
                    foreach (Stage stage in ExplainLevels)
                    {
                        File.WriteAllText(($@"DebateGame\player\previouspoints\positiveExplain{stage.Name}{i}.txt"), "0");
                        File.WriteAllText(($@"DebateGame\player\previouspoints\negativeExplain{stage.Name}{i}.txt"), "0");
                        stage.Won = false;
                        stage.Unlockable = false;
                    }
                }
                for (int i = 0; i < player1.NormalGamePositivePoints.Count; i++)
                {
                    foreach (Stage stage in NormalLevels)
                    {
                        File.WriteAllText(($@"DebateGame\player\normalLossPoints\negative{stage.Name}{i}.txt"), "0");
                        File.WriteAllText(($@"DebateGame\player\normalLossPoints\positive{stage.Name}{i}.txt"), "0");
                        stage.Won = false;
                        stage.Unlockable = false;
                    }
                }

                WritingStages(NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Your player status had reseted.");
                Console.WriteLine();
                Console.WriteLine("Enter any key to return to the main meun");
                Console.ReadLine();

                Main();
            }
            else if (mainInput.ToUpper() == "M")
            {
                Stage stage = new Stage("Manual", 0, 0, "M");
                stage.DataBase = XDocument.Load(@"DebateGame\Manual.xml");
                TextBookScroll manual = new TextBookScroll(stage, player1);
                manual.next(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, stage);

                return;
            }

            else if (mainInput.ToUpper() == "S")
            {
                Console.WriteLine();
                Console.WriteLine("Saving, please wait..");
                Console.WriteLine();

                WritingPlayer(player1);
                WritingStages(NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);

                Console.Clear();
                Console.WriteLine("Your advancement in the game has been saved");
                Console.WriteLine();
                Console.WriteLine("Enter any key to return to the main meun");
                Console.ReadLine();

                return;
            }
        }

        #endregion

        #endregion

        #region console save
        
        public static void WritingPlayer(Player player)
        {
            string[] normalGamePositive = new string[player.NormalGamePositivePoints.Count()];
            for (int i = 0; i < player.NormalGamePositivePoints.Count(); i++)
            {
                normalGamePositive[i] = player.NormalGamePositivePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\normalpositive\normalpositive{i}.txt", normalGamePositive[i]);
            }
            
            string[] normalGameNegative = new string[player.NormalGameNegativePoints.Count()];
            for (int i = 0; i < player.NormalGameNegativePoints.Count(); i++)
            {
                normalGameNegative[i] = player.NormalGameNegativePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\normalnegative\normalnegative{i}.txt", normalGameNegative[i]);
            }

            string[] hardcoreGamePositive = new string[player.HardcoreGamePositivePoints.Count()];
            for (int i = 0; i < player.HardcoreGamePositivePoints.Count(); i++)
            {
                hardcoreGamePositive[i] = player.HardcoreGamePositivePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\hardcorepositive\hardcorepositive{i}.txt", hardcoreGamePositive[i]);
            }

            string[] hardcoreGameNegative = new string[player.HardcoreGameNegativePoints.Count()];
            for (int i = 0; i < player.HardcoreGameNegativePoints.Count(); i++)
            {
                hardcoreGameNegative[i] = player.HardcoreGameNegativePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\hardcorenegative\hardcorenegative{i}.txt", hardcoreGameNegative[i]);
            }

            string[] ExplainGamePositive = new string[player.ExplainGamePositivePoints.Count()];
            for (int i = 0; i < player.ExplainGamePositivePoints.Count(); i++)
            {
                ExplainGamePositive[i] = player.ExplainGamePositivePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\explainpositive\explainpositive{i}.txt", ExplainGamePositive[i]);
            }

            string[] ExplainGameNegative = new string[player.ExplainGameNegativePoints.Count()];
            for (int i = 0; i < player.ExplainGameNegativePoints.Count(); i++)
            {
                ExplainGameNegative[i] = player.ExplainGameNegativePoints[i].ToString();
                File.WriteAllText($@"DebateGame\player\explainnegative\explainnegative{i}.txt", ExplainGameNegative[i]);
            }

            string knowledge = player.Knowledge.ToString();
            File.WriteAllText(@"DebateGame\player\knowledge.txt", knowledge);

            string highNormal = player.HighNormalRank.ToString();
            File.WriteAllText(@"DebateGame\player\highnormal.txt", highNormal);

            string highHardcore = player.HighHardcoreRank.ToString();
            File.WriteAllText(@"DebateGame\player\highhardcore.txt", highHardcore);

            string highExplain = player.HighExplanationRank.ToString();
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
                isExplainUnlock[i] = ExplainLevels[i].Unlockable.ToString();
            }
            File.Delete(@"DebateGame\stages\explainunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\explainunlock.txt", isExplainUnlock);

            string[] hardcore = new string[HardcoreLevels.Count()];
            string[] isHardcoreUnlock = new string[HardcoreLevels.Count()];
            for (int i = 0; i < HardcoreLevels.Count; i++)
            {
                hardcore[i] = HardcoreLevels[i].Won.ToString();
                File.WriteAllText($@"DebateGame\stages\hardcore\hardcore{i}.txt", hardcore[i]);
                isHardcoreUnlock[i] = HardcoreLevels[i].Unlockable.ToString();
            }
            File.Delete(@"DebateGame\stages\hardcoreunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\hardcoreunlock.txt", isHardcoreUnlock);

            string[] IsInteraptionUnlock = new string[InterpationsRightNow.Count()];
            for(int i = 0; i < InterpationsRightNow.Count(); i++)
            {
                IsInteraptionUnlock[i] = InterpationsRightNow[i].Unlockable.ToString();
            }
            File.Delete(@"DebateGame\stages\interaptionsunlock.txt");
            File.WriteAllLines(@"DebateGame\stages\interaptionsunlock.txt", IsInteraptionUnlock);
        }

        #endregion

        #region the actual main of the program

        public static void Main()
        {
            Console.Title = "Debate Game";
            Console.SetWindowSize(110, 50);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;

            List<Stage> NormalLevels = new List<Stage>();
            List<Stage> HardcoreLevels = new List<Stage>();
            List<Stage> Interaptions = new List<Stage>();
            List<Stage> ExplainLevels = new List<Stage>();

            NormalLevels = NormalGames();
            HardcoreLevels = HardcoreGames();
            Interaptions = InteraptionsForLevels();
            ExplainLevels = ExplanationGames();

            Player player1 = new Player();

            for (double i = 0; i < double.MaxValue; i++)
            {
                MainMeun(player1, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
            }
        }

        #endregion
    }
}