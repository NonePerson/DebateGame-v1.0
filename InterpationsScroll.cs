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
    public class InterpationsScroll : Program
    {
        #region ctor
        public InterpationsScroll(Stage currectStage, Player player, Game NewGame)
        {
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
        }
        #endregion
        #region The actual function
        public void next(Game NewGame, Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions)
        {
            Console.Clear();
            WritingText(path.Value);
            Console.WriteLine();
            Console.WriteLine("Press 'U' to go to the next screen, or D to go to the previous screen");
            Console.WriteLine();
            Console.WriteLine("In order to view the list of moves for hardcore mode, press H");
            Console.WriteLine();
            Console.WriteLine("In order to view the list of point categories with their numbers, press E");
            MainMeunMessage();
            Console.WriteLine();
            input = Console.ReadLine();
            Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, input);
            switch (input.ToUpper())
            {
                case "D":
                    path = recentScreen.Element("PreviousScreen");
                    break;
                case "U":
                    path = recentScreen.Element("NextScreen");
                    break;
                case "H":
                    Console.Clear();
                    WritingText(@"DebateGame\hardcoreGame\intro.txt");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the stage");
                    Console.WriteLine();
                    Console.ReadLine();
                    next(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
                    break;
               case "E":
                    Console.Clear();
                    WritingText(@"DebateGame\ExplainGame\list.txt");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to go back to the stage");
                    Console.WriteLine();
                    Console.ReadLine();
                    next(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
                    break;
                default:
                    next(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
                    break;
            }
            if(path.Value == "")
            {
                Return(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, "m");
            }
            foreach (var screen in screens)
            {
                if (screen.Element("Path").Value == path.Value)
                {
                    recentScreen = screen;
                }
            }
            next(NewGame, player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions);
        }
        // Return(NewGame, player, NormalLevels, HardcoreLevels, Interaptions, oneInput);
        #endregion

        #region Properties

        XDocument DataBase { get; set; }
        string input { get; set; }
        IEnumerable<XElement> screens { get; set; }
        XElement path { get; set; }
        XElement recentScreen { get; set; }

        #endregion
    }
}
