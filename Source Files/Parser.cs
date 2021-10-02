using System;
using System.Collections.Generic;
using System.Text;

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

            ConvertToPostfix();
            Parse();

            display();
        }

        private void Parse()
        {
            Stack<int> stack = new Stack<int>();

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
            result = stack.Pop();
        }

        private void ConvertToPostfix()
        {
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> operatorStack = new Stack<Token>();

            for (int i = 0; i < _tokens.Count; i++)
            {
                Token token = _tokens[i];
                if (token.getType() == tokenType.numberToken)
                    outputQueue.Enqueue(token);
                else if (token.isOperator() == true)
                {
                    try
                    {
                        while (operatorStack.Peek().getPrecedence() >= token.getPrecedence())
                            outputQueue.Enqueue(operatorStack.Pop());

                        operatorStack.Push(token);

                    }
                    catch (InvalidOperationException)
                    {
                        operatorStack.Push(token);
                    }
                }
            }
            while (operatorStack.Count > 0)
                outputQueue.Enqueue(operatorStack.Pop());

            _tokens.Clear();
            while (outputQueue.Count > 0)
                _tokens.Add(outputQueue.Dequeue());
        }
        public void display()
        {
            Console.Write("[");
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (i < _tokens.Count - 1)
                    Console.Write(_tokens[i].getValue() + ", ");
                else
                    Console.Write(_tokens[i].getValue());
            }
            Console.Write("]");
            Console.WriteLine();

            Console.WriteLine("Result: " + result);
        }
    }
}