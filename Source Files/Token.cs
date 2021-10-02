using System;
using System.Collections.Generic;
using System.Text;

namespace arithmeticParser
{
    enum tokenType
    {
        numberToken,
        plusToken,
        minusToken,
        multiplyToken,
        divideToken,
        whitespace
    }

    class Token
    {
        private string m_value;
        private tokenType m_type;

        public Token left = null;
        public Token right = null;

        public Token(tokenType type, string value)
        {
            m_type = type;
            m_value = value;
        }

        public string getValue()
        {
            return m_value;
        }

        public tokenType getType()
        {
            return m_type;
        }
        public int getPrecedence()
        {
            switch (m_type)
            {
                case tokenType.plusToken:
                    return 1;

                case tokenType.minusToken:
                    return 1;

                case tokenType.multiplyToken:
                    return 2;

                case tokenType.divideToken:
                    return 2;

                default:
                    return 0;
            }
        }
    }
}