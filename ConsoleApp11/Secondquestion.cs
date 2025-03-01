using System;

namespace ConsoleApp11
{
    internal class Secondquestion
    {
        static void Main(string[] args)
        {
            string text = "Code Academy";
            int vowelCount = CountVowels(text);
            Console.WriteLine($"Number of vowels in {text}: {vowelCount}");
        }

        public static int CountVowels(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if ("aeiou".Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
