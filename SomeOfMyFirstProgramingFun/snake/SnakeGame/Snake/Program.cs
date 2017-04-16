namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Program
    {
        private const byte Right = 0;
        private const byte Left = 1;
        private const byte Down = 2;
        private const byte Up = 3;
        private const int SpeedIncreaser = 1;
        private const char SnakeBodyElement = '0';
        private const char SnakeFoodElement = 'Q';
        private const ConsoleColor AppleColor = ConsoleColor.Red;
        private const ConsoleColor EndGameColor = ConsoleColor.Yellow;
        private const ConsoleColor SnakeColor = ConsoleColor.Green;

        private static long gameScore = 0;
        private static byte direction = 0;
        private static int gameSpeed = 200;

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
                Console.ForegroundColor = SnakeColor;
                DrawingManager(position, SnakeBodyElement);
            }

            var randomNumberGenerator = new Random();

            var food = new Position(
                randomNumberGenerator.Next(0, Console.WindowWidth),
                randomNumberGenerator.Next(0, Console.WindowHeight));

            Console.ForegroundColor = AppleColor;
            DrawingManager(food, SnakeFoodElement);

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
                    Console.ForegroundColor = EndGameColor;
                    Console.WriteLine("Game over!");
                    Console.WriteLine("Your score is {0}", gameScore);
                    Console.ReadLine();
                    return;
                }

                snakeBody.Enqueue(newHead);
                Console.ForegroundColor = SnakeColor;
                DrawingManager(newHead, SnakeBodyElement);

                // eating the food
                if (snakeBody.Contains(food))
                {
                    food = new Position(
                        randomNumberGenerator.Next(0, Console.WindowWidth),
                        randomNumberGenerator.Next(0, Console.WindowHeight));

                    Console.ForegroundColor = AppleColor;
                    DrawingManager(food, SnakeFoodElement);

                    gameScore += 100;

                    if (gameSpeed - SpeedIncreaser < 0)
                    {
                        gameSpeed = 0;
                    }
                    else
                    {
                        gameSpeed -= SpeedIncreaser;
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
                        if (previousDirection != Right)
                        {
                            result = Left;
                        }

                        break;
                    }

                case ConsoleKey.UpArrow:
                    {
                        if (previousDirection != Down)
                        {
                            result = Up;
                        }

                        break;
                    }

                case ConsoleKey.RightArrow:
                    {
                        if (previousDirection != Left)
                        {
                            result = Right;
                        }

                        break;
                    }

                case ConsoleKey.DownArrow:
                    {
                        if (previousDirection != Up)
                        {
                            result = Down;
                        }

                        break;
                    }
            }

            return result;
        }
    }
}
