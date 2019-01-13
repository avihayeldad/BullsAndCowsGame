using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCowsGame
{
    public class GuessLineButtons : UserControl
    {
        private int m_GuessLineButtonsIndex;
        private Button m_CheckGuessButton;
        private UserGuessButtons m_UserGuessButtons;
        private ResultButtons m_ResultButtons;
        private MainScreenWindow m_MainScreenWindow;

        public GuessLineButtons(MainScreenWindow i_MainScreenWindow, int i_GuessLineButtonsIndex)
        {
            m_GuessLineButtonsIndex = i_GuessLineButtonsIndex;
            m_MainScreenWindow = i_MainScreenWindow;        
            m_ResultButtons = new ResultButtons();
            m_ResultButtons.Location = new Point(320, 5);
            m_CheckGuessButton = new Button();
            m_CheckGuessButton.Location = new Point(260, 15);
            m_CheckGuessButton.Size = new Size(50, 20);
            m_CheckGuessButton.Text = "-->>";
            m_CheckGuessButton.Enabled = false;
            m_CheckGuessButton.Click += checkGuessButtons_Click;
            m_UserGuessButtons = new UserGuessButtons();
            m_UserGuessButtons.Location = new Point(0, 0);
            for (int i = 0; i < 4; ++i)
            {
                UserGuessButtons.GuessButtons[i].Click += guessLinesButtons_Click;
            }

            this.Size = new Size(360, 50);
            this.Controls.Add(m_UserGuessButtons);
            this.Controls.Add(m_CheckGuessButton);
            this.Controls.Add(m_ResultButtons);
        }

        private void guessLinesButtons_Click(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.WhiteSmoke;
            ChooseColorWindow ChooseColorWindow = new ChooseColorWindow(sender as Button);
            ChooseColorWindow.EnabledButtons(m_UserGuessButtons);
            ChooseColorWindow.ShowDialog();
            if (UserGuessButtons.GuessButtons[0].BackColor != Color.WhiteSmoke &&
                UserGuessButtons.GuessButtons[1].BackColor != Color.WhiteSmoke &&
                UserGuessButtons.GuessButtons[2].BackColor != Color.WhiteSmoke &&
                UserGuessButtons.GuessButtons[3].BackColor != Color.WhiteSmoke &&
                m_MainScreenWindow.BullsAndCowsAlgorithm.NumberOfChances == m_GuessLineButtonsIndex &&
                m_MainScreenWindow.BullsAndCowsAlgorithm.UserIsGuessedRight == false)
            {
                m_CheckGuessButton.Enabled = true;
            }
        }

        private void checkGuessButtons_Click(object sender, EventArgs e)
        {
            bool sequenceIsRight;

            this.Enabled = false;
            m_MainScreenWindow.CurrentSequence = colorToLetterConvertor(UserGuessButtons.GuessButtons[0].BackColor) +
                colorToLetterConvertor(UserGuessButtons.GuessButtons[1].BackColor) +
                colorToLetterConvertor(UserGuessButtons.GuessButtons[2].BackColor) +
                colorToLetterConvertor(UserGuessButtons.GuessButtons[3].BackColor);
            sequenceIsRight = m_MainScreenWindow.BullsAndCowsAlgorithm.CheckAndStorecurrentUserSequence(m_MainScreenWindow.CurrentSequence);
            paintIndicatorButton(m_MainScreenWindow.BullsAndCowsAlgorithm.RoundMemoryArray[m_MainScreenWindow.BullsAndCowsAlgorithm.NumberOfChances]);
            if (sequenceIsRight)
            {
                m_MainScreenWindow.PaintHiddenSequenceButtons();
                m_MainScreenWindow.BullsAndCowsAlgorithm.UserIsGuessedRight = true;
                m_MainScreenWindow.EnabledAll();
            }
            else
            {
                ++m_MainScreenWindow.BullsAndCowsAlgorithm.NumberOfChances;
            }
        }

        private string colorToLetterConvertor(Color i_ButtonColor)
        {
            string letter = string.Empty;

            if (i_ButtonColor == Color.Magenta)
            {
                letter = "A";
            }
            else if (i_ButtonColor == Color.Red)
            {
                letter = "B";
            }
            else if (i_ButtonColor == Color.Green)
            {
                letter = "C";
            }
            else if (i_ButtonColor == Color.LightSkyBlue)
            {
                letter = "D";
            }
            else if (i_ButtonColor == Color.Blue)
            {
                letter = "E";
            }
            else if (i_ButtonColor == Color.Yellow)
            {
                letter = "F";
            }
            else if (i_ButtonColor == Color.DarkRed)
            {
                letter = "G";
            }
            else if (i_ButtonColor == Color.White)
            {
                letter = "H";
            }

            return letter;
        }

        public UserGuessButtons UserGuessButtons
        {
            get
            {
                return m_UserGuessButtons;
            }

            set
            {
                m_UserGuessButtons = value;
            }
        }

        public Button CheckGuessButton
        {
            get
            {
                return m_CheckGuessButton;
            }

            set
            {
                m_CheckGuessButton = value;
            }
        }

        public ResultButtons ResultButtons
        {
            get
            {
                return m_ResultButtons;
            }

            set
            {
                m_ResultButtons = value;
            }
        }

        private void paintIndicatorButton(RoundMemory i_RoundMemoryArray)
        {
            int countV = i_RoundMemoryArray.NumberOfV;
            int countX = i_RoundMemoryArray.NumberOfX;

            for (int i = 0; i < 4; ++i)
            {
                if (countV + countX > 0)
                {
                    if (countV > 0)
                    {
                        ResultButtons.Buttons[i].BackColor = Color.Black;
                        --countV;
                    }
                    else
                    {
                        ResultButtons.Buttons[i].BackColor = Color.Yellow;
                        --countX;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
