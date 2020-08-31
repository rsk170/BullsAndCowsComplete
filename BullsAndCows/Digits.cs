using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCowsComplete
{
    public class Digits
    {
        public static bool HasUniqueDigits(string possibility)
        {
            for (int i = 0; i < 3; i++) 
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (possibility[i] == possibility[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static string GetRandomNumber()
        {
            string possibility;
            do
            {
                possibility = GeneratePossibleNumber();
            } while (!HasUniqueDigits(possibility));

            return possibility;
        }

        private static string GeneratePossibleNumber()
        {
            Random random = new Random();
            string possibility = "";
            for (int i = 0; i < 4; i++)
            {
                possibility += random.Next(1, 9).ToString();
            }

            return possibility;
        }

        public static List<string> GetAllUniqueNumbers()
        {
            List<string> numbers = new List<string>();
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    if (a == b)
                        continue;

                    for (int c = 1; c <= 9; c++)
                    {
                        if (a == c || b == c)
                            continue;
                        for (int d = 1; d <= 9; d++)
                        {
                            if (a == d || b == d || c == d)
                                continue;
                            string number = a.ToString() + b.ToString() + c.ToString() + d.ToString();
                            numbers.Add(number);
                        }
                    }
                }
            }

            return numbers;
        }

        public static string GetPossibleAnswer(List<string> numbers)
        {
            var random = new Random().Next(numbers.Count);
            string currentGuess = numbers[random];
            Console.WriteLine(currentGuess);
            return currentGuess;
        }
    }
}