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
    public class BossGame
    {
        #region ctor
        public BossGame(Stage currectStage, Player player, Game NewGame)
        {
            DataBase = new XDocument(currectStage.DataBase);
            DataBase = new XDocument(currectStage.DataBase);
            screens = new List<XElement>(currectStage.DataBase.Root.Elements("Screen"));
            recentScreen = new XElement(screens.First());
            path = new XElement(recentScreen.Element("Path"));
            pointCategory = new List<XElement>(recentScreen.Elements("pointCategory"));
            state = new XElement(recentScreen.Element("State"));
            // I'm still unsure what to do with the rest of the properties.. let's not be harsh
        }
        #endregion

        #region openingScreen

        #endregion

        #region Properties

        string input { get; set; }
        XDocument DataBase { get; set; }
        IEnumerable<XElement> screens { get; set; }
        XElement recentScreen { get; set; }
        XElement path { get; set; }
        XElement state { get; set; }
        IEnumerable<XElement> pointCategory { get; set; }
        IEnumerable<XElement> check { get; set; } // remember: you already know the elemtns in this collection
        XElement LogicalInference { get; set; }
        XElement Definition { get; set; }
        XElement Base { get; set; }
        XElement charAnswerA { get; set; }
        XElement charAnswerB { get; set; }
        XElement charAnswerC { get; set; }
        XElement charAnswerD { get; set; }
        XElement charAnswerE { get; set; }
        IEnumerable<XElement> choices { get; set; }
        XElement Counter { get; set; }

        #endregion
    }
}
