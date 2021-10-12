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
        exponentToken,
        lBracketToken,
        rBracketToken,
        whitespace
    }

    class Token
    {
        private string _value;
        private tokenType _type;

        public Token(tokenType type, string value)
        {
            _type = type;
            _value = value;
        }

        public string getValue()
        {
            return _value;
        }

        public tokenType getType()
        {
            return _type;
        }

        public bool isOperator()
        {
            switch (_type)
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
            switch (_type)
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
            switch (_type)
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
