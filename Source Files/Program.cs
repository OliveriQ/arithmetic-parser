using System;

namespace arithmeticParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text;
            
            while (true)
            {
                Console.Write("> ");
                text = Console.ReadLine();

                var parser = new Parser(text);
            }
        }
    }
}
