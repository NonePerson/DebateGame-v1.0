using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    public class HardcoreGameAnswers
    {
        #region useless part
        // NOTE: Please limit the number of answers the user can sumbit, or else he might sumbit all 18
        /* this is useless, isn't it?
        public HardcoreGameAnswers()
        {
            options = new List<double>();
            for (int i = 0; i < 18; i++)
            {
                options.Add(i);
            }
        }
        
        List<double> options { get; set; }
        */
        #endregion

        #region checking the player's answers list
        public bool isTheAnswerCorrect(int currectAnswer, List<int> userAnswers)
        {
            foreach(int userAnswer in userAnswers)
            {
                if(currectAnswer == userAnswer)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region the 2 main functions (returning updates lists of the player's points)
        // there is a double code here due to needing returning two lists - try to get rid of it
        public List<int> UpdatingPositivePoints(List<int> userAnswers2, List<int> correctAnswers2, List<int> hardcoreGamePositivePoints, List<int> hardcoreGameNegativePoints, string mode)
        {
            List<bool> matchingAnswers = new List<bool>();
            foreach (int currectAnswer in correctAnswers2)
            {
                if (isTheAnswerCorrect(currectAnswer, userAnswers2))
                {
                    matchingAnswers.Add(true);                    
                }
                else
                {
                    matchingAnswers.Add(false);
                }
            }
            hardcoreGamePositivePoints = PositivePoints(userAnswers2, correctAnswers2, hardcoreGamePositivePoints, matchingAnswers, mode);
            return hardcoreGamePositivePoints;
        }
        public List<int> UpdatingNegativePoints(List<int> userAnswers2, List<int> correctAnswers2, List<int> hardcoreGamePositivePoints, List<int> hardcoreGameNegativePoints, string mode)
        {
            List<bool> matchingAnswers = new List<bool>();
            foreach (int currectAnswer in correctAnswers2)
            {
                if (isTheAnswerCorrect(currectAnswer, userAnswers2))
                {
                    matchingAnswers.Add(true);
                }
                else
                {
                    matchingAnswers.Add(false);
                }
            }
            hardcoreGameNegativePoints = NegativePoints(userAnswers2, correctAnswers2, hardcoreGameNegativePoints, matchingAnswers, mode);
            return hardcoreGameNegativePoints;
        }
        #endregion

        #region the 2 functions that do the actual update
        public List<int> PositivePoints(List<int> userAnswers2, List<int> correctAnswers2, List<int> hardcoreGamePositivePoints, List<bool> matchingAnswers, string mode)
        {
            for(int i = 0; i < matchingAnswers.Count; i++)
            {
                if(matchingAnswers[i])
                {
                    hardcoreGamePositivePoints = PlayerPoints(hardcoreGamePositivePoints, userAnswers2[i], mode);
                }                          
            }
            return hardcoreGamePositivePoints;
        }
        public List<int> NegativePoints(List<int> userAnswers2, List<int> correctAnswers2, List<int> hardcoreGameNegativePoints, List<bool> matchingAnswers, string mode)
        {
            for (int i = 0; i < matchingAnswers.Count; i++)
            {
                if (!matchingAnswers[i])
                {
                    PlayerPoints(hardcoreGameNegativePoints, userAnswers2[i], mode);
                    PlayerPoints(hardcoreGameNegativePoints, correctAnswers2[i], mode);
                    
                    //hardcoreGameNegativePoints[0] += 2;
                }
            }
            return hardcoreGameNegativePoints;
        }
        #endregion

        #region checking each answer's belonging to the point categories
        public List<int> PlayerPoints(List<int> points, int answer, string mode)
        {
            if (mode.ToUpper() == "H")
            {
                if (answer == 3 || answer == 10)
                {
                    points[0] = points[0] + 1;
                }
                if (answer == 4)
                {
                    points[1] = points[1] + 1;
                }
                if (answer == 2 || answer == 7 || answer == 8 || answer == 9)
                {
                    points[2] = points[2] + 1;
                }
                if (answer == 1 || answer == 5 || answer == 6)
                {
                    points[3] = points[3] + 1;
                }
                if (answer == 14 || answer == 18 || answer == 19)
                {
                    points[4] = points[4] + 1;
                }
                if (answer == 11 || answer == 12 || answer == 13 || answer == 15 || answer == 16 || answer == 17 || answer == 20)
                {
                    points[5] = points[5] + 1;
                }

                return points;
            }
            if(mode.ToUpper() == "E")
            {
                points[answer] = points[answer] + 1;
                return points;
            }
            return points;
        }
        #endregion
    }
}
