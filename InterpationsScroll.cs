using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApplication9
{
    public class TextBookScroll : Program
    {
        #region ctor

        public TextBookScroll(Stage currectStage, Player player)
        {
            DataBase = new XDocument(currectStage.DataBase);
            Screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            RecentScreen = new XElement(Screens.First());
            Path = new XElement(RecentScreen.Element("Path"));
        }

        #endregion

        #region The actual function

        public void next(Player player, List<Stage> NormalLevels, List<Stage> ExplainLevels, List<Stage> HardcoreLevels, List<Stage> Interaptions, Stage stageI)
        {
            Console.Clear();
            WritingText(Path.Value);
            Console.WriteLine();
            Console.WriteLine("enter 'U' to go to the next screen, or D to go to the previous screen");
            Console.WriteLine();

            if (stageI.Mode.ToUpper() == "I")
            {
                Console.WriteLine("In order to view the list of moves for hardcore mode, enter H");
                Console.WriteLine();
                Console.WriteLine("In order to view the list of moves for explain mode, enter E");
                Console.WriteLine();
            }

            MainMeunMessage();
            Console.WriteLine();
            Input = Console.ReadLine();

            if(ShouldIReturnToMainMeun(Input))
            {
                return;
            }

            if (stageI.Mode.ToUpper() == "M")
            {
                while (Input.ToUpper() != "D" && Input.ToUpper() != "U")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Enter again: ");
                    Console.WriteLine();
                    Input = Console.ReadLine();

                    if (ShouldIReturnToMainMeun(Input))
                    {
                        return;
                    }
                }

            }

            else if (stageI.Mode.ToUpper() == "I")
            {
                while (Input.ToUpper() != "D" && Input.ToUpper() != "U" &&
                    Input.ToUpper() != "E" && Input.ToUpper() != "H")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Enter again: ");
                    Console.WriteLine();
                    Input = Console.ReadLine();

                    if (ShouldIReturnToMainMeun(Input))
                    {
                        return;
                    }
                }
            }

            switch (Input.ToUpper())
            {
                case "D":
                    Path = RecentScreen.Element("PreviousScreen");
                    break;
                case "U":
                    Path = RecentScreen.Element("NextScreen");
                    break;
                case "H":
                    if (stageI.Mode.ToUpper() == "I")
                    {
                        Console.Clear();
                        WritingText(@"DebateGame\hardcoreGame\intro.txt");
                        Console.WriteLine();
                        Console.WriteLine("Enter any key to go back to the stage");
                        Console.WriteLine();
                        Console.ReadLine();
                        next(player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, stageI);
                        return;
                    }
                    break;
                case "E":
                    if (stageI.Mode.ToUpper() == "I")
                    {
                        Console.Clear();
                        WritingText(@"DebateGame\ExplainGame\list.txt");
                        Console.WriteLine();
                        Console.WriteLine("Enter any key to go back to the stage");
                        Console.WriteLine();
                        Console.ReadLine();
                        next(player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, stageI);
                        return;
                    }
                    break;
            }

            if (string.IsNullOrEmpty(Path.Value))
            {
                return;
            }

            foreach (var screen in Screens)
            {
                if (screen.Element("Path").Value == Path.Value)
                {
                    RecentScreen = screen;
                }
            }

            next(player, NormalLevels, ExplainLevels, HardcoreLevels, Interaptions, stageI);

        }

        #endregion

        #region Properties

        private XDocument DataBase { get; set; }
        private string Input { get; set; }
        private IEnumerable<XElement> Screens { get; set; }
        private XElement Path { get; set; }
        private XElement RecentScreen { get; set; }

        #endregion
    }
}
