using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCowsGame
{
    public class Program
    {
        public static void Main()
        {
            BullsAndCowsUI m_Game;

            m_Game = new BullsAndCowsUI();
            m_Game.StartGame();
        }
    }
}
