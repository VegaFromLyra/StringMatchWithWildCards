using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Given two strings where first string may contain wild card characters and second string is a normal string. Write a function that returns true if the two strings match. The following are allowed wild card characters in first string.

//* --> Matches with 0 or more instances of any character or set of characters.
//? --> Matches with any one character

namespace StringMatchWithWildCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("g*ks", "geeks"); // Yes
            Test("ge?ks*", "geeksforgeeks"); // Yes
            Test("g*k", "gee");  // No because 'k' is not in second
            Test("*pqrs", "pqrst"); // No because 't' is not in first
            Test("abc*bcd", "abcdhghgbcd"); // Yes
            Test("abc*c?d", "abcd"); // No because second must have 2 instances of 'c'
            Test("*c*d", "abcd"); // Yes
            Test("*?c*d", "abcd"); // Yes
        }

        static void Test(string s1, string s2)
        {
            if (Match(s1, s2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        // First one will contain * or ? or both
        static bool Match(string first, string second)
        {
            if (String.IsNullOrEmpty(first) && String.IsNullOrEmpty(second))
            {
                return true;
            }
            // if only the second string has reached its end,
            // the patterns did not match up. First should not be 
            // empty but in case it is, return false
            else if (String.IsNullOrEmpty(first)) 
            {
                return false;
            }
            else if (String.IsNullOrEmpty(second))
            {
                if (first.Length == 1 &&
                    (first[0] == '*') || (first[0] == '?')
                   )
                {
                    return true;
                }

                return false;
            }
            else if (first[0] == second[0] || first[0] == '?')
            {
                return Match(first.Substring(1, first.Length - 1), second.Substring(1, second.Length - 1));
            }
            else if ((first[0] == '*') && (first.Length == 1))
            {
                return true;
            }
            else if (first[0] == '*')
            {
                return Match(first.Substring(1, first.Length - 1), second) || Match(first, second.Substring(1, second.Length - 1));
            }
            else
            {
                return false;
            }
        }
    }
}
