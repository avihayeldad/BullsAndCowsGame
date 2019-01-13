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
    public partial class UserGuessButtons : UserControl
    {
        private Button[] m_GuessButtons;

        public UserGuessButtons()
        {
            this.Size = new Size(245, 50);
            m_GuessButtons = new Button[4];
            m_GuessButtons[0] = new Button();
            m_GuessButtons[0].Location = new Point(0, 0);
            m_GuessButtons[0].Size = new Size(50, 50);
            m_GuessButtons[1] = new Button();
            m_GuessButtons[1].Location = new Point(65, 0);
            m_GuessButtons[1].Size = new Size(50, 50);
            m_GuessButtons[2] = new Button();
            m_GuessButtons[2].Location = new Point(130, 0);
            m_GuessButtons[2].Size = new Size(50, 50);
            m_GuessButtons[3] = new Button();
            m_GuessButtons[3].Location = new Point(195, 0);
            m_GuessButtons[3].Size = new Size(50, 50);
            this.Controls.Add(m_GuessButtons[0]);
            this.Controls.Add(m_GuessButtons[1]);
            this.Controls.Add(m_GuessButtons[2]);
            this.Controls.Add(m_GuessButtons[3]);
            InitializeComponent();
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                for (int i = 0; i < 4; ++i)
                {
                    m_GuessButtons[i].BackColor = value;
                }
            }
        }

        public Button[] GuessButtons
        {
            get
            {
                return m_GuessButtons;
            }
        }
    }
}
