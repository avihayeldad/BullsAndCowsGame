using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCowsGame
{
    internal partial class NumberOfGuessWindow : Form
    {
        private Button m_ButtonStart;
        private Button m_ButtonChangeChancesNumber;
        private int m_minNumberOfGuess;
        private int m_maxNumberOfGuess;
        private int m_NumberOfChances;

        public NumberOfGuessWindow(int i_MinNumberOfGuess, int i_MaxNumberOfGuess)
        {
            m_minNumberOfGuess = i_MinNumberOfGuess;
            m_maxNumberOfGuess = i_MaxNumberOfGuess;
            m_NumberOfChances = m_minNumberOfGuess;
            this.Text = "Bool Pgia";
            this.Size = new Size(300, 170);
            this.StartPosition = FormStartPosition.CenterScreen;

            m_ButtonStart = new Button();
            m_ButtonStart.Location = new Point(190, 100);
            m_ButtonStart.Text = "Start";
            this.Controls.Add(m_ButtonStart);

            m_ButtonChangeChancesNumber = new Button();
            m_ButtonChangeChancesNumber.Location = new Point(40, 40);
            m_ButtonChangeChancesNumber.Text = "Number of chances: " + m_minNumberOfGuess.ToString();
            m_ButtonChangeChancesNumber.Width = 200;
            this.Controls.Add(m_ButtonChangeChancesNumber);

            m_ButtonChangeChancesNumber.Click += new EventHandler(buttonChangeChancesNumber_Click);
            m_ButtonStart.Click += new EventHandler(buttonStart_Click);
            InitializeComponent();
        }

        private void buttonChangeChancesNumber_Click(object sender, EventArgs e)
        {
            if (m_NumberOfChances < m_maxNumberOfGuess)
            {
                ++m_NumberOfChances;
                m_ButtonChangeChancesNumber.Text = "Number of chances: " + m_NumberOfChances.ToString();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int NumberOfChances
        {
            get
            {
                return m_NumberOfChances;
            }

            set
            {
                m_NumberOfChances = value;
            }
        }

        public int minNumberOfGuess
        {
            get
            {
                return m_minNumberOfGuess;
            }

            set
            {
                m_minNumberOfGuess = value;
            }
        }

        public int maxNumberOfGuess
        {
            get
            {
                return m_maxNumberOfGuess;
            }

            set
            {
                m_maxNumberOfGuess = value;
            }
        }
    }
}
