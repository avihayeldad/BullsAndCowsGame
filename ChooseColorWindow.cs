using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BullsAndCowsGame
{
    public partial class ChooseColorWindow : Form
    {
        private Button m_PressedButton;
        private Button[] m_ColorsButtons;
        private Color[] m_Colors;
        private EventHandler[] setColorByLetter_Click;

        public ChooseColorWindow(Button i_PressedButton)
        {
            setColorByLetter_Click = new EventHandler[8];
            m_Colors = new Color[8];
            m_ColorsButtons = new Button[8];
            m_PressedButton = i_PressedButton;
            setLettersOfColors();
            setColors();
            this.Text = "Pick a color:";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(290, 185);
            for (int i = 0; i < 8; ++i)
            {
                m_ColorsButtons[i] = new Button();
                m_ColorsButtons[i].Size = new Size(50, 50);
                if (i < 4)
                {
                    m_ColorsButtons[i].Location = new Point((65 * i) + 15, 15);
                }
                else
                {
                    m_ColorsButtons[i].Location = new Point(((65 * i) % 260) + 15, 80);
                }

                m_ColorsButtons[i].BackColor = m_Colors[i];
                m_ColorsButtons[i].Click += new EventHandler(setColorByLetter_Click[i]);
                this.Controls.Add(m_ColorsButtons[i]);
            }

            InitializeComponent();
        }

        private void setByColorLetterA_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[0];
            this.Close();
        }

        private void setByColorLetterB_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[1];
            this.Close();
        }

        private void setByColorLetterC_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[2];
            this.Close();
        }

        private void setByColorLetterD_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[3];
            this.Close();
        }

        private void setByColorLetterE_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[4];
            this.Close();
        }

        private void setByColorLetterF_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[5];
            this.Close();
        }

        private void setByColorLetterG_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[6];
            this.Close();
        }

        private void setByColorLetterH_Click(object sender, EventArgs e)
        {
            m_PressedButton.BackColor = m_Colors[7];
            this.Close();
        }

        private void setColors()
        {
            for (int i = 0; i < 8; ++i)
            {
                m_Colors[i] = new Color();
            }

            m_Colors[0] = Color.Magenta;
            m_Colors[1] = Color.Red;
            m_Colors[2] = Color.Green;
            m_Colors[3] = Color.LightSkyBlue;
            m_Colors[4] = Color.Blue;
            m_Colors[5] = Color.Yellow;
            m_Colors[6] = Color.DarkRed;
            m_Colors[7] = Color.White;
        }

        private void setLettersOfColors()
        {
            setColorByLetter_Click[0] = setByColorLetterA_Click;
            setColorByLetter_Click[1] = setByColorLetterB_Click;
            setColorByLetter_Click[2] = setByColorLetterC_Click;
            setColorByLetter_Click[3] = setByColorLetterD_Click;
            setColorByLetter_Click[4] = setByColorLetterE_Click;
            setColorByLetter_Click[5] = setByColorLetterF_Click;
            setColorByLetter_Click[6] = setByColorLetterG_Click;
            setColorByLetter_Click[7] = setByColorLetterH_Click;
        }

        public void EnabledButtons(UserGuessButtons i_UserGuessButtons)
        {
            foreach (Button currentButton in m_ColorsButtons)
            {
                if (currentButton.BackColor == i_UserGuessButtons.GuessButtons[0].BackColor ||
                    currentButton.BackColor == i_UserGuessButtons.GuessButtons[1].BackColor ||
                    currentButton.BackColor == i_UserGuessButtons.GuessButtons[2].BackColor ||
                    currentButton.BackColor == i_UserGuessButtons.GuessButtons[3].BackColor)
                {
                    currentButton.Enabled = false;
                }
            }
        }
    }
}
