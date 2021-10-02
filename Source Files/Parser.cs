using System;
using System.Collections.Generic;
using System.Text;

namespace arithmeticParser
{
    class Parser
    {
        private List<Token> m_tokens;

        public Parser(string text)
        {
            var lexer = new Lexer(text);
            m_tokens = lexer.getTokens();

            display();
        }
        public void display()
        {
            Console.Write("[");
            for (int i = 0; i < m_tokens.Count; i++)
            {
                if (i < m_tokens.Count - 1)
                    Console.Write(m_tokens[i].getValue() + ", ");
                else
                    Console.Write(m_tokens[i].getValue());
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}