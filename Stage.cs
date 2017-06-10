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
            this.diffculty = diffculty;
            this.NormalRankCondition = 0;
            this.HardcoreRankCondition = 0;
            this.ExplainRankCondition = 0;
            this.mode = place;
            Won = mod(position, place);
            #endregion


        }
        #endregion
        public static bool mod(int position, string place)
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
                    for (int i = 0; i < 10; i++)
                    {
                        if (position - 1 == i)
                        {
                            stage = File.ReadAllText($@"DebateGame\stages\explain\explain{i}.txt");
                            return bool.Parse(stage);
                        }
                    }
                    break;
                case "H":
                    for (int i = 0; i < 10; i++)
                    {
                        if (position - 1 == i)
                        {
                            stage = File.ReadAllText($@"DebateGame\stages\hardcore\hardcore{i}.txt");
                            return bool.Parse(stage);
                        }
                    }
                    break;
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

        public string mode { get; set; }
        #endregion
    }
}