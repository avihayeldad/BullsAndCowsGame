using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public class RoundMemory
    {
        public const char k_VSign = 'V';
        public const char k_XSign = 'X';
        private string m_Sequence;
        private int m_NumberOfX;
        private int m_NumberOfV;

        public RoundMemory()
        {
            m_Sequence = null;
            m_NumberOfX = 0;
            m_NumberOfV = 0;
        }

        public int NumberOfX
        {
            get
            {
                return m_NumberOfX;
            }

            set
            {
                m_NumberOfX = value;
            }
        }

        public int NumberOfV
        {
            get
            {
                return m_NumberOfV;
            }

            set
            {
                m_NumberOfV = value;
            }
        }

        public string Sequence
        {
            get
            {
                return m_Sequence;
            }

            set
            {
                m_Sequence = value;
            }
        }
    }
}
