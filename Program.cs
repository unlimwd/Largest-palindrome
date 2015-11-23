using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "afabcdcbatsf";
            Console.WriteLine("S = " + S);
            List<string> Palindromes = new List<string>();

            for (int StartPosition = 0; StartPosition <= S.Length - 1; StartPosition++)
            {
                for (int StopPosition = S.Length - 1; StopPosition >= StartPosition; StopPosition--)
                {
                    string MayBePalindrome = TakeSubstring(S, StartPosition, StopPosition);
                    Console.WriteLine("StartPosition = {0}, StopPosition = {1}, MayBePalindrome = {2}", StartPosition, StopPosition, MayBePalindrome);
                    if (IsSubstringPalindrome(MayBePalindrome))
                    {
                        Palindromes.Add(MayBePalindrome);
                        Console.WriteLine("It's a palindrome");
                    }
                    else Console.WriteLine("It isn't a palindrome");

                    if (StartPosition == StopPosition)
                    {
                        StopPosition = StartPosition - 1;    //go out from cycle
                    }
                }
            }

            int MaxLengthOfPalindrome = 0;
            foreach(string str in Palindromes)
            {
                if (str.Length > MaxLengthOfPalindrome)
                    MaxLengthOfPalindrome = str.Length;
            }

            int SourcePalindromesListCount = Palindromes.Count;
            for (int i = SourcePalindromesListCount - 1; i >= 0; i--)//use reverse cycle, 
                                                                     //because we need walkthrough all elements of list, and we must be able to del elements in cycle body
            {
                if (Palindromes[i].Length < MaxLengthOfPalindrome)
                    Palindromes.Remove(Palindromes[i]);
            }

            if (MaxLengthOfPalindrome > 1)
            {
                Console.WriteLine("Maximal length of palindrome is {0}. This is (are):", MaxLengthOfPalindrome);
                Palindromes.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("There aren't palindromes in S");
            }
            Console.ReadLine();
        }

        static bool IsSubstringPalindrome(string Str)//if Str is not palindtome function must returns false
        {
            for (int i = 0; i <= Str.Length - 1; i++)
            {
                if (Str[i] != Str[Str.Length - 1 - i]) return false;
                if ((i == Str.Length - 1 - i) || //if we reached middle of string with odd quantity of elements
                    (i + 1 == Str.Length - 1 - i)) //if we reached middle of string with odd quantity of elements
                {
                    i = Str.Length;  //go out from cycle
                }
            }
            return true;
        }

        static string TakeSubstring(string S, int StartPosition, int StopPosition)//function takes substring from StartPosition to StopPosition from S
        {
            string res = null;
            for (int i = StartPosition; i <= StopPosition; i++)
            {
                res = res + S[i];
            }
            return res;
        }
    }
}
