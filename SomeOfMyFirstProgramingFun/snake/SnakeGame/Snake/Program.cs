using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var nextPosition = new Position(0, 0);

            Queue<Position> body = new Queue<Position>();

            for (int i = 0; i < 5; i++)
            {
                body.Enqueue(new Position(i, 0));
            }

            foreach (Position position in body)
            {
                nextPosition = position;
                Console.SetCursorPosition(nextPosition.Col, nextPosition.Row);
                Console.Write("o");
            }

            while (true)
            {
                //moving the snake
                var input = Console.ReadKey().Key;
                nextPosition = new Position(
                    nextPosition.Col + Direction(input).Col,
                    nextPosition.Row + Direction(input).Row);



                Console.SetCursorPosition(nextPosition.Col, nextPosition.Row);
                Console.Write("o");
            }
        }
        public static Position Direction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    {
                        return new Position(0, 1);
                    }
                case ConsoleKey.UpArrow:
                    {
                        return new Position(0, -1);
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return new Position(-1, 0);
                    }
                case ConsoleKey.RightArrow:
                    {
                        return new Position(1, 0);
                    }
                default:
                    throw new ArgumentException("No sutch direction");
            }
        }
    }
}
