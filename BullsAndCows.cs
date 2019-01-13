using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class BullsAndCows
    {
        public const int k_MinNumberOfGuess = 4;
        public const int k_MaxNumberOfGuess = 10;
        public const int k_SequenceLength = 4;
        public const char k_FirstLetter = 'A';
        public const char k_LastLetter = 'H';
        public const char k_ExitSign = 'Q';
        private bool m_UserIsGuessedRight;
        private int m_TotalGuessNumber;
        private int m_NumberOfChances;
        private string m_HiddenSequence;
        private RoundMemory[] m_RoundMemoryArray;

        public BullsAndCows(int i_NumberOfGuess)
        {
            m_UserIsGuessedRight = false;
            m_HiddenSequence = getRandomSequence();
            m_TotalGuessNumber = i_NumberOfGuess;
            m_RoundMemoryArray = new RoundMemory[m_TotalGuessNumber];
        }

        private string getRandomSequence()
        {
            StringBuilder sequence = new StringBuilder();
            int amountOfLetter;
            char[] allLetters;
            char updateLetter = k_FirstLetter;

            amountOfLetter = (int)k_LastLetter - (int)k_FirstLetter + 1;
            allLetters = new char[amountOfLetter];
            for (int i = 0; i < amountOfLetter; ++i)
            {
                allLetters[i] = updateLetter;
                ++updateLetter;
            }

            Random randomObject = new Random();
            for (int i = 0; i < k_SequenceLength; ++i)
            {
                char currentLetter;
                int randomNumber = randomObject.Next(0, amountOfLetter);
                currentLetter = allLetters[randomNumber];
                allLetters[randomNumber] = allLetters[amountOfLetter - 1];
                allLetters[amountOfLetter - 1] = currentLetter;
                --amountOfLetter;
                sequence.Insert(0, currentLetter);
            }

            return sequence.ToString();
        }

        public bool CheckAndStorecurrentUserSequence(string i_SequenceToCheck)
        {
            m_RoundMemoryArray[m_NumberOfChances] = new RoundMemory();
            m_RoundMemoryArray[m_NumberOfChances].Sequence = i_SequenceToCheck;
            for (int i = 0; i < k_SequenceLength; ++i)
            {
                for (int j = 0; j < k_SequenceLength; ++j)
                {
                    if (i_SequenceToCheck[i] == m_HiddenSequence[j])
                    {
                        if (i == j)
                        {
                            m_RoundMemoryArray[m_NumberOfChances].NumberOfV++;
                        }
                        else
                        {
                            m_RoundMemoryArray[m_NumberOfChances].NumberOfX++;
                        }
                    }
                }
            }

            return m_RoundMemoryArray[m_NumberOfChances].NumberOfV == 4;
        }

        public int TotalGuessNumber
        {
            get
            {
                return m_TotalGuessNumber;
            }

            set
            {
                m_TotalGuessNumber = value;
            }
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

        public RoundMemory[] RoundMemoryArray
        {
            get
            {
                return m_RoundMemoryArray;
            }

            set
            {
                m_RoundMemoryArray = value;
            }
        }

        public string HiddenSequence
        {
            get
            {
                return m_HiddenSequence;
            }

            set
            {
                m_HiddenSequence = value;
            }
        }

        public bool UserIsGuessedRight
        {
            get
            {
                return m_UserIsGuessedRight;
            }

            set
            {
                m_UserIsGuessedRight = value;
            }
        }      
    }
}
