using System;
using System.Collections.Generic;

namespace arithmeticParser
{
    class Parser
    {
        private List<Token> _tokens;
        private int result;

        public Parser(string text)
        {
            var lexer = new Lexer(text);
            _tokens = lexer.getTokens();

            Parse();
        }
        private void Parse()
        {
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> operatorStack = new Stack<Token>();

            for (int i = 0; i < _tokens.Count; i++)
            {
                Token token = _tokens[i];

                if (token.getType() == tokenType.exponentToken)
                {
                    Token Base = _tokens[i - 1];
                    Token Exponent = _tokens[i + 1];

                    _tokens.RemoveRange(i, 2);

                    for (int j = 0; j < Int32.Parse(Exponent.getValue()) - 1; j++)
                    {
                        _tokens.Insert(i, Base);
                        _tokens.Insert(i, new Token(tokenType.multiplyToken, "*"));
                    }

                    i--;
                }

                if (token.getType() == tokenType.numberToken)
                    outputQueue.Enqueue(token);

                else if (token.isOperator() == true)
                {
                    try
                    {
                        while (operatorStack.Peek().getPrecedence() >= token.getPrecedence() &&
                                operatorStack.Peek().isBracket() == false)
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
                else if (token.getType() == tokenType.lBracketToken)
                    operatorStack.Push(token);

                else if (token.getType() == tokenType.rBracketToken)
                {
                        while (operatorStack.Peek().getType() != tokenType.lBracketToken)
                            outputQueue.Enqueue(operatorStack.Pop());

                    operatorStack.Pop();
                }
            }
            while (operatorStack.Count > 0)
                outputQueue.Enqueue(operatorStack.Pop());

            _tokens.Clear();
            while (outputQueue.Count > 0)
                _tokens.Add(outputQueue.Dequeue());
        }

        public List<Token> getTokens()
        {
            return _tokens;
        }
    }
}