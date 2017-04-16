namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Program
    {
        private static byte direction = 0;
        private static byte right = 0;
        private static byte left = 1;
        private static byte down = 2;
        private static byte up = 3;
        private static int speedIncreaser = 1;
        private static int gameSpeed = 200;
        private static char snakeBodyElement = '0';
        private static char snakeFoodElement = 'Q';
        private static long gameScore = 0;
        private static ConsoleColor appleColor = ConsoleColor.Red;
        private static ConsoleColor endGameColor = ConsoleColor.Yellow;
        private static ConsoleColor snakeColor = ConsoleColor.Green;

        public static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Queue<Position> snakeBody = new Queue<Position>();

            Position[] directions =
            {
            new Position(1, 0), // right
            new Position(-1, 0), // left
            new Position(0, 1), // down
            new Position(0, -1), // up
            };

            for (int i = 0; i < 5; i++)
            {
                snakeBody.Enqueue(new Position(i, 0));
            }

            foreach (Position position in snakeBody)
            {
                Console.ForegroundColor = snakeColor;
                DrawingManager(position, snakeBodyElement);
            }

            var randomNumberGenerator = new Random();

            var food = new Position(
                randomNumberGenerator.Next(0, Console.WindowWidth),
                randomNumberGenerator.Next(0, Console.WindowHeight));

            Console.ForegroundColor = appleColor;
            DrawingManager(food, snakeFoodElement);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var input = Console.ReadKey().Key;

                    direction = DirectionSelecter(input, direction);
                }

                var currentHead = snakeBody.Last();
                var newHead = new Position(
                    currentHead.Col + directions[direction].Col,
                    currentHead.Row + directions[direction].Row);

                if (newHead.Col < 0)
                {
                    newHead.Col = Console.WindowWidth - 1;
                }

                if (newHead.Col >= Console.WindowWidth)
                {
                    newHead.Col = 0;
                }

                if (newHead.Row < 0)
                {
                    newHead.Row = Console.WindowHeight - 1;
                }

                if (newHead.Row >= Console.WindowHeight)
                {
                    newHead.Row = 0;
                }

                // ending the game afther collision with body
                if (snakeBody.Contains(newHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = endGameColor;
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Your score is {0}", gameScore);
                    Console.ReadLine();
                    return;
                }

                snakeBody.Enqueue(newHead);
                Console.ForegroundColor = snakeColor;
                DrawingManager(newHead, snakeBodyElement);

                // eating the food
                if (snakeBody.Contains(food))
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowWidth),
                        randomNumberGenerator.Next(0, Console.WindowHeight));

                    Console.ForegroundColor = appleColor;
                    DrawingManager(food, snakeFoodElement);

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
                    DrawingManager(lastElement, ' ');
                }

                Thread.Sleep(gameSpeed);
            }
        }

        private static void DrawingManager(Position position, char writingElement)
        {
            Console.SetCursorPosition(position.Col, position.Row);
            Console.Write(writingElement);
        }

        private static byte DirectionSelecter(ConsoleKey input, byte previousDirection)
        {
            byte result = previousDirection;

            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (previousDirection != right)
                        {
                            result = left;
                        }

                        break;
                    }

                case ConsoleKey.UpArrow:
                    {
                        if (previousDirection != down)
                        {
                            result = up;
                        }

                        break;
                    }

                case ConsoleKey.RightArrow:
                    {
                        if (previousDirection != left)
                        {
                            result = right;
                        }

                        break;
                    }

                case ConsoleKey.DownArrow:
                    {
                        if (previousDirection != up)
                        {
                            result = down;
                        }

                        break;
                    }
            }

            return result;
        }
    }
}
