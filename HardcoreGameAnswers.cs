using System.Collections.Generic;

namespace ConsoleApplication9
{
    public class UpdatingPointsInExplainingModes
    {
        #region checking the player's answers list

        private bool isTheAnswerCorrect(int correctAnswer, List<int> userAnswers)
        {
            foreach(int userAnswer in userAnswers)
            {
                if(correctAnswer == userAnswer)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region the 2 main functions (returning updates lists of the player's points)

        public List<int> UpdatingPositivePoints(List<int> userAnswers, List<int> correctAnswers, List<int> gamePositivePoints, List<int> gameNegativePoints, string mode)
        {
            List<bool> matchingAnswers = new List<bool>();
            foreach (int correctAnswer in correctAnswers)
            {
                matchingAnswers.Add(isTheAnswerCorrect(correctAnswer, userAnswers));
            }
            gamePositivePoints = PositivePoints(userAnswers, correctAnswers, gamePositivePoints, matchingAnswers, mode);
            return gamePositivePoints;
        }

        public List<int> UpdatingNegativePoints(List<int> userAnswers, List<int> correctAnswers, List<int> gamePositivePoints, List<int> gameNegativePoints, string mode)
        {
            List<bool> matchingAnswers = new List<bool>();
            foreach (int correctAnswer in correctAnswers)
            {
                matchingAnswers.Add(isTheAnswerCorrect(correctAnswer, userAnswers));
            }
            gameNegativePoints = NegativePoints(userAnswers, correctAnswers, gameNegativePoints, matchingAnswers, mode);
            return gameNegativePoints;
        }

        #endregion

        #region the 2 functions that do the actual update
        private List<int> PositivePoints(List<int> userAnswers, List<int> correctAnswers, List<int> gamePositivePoints, List<bool> matchingAnswers, string mode)
        {
            for(int i = 0; i < matchingAnswers.Count; i++)
            {
                if(matchingAnswers[i])
                {
                    gamePositivePoints = PlayerPoints(gamePositivePoints, userAnswers[i], mode);
                }                          
            }
            return gamePositivePoints;
        }
        private List<int> NegativePoints(List<int> userAnswers, List<int> correctAnswers, List<int> gameNegativePoints, List<bool> matchingAnswers, string mode)
        {
            for (int i = 0; i < matchingAnswers.Count; i++)
            {
                if (!matchingAnswers[i])
                {
                    gameNegativePoints = PlayerPoints(gameNegativePoints, userAnswers[i], mode);
                    gameNegativePoints = PlayerPoints(gameNegativePoints, correctAnswers[i], mode);     
                }
            }
            return gameNegativePoints;
        }
        #endregion

        #region checking each answer's belonging to the point categories

        private List<int> PlayerPoints(List<int> points, int answer, string mode)
        {
            if (mode.ToUpper() == "H")
            {
                if (answer == 3 || answer == 10 || answer == 16)
                {
                    points[0] = points[0] + 1;
                }
                if (answer == 4)
                {
                    points[1] = points[1] + 1;
                }
                if (answer == 2 || answer == 7 || answer == 8 || answer == 9 || answer == 6)
                {
                    points[2] = points[2] + 1;
                }
                if (answer == 1 || answer == 5)
                {
                    points[3] = points[3] + 1;
                }
                if (answer == 14 || answer == 18 || answer == 19 || answer == 16)
                {
                    points[4] = points[4] + 1;
                }
                if (answer == 11 || answer == 12 || answer == 13 || answer == 15 || answer == 17 || answer == 20)
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