

namespace Loto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Draw
    {
        private static int capacity = 48;
        private string name;
        private static int drawCount;
        private static int[] drawNumbers;
        private static int[] drawNumbersCounter = new int[capacity];

        //Constructor
        public Draw(string Name, int one, int two, int three, int four, int five, int six)
        {
            this.name = Name;
            drawNumbers = new int[6];
            drawNumbers[0] = one;
            drawNumbers[1] = two;
            drawNumbers[2] = three;
            drawNumbers[3] = four;
            drawNumbers[4] = five;
            drawNumbers[5] = six;

            drawCount++;
            NumbersCounter();
        }

        //methods
        public static int[] NumbersCounter()
        {
            for (int i = 1; i <= drawNumbers.Length; i++)
            {
                drawNumbersCounter[drawNumbers[i - 1]]++;
            }
            return drawNumbersCounter;
        }
       
        public static void Print()
        {
            for (int index = 1; index < drawNumbersCounter.Length; index++)
            {
                double percent = (drawCount * drawNumbersCounter[index]) / 100.0;
                
                Console.WriteLine(string.Format("число: {0,-4} изтеглено: {1,3} Процент: {2,3}%", index, drawNumbersCounter[index],percent));
            }
        }
        public static void MostPickedNumbers(int numbersRange)
        {
            if (numbersRange > 0 && numbersRange < 48)
            {
                int[] copy = (int[])drawNumbersCounter.Clone();
                int[] indexes = new int[numbersRange];
                Console.WriteLine("Най-избрани числа са: ");
                for (int i = 0; i < indexes.Length; i++)
                {
                    int maxValue = copy.Max();
                    int maxIndex = copy.ToList().IndexOf(maxValue);
                    copy[maxIndex] = 0;
                    Console.WriteLine(maxIndex + " (" + maxValue + "пъти) ");
                }
                Console.WriteLine();
                Console.WriteLine("Брой изтегляния: " + drawCount);
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                throw new IndexOutOfRangeException("Въведеното число трябва да е от 1 до 47!");
            }
        }

    }
}
 