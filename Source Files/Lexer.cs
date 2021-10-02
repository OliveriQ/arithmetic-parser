using System;
using System.Collections.Generic;
using System.Text;

namespace arithmeticParser
{
    class Lexer
    {
        private string _text;
        private int _endOfText;

        private List<Token> _tokens = new List<Token>();

        public Lexer(string text)
        {
            _text = text;
            _endOfText = text.Length;

            Tokenize();
            ConvertToPostfix();
        }

        private void ConvertToPostfix() // shunting-yard algorithm
        {
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> operatorStack = new Stack<Token>();

            for (int i = 0; i < _tokens.Count; i++)
            {
                Token token = _tokens[i];
                if (token.getType() == tokenType.numberToken)
                    outputQueue.Enqueue(token);
                else if (token.getType() == tokenType.plusToken || token.getType() == tokenType.minusToken ||
                        token.getType() == tokenType.multiplyToken || token.getType() == tokenType.divideToken)
                {
                    try
                    {
                        while (operatorStack.Peek().getPrecedence() >= token.getPrecedence())
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }
                        operatorStack.Push(token);

                    }
                    catch (InvalidOperationException)
                    {
                        operatorStack.Push(token);
                    }
                }
            }
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            _tokens.Clear();
            while (outputQueue.Count > 0)
            {
                _tokens.Add(outputQueue.Dequeue());
            }
        }

        private void Tokenize(tokenType type = tokenType.whitespace, int index = 0, string pToken = "")
        {
            if (index == _endOfText)
            {
                if (type == tokenType.numberToken)
                    addToken(pToken, tokenType.numberToken);

                return;
            }

            string token = Char.ToString(_text[index]);

            if (Char.IsDigit(char.Parse(token)) && type == tokenType.numberToken)
                Tokenize(tokenType.numberToken, index + 1, pToken + token);

            else if (!Char.IsDigit(char.Parse(token)) && type == tokenType.numberToken)
            {
                addToken(pToken, tokenType.numberToken);
                Tokenize(tokenType.whitespace, index);
            }
            else if (Char.IsDigit(char.Parse(token)))
                Tokenize(tokenType.numberToken, index + 1, token);

            else if (token == "+")
            {
                addToken(token, tokenType.plusToken);
                Tokenize(tokenType.plusToken, index + 1);
            }
            else if (token == "-")
            {
                addToken(token, tokenType.minusToken);
                Tokenize(tokenType.minusToken, index + 1);
            }
            else if (token == "*")
            {
                addToken(token, tokenType.multiplyToken);
                Tokenize(tokenType.multiplyToken, index + 1);
            }
            else if (token == "/")
            {
                addToken(token, tokenType.divideToken);
                Tokenize(tokenType.divideToken, index + 1);
            }

            else if (token == " ")
                Tokenize(tokenType.whitespace, index + 1);
        }
        private void addToken(string value, tokenType type)
        {
            _tokens.Add(new Token(type, value));
        }

        public List<Token> getTokens()
        {
            return _tokens;
        }
    }
}