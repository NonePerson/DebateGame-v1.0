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
    public class Game
    {
        #region ctor
        public Game()
        {
            #region intializing properties values
            position = "MainMeun";
            #endregion
        }
        #endregion
        #region Properties
        public string position { get; set; }
        #endregion

        #region initializing other objects
        Player aa = new Player();
        #endregion 

    }
}
