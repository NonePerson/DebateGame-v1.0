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

    public class Player
    {
        #region ctor
        public Player()
        {
            #region intial initialization    
            this.normalGamePositivePoints = new List<int>();                         
            this.normalGameNegativePoints = new List<int>();
            this.hardcoreGamePositivePoints = new List<int>();
            this.hardcoreGameNegativePoints = new List<int>();
            this.ExplanationGamePositive = new List<int>();
            this.ExplanationGameNegative = new List<int>();
            #endregion
            #region value placements
            for (int i = 0; i < 6; i++)
            {
                this.normalGamePositivePoints.Add(0);
                this.normalGameNegativePoints.Add(0);
                this.hardcoreGamePositivePoints.Add(0);
                this.hardcoreGameNegativePoints.Add(0);
                this.ExplanationGamePositive.Add(0);
                this.ExplanationGameNegative.Add(0);
            }
            this.knowledge = 0;
            this.highNormalRank = RankingCalculation(normalGamePositivePoints, normalGameNegativePoints, knowledge);
            this.highExplanationRank = RankingCalculation(ExplanationGamePositive, ExplanationGameNegative, 0);
            this.highHardcoreRank = RankingCalculation(hardcoreGamePositivePoints, hardcoreGameNegativePoints, 0);

            normalGamePositivePoints = listModify(@"DebateGame\player\normalpositive\normalpositive", normalGamePositivePoints);
            normalGameNegativePoints = listModify(@"DebateGame\player\normalnegative\normalnegative", normalGameNegativePoints);
            hardcoreGamePositivePoints = listModify(@"DebateGame\player\hardcorepositive\hardcorepositive", hardcoreGamePositivePoints);
            hardcoreGameNegativePoints = listModify(@"DebateGame\player\hardcorenegative\hardcorenegative", hardcoreGameNegativePoints);
            ExplanationGamePositive = listModify(@"DebateGame\player\explainpositive\explainpositive", ExplanationGamePositive);
            ExplanationGameNegative = listModify(@"DebateGame\player\explainnegative\explainnegative", ExplanationGameNegative);
            knowledge = pointModify(@"DebateGame\player\knowledge.txt", knowledge);
            highNormalRank = pointModify(@"DebateGame\player\highnormal.txt", highNormalRank);
            highExplanationRank = pointModify((@"DebateGame\player\highexplain.txt"), highExplanationRank);
            highHardcoreRank = pointModify(@"DebateGame\player\highhardcore.txt", highHardcoreRank);
            #endregion
        }
        #endregion ctor

        #region Properties
        public List<int> normalGamePositivePoints { get; set; }       
        public List<int> normalGameNegativePoints { get; set; }
        public List<int> hardcoreGamePositivePoints { get; set; }              
        public List<int> hardcoreGameNegativePoints { get; set; }
        public List<int> ExplanationGamePositive { get; set; }
        public List<int> ExplanationGameNegative { get; set; }
        
        public double knowledge { get; set; }
        public double normalGameRank { get; set; }
        public double hardcoreGamerank { get; set; }
        public double highNormalRank { get; set; }
        public double highHardcoreRank { get; set; }
        public double highExplanationRank { get; set; }


        #endregion

        #region Calculating the player's rank

        public static List<int> listModify(string path, List<int> that)
        {
            that.RemoveRange(0, 6);
            for(int i = 0; i < 6; i++)
            {
                that.Add(int.Parse(File.ReadAllText($"{path}{i}.txt")));
            }
           
            return that;
        }
        
        public static double pointModify(string path, double point)
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
                return 0; // to avoid dividing in zero
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