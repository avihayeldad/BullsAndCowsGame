using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCowsGame
{
    public partial class ResultButtons : UserControl
    {
        private Button[] m_Buttons;

        public ResultButtons()
        {
            this.Size = new Size(55, 55);
            m_Buttons = new Button[4];
            m_Buttons[0] = new Button();
            m_Buttons[0].Location = new Point(0, 0);
            m_Buttons[0].Size = new Size(15, 15);
            m_Buttons[0].TabStop = false;
            m_Buttons[1] = new Button();
            m_Buttons[1].Location = new Point(0, 25);
            m_Buttons[1].Size = new Size(15, 15);
            m_Buttons[1].TabStop = false;
            m_Buttons[2] = new Button();
            m_Buttons[2].Location = new Point(25, 0);
            m_Buttons[2].Size = new Size(15, 15);
            m_Buttons[2].TabStop = false;
            m_Buttons[3] = new Button();
            m_Buttons[3].Location = new Point(25, 25);
            m_Buttons[3].Size = new Size(15, 15);
            m_Buttons[3].TabStop = false;
            this.Controls.Add(m_Buttons[0]);
            this.Controls.Add(m_Buttons[1]);
            this.Controls.Add(m_Buttons[2]);
            this.Controls.Add(m_Buttons[3]);
            InitializeComponent();
        }

        public Button[] Buttons
        {
            get
            {
                return m_Buttons;
            }

            set
            {
                m_Buttons = value;
            }
        }
    }
}
