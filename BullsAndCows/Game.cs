using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BullsAndCowsComplete
{
    public class Game
    {
        private readonly string _secret;
        private readonly List<string> _numbers = new List<string>();

        public Game()
        {
            _secret = Digits.GetRandomNumber();
            _numbers = Digits.GetAllUniqueNumbers();
        }

        public void PlayGame()
        {
            string guess;

            Console.WriteLine($"The secret number is {_secret}");
            while (true)
            {
                Console.Write("The guess number is: ");
                guess = Digits.GetPossibleAnswer(_numbers);

                System.Threading.Thread.Sleep(1000);
                var counts = CountBullsAndCows(guess, _secret);
                Console.WriteLine($"{counts.Bulls} bulls");
                Console.WriteLine($"{counts.Cows} cows");

                if (counts.Bulls == 4)
                {
                    Console.WriteLine("Congratulations! You won!");
                    Console.WriteLine($"The number is {guess}");
                    break;
                }

                ModifyList(_numbers, guess, counts.Cows, counts.Bulls);
                Console.WriteLine($"There are {_numbers.Count} possible numbers remaining.");
                System.Threading.Thread.Sleep(4000);
            }
        }

        public void ModifyList(List<string> numbers, string currentGuess, int cowsCount, int bullsCount)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (cowsCount == 0 && bullsCount == 0)
                {
                    for (int j = 0; j < currentGuess.Length; j++)
                    {
                        char currentDigit = currentGuess[j];
                        numbers.RemoveAll(u => u.Contains(currentDigit));
                    }
                }
                else if (bullsCount == 0)
                {
                    for (int j = 0; j < currentGuess.Length; j++)
                    {
                        char currentDigit = currentGuess[j];

                        numbers.RemoveAll(u => u.IndexOf(currentDigit) == j);
                    }
                }
                else
                {
                    var counts =  CountBullsAndCows(currentGuess, numbers[i]);
                    if (counts.Cows != cowsCount && counts.Bulls != bullsCount)
                    {
                        numbers.Remove(numbers[i]);
                        i--;
                    }
                }
            }

            numbers.Remove(currentGuess);
        }

        public BullsAndCowsCount CountBullsAndCows(string currentGuess, string currentNumber)
        {
            int bulls = 0, cows = 0;
            for (int j = 0; j < currentGuess.Length; j++)
            {
                char currentDigit = currentGuess[j];

                int index = currentNumber.IndexOf(currentDigit);
                if (index == j)
                {
                    bulls++;
                }
                else if (index >= 0)
                {
                    cows++;
                }
            }

            return new BullsAndCowsCount(bulls, cows);
        }
    }
}
