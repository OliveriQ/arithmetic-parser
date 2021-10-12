using System;
using System.Collections.Generic;
using System.Text;

namespace arithmeticParser
{
    class Interpreter
    {
        private List<Token> _tokens;
        private int _result;

        public Interpreter(string text)
        {
            var parser = new Parser(text);
            _tokens = parser.getTokens();

            Execute();
            display();
        }

        private void Execute()
        {
            var stack = new Stack<int>();

            for (int i = 0; i < _tokens.Count; i++)
            {
                Token token = _tokens[i];

                if (token.getType() == tokenType.numberToken)
                    stack.Push(Int32.Parse(token.getValue()));
                else
                {
                    int a = stack.Pop(), b = stack.Pop(), c = 0;

                    switch (token.getValue())
                    {
                        case "+":
                            c = a + b;
                            break;

                        case "-":
                            c = b - a;
                            break;

                        case "*":
                            c = a * b;
                            break;

                        case "/":
                            c = b / a;
                            break;
                    }

                    stack.Push(c);
                }
            }
            
            _result = stack.Pop();
        }

        public void display()
        {
            Console.WriteLine(_result);
        }
    }
}
