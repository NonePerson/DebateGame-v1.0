using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class Stage
    {
        #region ctor

        public Stage(string stageName, int diffculty, int position, string place)
        {
            #region initializing the propeties's values
            this.Name = stageName;
            this.Locked = true;
            this.Won = false;
            this.KeyForLevel = new ConsoleKey();
            this.DataBase = new XDocument();
            this.Position = position;
            this.Diffculty = diffculty;
            this.NormalRankCondition = 0;
            this.HardcoreRankCondition = 0;
            this.ExplainRankCondition = 0;
            this.Mode = place;

            string[] allStages = File.ReadAllLines($@"DebateGame\stages\normal.txt");
            int howManyStages = allStages.Count();

            Won = IsWonOrIsUnlockable(position, place, "won", howManyStages);
            Unlockable = IsWonOrIsUnlockable(position, place, "unlock", howManyStages);
            #endregion
        }
        #endregion

        #region determing whatever each stage and won, or is unlockable

        public static bool IsWonOrIsUnlockable(int position, string place, string propertie, int howManyStages)
        {
            string stage;
            switch (place.ToUpper())
            {
                case "G":
                        for (int i = 0; i < howManyStages; i++)
                        {
                            if (position - 1 == i)
                            {
                                stage = File.ReadAllText($@"DebateGame\stages\normal\normal{i}.txt");
                                return bool.Parse(stage);
                            }
                        }
                    break;
                case "E":
                    if (propertie == "won")
                    {
                        for (int i = 0; i < howManyStages; i++)
                        {
                            if (position - 1 == i)
                            {
                                stage = File.ReadAllText($@"DebateGame\stages\explain\explain{i}.txt");
                                return bool.Parse(stage);
                            }
                        }
                    }
                    else if (propertie == "unlock")
                    {
                        string[] stages = File.ReadAllLines($@"DebateGame\stages\explainunlock.txt");
                        string theStage = stages[position - 1];
                        return bool.Parse(theStage);
                    }
                    break;
                case "H":
                    if (propertie == "won")
                    {
                        for (int i = 0; i < howManyStages; i++)
                        {
                            if (position - 1 == i)
                            {
                                stage = File.ReadAllText($@"DebateGame\stages\hardcore\hardcore{i}.txt");
                                return bool.Parse(stage);
                            }
                        }
                    }
                    else if (propertie == "unlock")
                    {
                        string[] stages = File.ReadAllLines($@"DebateGame\stages\hardcoreunlock.txt");
                        string theStage = stages[position - 1];
                        return bool.Parse(theStage);
                    }
                    break;
                case "I":
                    if (propertie == "unlock")
                    {
                        string[] stages = File.ReadAllLines($@"DebateGame\stages\interaptionsunlock.txt");
                        string TheStage = stages[position - 1];
                        return bool.Parse(TheStage);
                    }
                    break;
            }

            return false;
        }

        #endregion

        #region Properties

        public bool Locked { get; set; }
        public bool Won { get; set; }
        public string Name { get; set; }
        public ConsoleKey KeyForLevel { get; set; }
        public XDocument DataBase { get; set; }
        public int Diffculty { get; set; }
        public double NormalRankCondition { get; set; }
        public double HardcoreRankCondition { get; set; }
        public double ExplainRankCondition { get; set; }
        public string Mode { get; set; }
        public bool Unlockable { get; set; }
        public int Position { get; set; }

        #endregion
    }
}