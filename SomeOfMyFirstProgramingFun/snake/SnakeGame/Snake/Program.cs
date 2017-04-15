using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Snake
{
    public class Program
    {
        private static byte direction;
        private static byte right = 0;
        private static byte left = 1;
        private static byte down = 2;
        private static byte up = 3;
        private static int speedIncreaser = 1;
        private static int gameSpeed = 200;
        private static char snakeBodyElement = '0';
        private static char snakeFoodElement = 'Q';
        private static long gameScore = 0;

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Queue<Position> snakeBody = new Queue<Position>();

            Position[] directions =
            {
            new Position(1, 0), // right
            new Position(-1, 0), //left
            new Position(0, 1), //down
            new Position(0, -1), //up
            };

            for (int i = 0; i < 5; i++)
            {
                snakeBody.Enqueue(new Position(i, 0));
            }

            foreach (Position position in snakeBody)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.Write(snakeBodyElement);
            }

            var randomNumberGenerator = new Random();

            var food = new Position(
                randomNumberGenerator.Next(0, Console.WindowWidth),
                randomNumberGenerator.Next(0, Console.WindowHeight));
            Console.SetCursorPosition(food.Col, food.Row);
            Console.Write(snakeFoodElement);

            while (true)
            {
                if (Console.KeyAvailable)
                {
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

                if (newHead.Col < 0) newHead.Col = Console.WindowWidth - 1;
                if (newHead.Col >= Console.WindowWidth) newHead.Col = 0;
                if (newHead.Row < 0) newHead.Row = Console.WindowHeight - 1;
                if (newHead.Row >= Console.WindowHeight) newHead.Row = 0;

                //ending the gameafther collision
                if (snakeBody.Contains(newHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Your score is {0}", gameScore);
                    Console.ReadLine();
                    return;
                }

                snakeBody.Enqueue(newHead);
                Console.SetCursorPosition(newHead.Col, newHead.Row);
                Console.Write(snakeBodyElement);

                //eating the food
                if (snakeBody.Contains(food))
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowWidth),
                        randomNumberGenerator.Next(0, Console.WindowHeight));

                    Console.SetCursorPosition(food.Col, food.Row);
                    Console.Write(snakeFoodElement);

                    gameScore += 100;

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
