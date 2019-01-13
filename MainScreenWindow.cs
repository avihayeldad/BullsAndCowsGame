using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCowsGame
{
    public partial class MainScreenWindow : Form
    {
        private string m_CurrentSequence;
        private BullsAndCows m_BullsAndCowsAlgorithm;
        private UserGuessButtons m_HiddenSequenceButtons;
        private GuessLineButtons[] m_GuessLinesButtons;

        public MainScreenWindow(BullsAndCows i_BullsAndCowsAlgorithm)
        {
            m_HiddenSequenceButtons = new UserGuessButtons();
            m_HiddenSequenceButtons.Enabled = false;
            m_BullsAndCowsAlgorithm = i_BullsAndCowsAlgorithm;
            this.Text = "Bool Pgia";
            this.StartPosition = FormStartPosition.CenterScreen;
            m_HiddenSequenceButtons.Location = new Point(15, 15);
            m_HiddenSequenceButtons.BackColor = Color.Black;
            this.Controls.Add(m_HiddenSequenceButtons);
            createGuessLinesButtons();
            this.Size = new Size(405, m_GuessLinesButtons[m_GuessLinesButtons.Length - 1].Top + 100);
            InitializeComponent();
        }

        private void createGuessLinesButtons()
        {
            m_GuessLinesButtons = new GuessLineButtons[m_BullsAndCowsAlgorithm.TotalGuessNumber];
            for (int i = 0; i < m_GuessLinesButtons.Length; ++i)
            {
                m_GuessLinesButtons[i] = new GuessLineButtons(this, i);
                m_GuessLinesButtons[i].UserGuessButtons.BackColor = Color.WhiteSmoke;
                m_GuessLinesButtons[i].Location = new Point(15, 75 + (i * 65));
                this.Controls.Add(m_GuessLinesButtons[i]);
            }
        }

        public void PaintHiddenSequenceButtons()
        {
            for (int i = 0; i < 4; ++i)
            {
                m_HiddenSequenceButtons.GuessButtons[i].BackColor = 
                    m_GuessLinesButtons[m_BullsAndCowsAlgorithm.NumberOfChances].UserGuessButtons.GuessButtons[i].BackColor;
            }
        }

        public void EnabledAll()
        {
            for (int i = 0; i < m_GuessLinesButtons.Length; ++i)
            {
                m_GuessLinesButtons[i].Enabled = false;
            }
        }

        public BullsAndCows BullsAndCowsAlgorithm
        {
            get
            {
                return m_BullsAndCowsAlgorithm;
            }
        }

        public string CurrentSequence
        {
            get
            {
                return m_CurrentSequence;
            }

            set
            {
                m_CurrentSequence = value;
            }
        }
    }
}