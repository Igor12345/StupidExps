using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    public class SimpleFinder
    {
        public string SearchPalindrome(string s)
        {
            Span<char> source = new char[s.Length * 2 + 1];
            for (int i = 0; i < s.Length; i++)
            {
                source[2 * i + 1] = s[i];
                source[2 * i] = '|';
            }

            source[0] = '$';
            source[^1] = '#';

            string result = "";

            int max = 0;
            for (int i = 0; i < source.Length; i++)
            {
                int r = 0;
                while (i - r - 1 > 0 && i + r + 1 < source.Length && source[i - r - 1] == source[i + r + 1])
                {
                    r++;
                }

                if (r > max)
                {
                    max = r;
                    var palindrome = source.Slice(i - r, 2 * r + 1).ToString().Replace("|", "");
                    result =palindrome;
                }
            }

            return result;
        }
        public int SearchPalindrome(Span<char> source, int start)
        {
            int r = 0;
            while (source[start - r - 1] == source[start + r + 1])
            {
                r++;
            }

            return r;
        }
    }
}