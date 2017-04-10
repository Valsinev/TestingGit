using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Snake
{
    class Program
    {
        private static byte direction;
        private static byte down = 0;
        private static byte up = 1;
        private static byte left = 2;
        private static byte right = 3;
        private static int speedIncreaser = 4;
        private static int gameSpeed = 200;

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Queue<Position> snakeBody = new Queue<Position>();

            Position[] directions =
            {
            new Position(0, 1),
            new Position(0, -1),
            new Position(-1, 0),
            new Position(1, 0)
            };

            for (int i = 0; i < 5; i++)
            {
                snakeBody.Enqueue(new Position(i, 0));
            }

            Position nextPosition;

            foreach (Position position in snakeBody)
            {
                nextPosition = position;
                Console.SetCursorPosition(nextPosition.Col, nextPosition.Row);
                Console.Write("*");
            }

            var randomNumberGenerator = new Random();

            var food = new Position(
                randomNumberGenerator.Next(0, Console.WindowWidth),
                randomNumberGenerator.Next(0, Console.WindowHeight));
            Console.SetCursorPosition(food.Col, food.Row);
            Console.Write("Q");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    //moving the snake
                    var input = Console.ReadKey().Key;

                    if (input == ConsoleKey.RightArrow)
                    {
                        if (direction != left) direction = right;
                    }
                    if (input == ConsoleKey.LeftArrow)
                    {
                        if (direction != right) direction = left;
                    }
                    if (input == ConsoleKey.UpArrow)
                    {
                        if (direction != down) direction = up;
                    }
                    if (input == ConsoleKey.DownArrow)
                    {
                        if (direction != up) direction = down;
                    }
                }

                var currentHead = snakeBody.Last();
                var newHead = new Position(
                    currentHead.Col + directions[direction].Col,
                    currentHead.Row + directions[direction].Row);
                snakeBody.Enqueue(newHead);

                Console.SetCursorPosition(newHead.Col, newHead.Row);
                Console.Write("#");

                //eating the food
                if (snakeBody.Contains(food))
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowWidth),
                        randomNumberGenerator.Next(0, Console.WindowHeight));

                    Console.SetCursorPosition(food.Col, food.Row);
                    Console.Write("Q");

                    if (gameSpeed - speedIncreaser < 0)
                    {
                        gameSpeed = 0;
                    }
                    else
                    {
                        gameSpeed -= speedIncreaser;
                    }
                }
                else
                {
                    var lastElement = snakeBody.Dequeue();
                    Console.SetCursorPosition(lastElement.Col, lastElement.Row);
                    Console.Write(" ");
                }

                Thread.Sleep(gameSpeed);
            }
        }
    }
}
