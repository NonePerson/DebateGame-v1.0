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
    public class Stage
    {
        #region ctor
        public Stage(string stageName, int diffculty, int position, string place)
        {
            // place = "n"/"e"/"h"
            #region initializing the propeties's values
            this.Name = stageName;
            // only the locked and won propeties will need to be in text files
            this.Locked = true;
            this.Won = false;
            KeyForLevel = new ConsoleKey();
            DataBase = new XDocument();
            Position = position;
            this.diffculty = diffculty;
            this.NormalRankCondition = 0;
            this.HardcoreRankCondition = 0;
            this.ExplainRankCondition = 0;
            this.mode = place;
            MaxPoints = 0;
            Won = mod(position, place, "won");
            unlockable = mod(position, place, "unlock");
            #endregion
        }
        #endregion
        public static bool mod(int position, string place, string propertie)
        {
            string stage;
            switch (place.ToUpper())
            { 
                case "G":
                        for (int i = 0; i < 10; i++)
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
                        for (int i = 0; i < 10; i++)
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
                        string TheStage = stages[position - 1];
                        return bool.Parse(TheStage);
                    }
                    break;
                case "H":
                    if (propertie == "won")
                    {
                        for (int i = 0; i < 10; i++)
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
                        string TheStage = stages[position - 1];
                        return bool.Parse(TheStage);
                    }
                    break;
                case "I":
                    string[] stages2 = File.ReadAllLines($@"DebateGame\stages\interaptionsunlock.txt");
                    string TheStage2 = stages2[position - 1];
                    return bool.Parse(TheStage2);
            }

            return false;
        }
        #region Properties
        public bool Locked { get; set; }
        public bool Won { get; set; }
        public string Name { get; set; }
        public ConsoleKey KeyForLevel { get; set; }
        public XDocument DataBase { get; set; }
        public int diffculty { get; set; }
        public double NormalRankCondition { get; set; }
        public double HardcoreRankCondition { get; set; }
        public double ExplainRankCondition { get; set; }
        public double MaxPoints { get; set; }
        public string mode { get; set; }
        public bool unlockable { get; set; }
        public int Position { get; set; }
        #endregion
    }
}