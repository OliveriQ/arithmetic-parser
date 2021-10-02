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
        lBracketToken,
        rBracketToken,
        whitespace
    }

    class Token
    {
        private string m_value;
        private tokenType m_type;

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

        public bool isOperator()
        {
            switch (m_type)
            {
                case tokenType.plusToken:
                    return true;

                case tokenType.minusToken:
                    return true;

                case tokenType.multiplyToken:
                    return true;

                case tokenType.divideToken:
                    return true;
            }
            return false;
        }

        public bool isBracket()
        {
            switch (m_type)
            {
                case tokenType.lBracketToken:
                    return true;

                case tokenType.rBracketToken:
                    return true;
            }
            return false;
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

                case tokenType.lBracketToken:
                    return 3;

                case tokenType.rBracketToken:
                    return 3;

                default:
                    return 0;
            }
        }
    }
}