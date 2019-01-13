using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class BullsAndCowsUI
    {
        private BullsAndCows m_BullsAndCowsAlgorithm;
        private MainScreenWindow m_MainScreen;

        private int getNumberOfGuessFromUser(int i_MinNumberOfGuess, int i_MaxNumberOfGuess)
        {
            NumberOfGuessWindow numberOfGuessWindow = new NumberOfGuessWindow(i_MinNumberOfGuess, i_MaxNumberOfGuess);

            numberOfGuessWindow.ShowDialog();

            return numberOfGuessWindow.NumberOfChances;
        }

        private void showMainScreen()
        {
            m_MainScreen = new MainScreenWindow(m_BullsAndCowsAlgorithm);
            m_MainScreen.ShowDialog();
        }

        public void StartGame()
        {
            int numberOfGuess;

            numberOfGuess = getNumberOfGuessFromUser(BullsAndCows.k_MinNumberOfGuess, BullsAndCows.k_MaxNumberOfGuess);
            m_BullsAndCowsAlgorithm = new BullsAndCows(numberOfGuess);
            showMainScreen();
        }
    }
}
