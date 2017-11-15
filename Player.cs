using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApplication9
{
    public class Player
    {
        #region ctor

        public Player()
        {
            #region intial initialization

            this.NormalGamePositivePoints = new List<int>();
            this.NormalGameNegativePoints = new List<int>();
            this.HardcoreGamePositivePoints = new List<int>();
            this.HardcoreGameNegativePoints = new List<int>();
            this.ExplainGamePositivePoints = new List<int>();
            this.ExplainGameNegativePoints = new List<int>();

            #endregion

            #region value placements

            NormalGamePositivePoints = ListModify(@"DebateGame\player\normalpositive\normalpositive", NormalGamePositivePoints);
            NormalGameNegativePoints = ListModify(@"DebateGame\player\normalnegative\normalnegative", NormalGameNegativePoints);
            HardcoreGamePositivePoints = ListModify(@"DebateGame\player\hardcorepositive\hardcorepositive", HardcoreGamePositivePoints);
            HardcoreGameNegativePoints = ListModify(@"DebateGame\player\hardcorenegative\hardcorenegative", HardcoreGameNegativePoints);
            ExplainGamePositivePoints = ListModify(@"DebateGame\player\explainpositive\explainpositive", ExplainGamePositivePoints);
            ExplainGameNegativePoints = ListModify(@"DebateGame\player\explainnegative\explainnegative", ExplainGameNegativePoints);
            Knowledge = PointModify(@"DebateGame\player\knowledge.txt", Knowledge);
            HighNormalRank = PointModify(@"DebateGame\player\highnormal.txt", HighNormalRank);
            HighExplanationRank = PointModify((@"DebateGame\player\highexplain.txt"), HighExplanationRank);
            HighHardcoreRank = PointModify(@"DebateGame\player\highhardcore.txt", HighHardcoreRank);

            #endregion
        }

        #endregion ctor

        #region Properties
        public List<int> NormalGamePositivePoints { get; set; }       
        public List<int> NormalGameNegativePoints { get; set; }
        public List<int> HardcoreGamePositivePoints { get; set; }              
        public List<int> HardcoreGameNegativePoints { get; set; }
        public List<int> ExplainGamePositivePoints { get; set; }
        public List<int> ExplainGameNegativePoints { get; set; }
        
        public double Knowledge { get; set; }
        public double HighNormalRank { get; set; }
        public double HighHardcoreRank { get; set; }
        public double HighExplanationRank { get; set; }

        #endregion

        #region Calculating the player's rank

        private static List<int> ListModify(string path, List<int> pointList)
        {
            for(int i = 0; i < 6; i++)
            {
                pointList.Add(int.Parse(File.ReadAllText($"{path}{i}.txt")));
            }
           
            return pointList;
        }
        
        private static double PointModify(string path, double point)
        {
            point = double.Parse(File.ReadAllText(path));
            return point;
        }

        public double RankingCalculation(List<int> GamePositivePoints, List<int> GameNegativePoints, double knowledge)
        {
            double positivePoints = 0;
            double negativePoints = 0;
            for (int i = 0; i < 6; i++)
            {
                positivePoints += GamePositivePoints[i];
                negativePoints += GameNegativePoints[i];
            }
            positivePoints = positivePoints + knowledge;
            
            if(positivePoints == 0)
            {
                return 0;
            }
            
            if (positivePoints <= negativePoints)
            {
                return (Math.Pow(((positivePoints / negativePoints) * 0.5), 0.5)) * positivePoints;
            }

            else
            {
                double first = Math.Pow(0.5, 0.5);
                double second = (Math.Pow(((negativePoints / positivePoints) * 0.5), 0.5));
                return (Math.Pow(first, second)) * positivePoints;
            }
        }

        #endregion

        #region intializing the point categories

        public List<string> getPointCategories()
        {
            List<string> pointCategories = new List<string>();
            pointCategories.Add("logical fallacy: ");
            pointCategories.Add("self contradiction: ");
            pointCategories.Add("defintion: ");
            pointCategories.Add("base: ");
            pointCategories.Add("focusing on the main: ");
            pointCategories.Add("reflection: ");
            return pointCategories;
        }
        #endregion
    }
}