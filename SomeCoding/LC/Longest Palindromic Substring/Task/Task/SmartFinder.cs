using System;

namespace Task;

public class SmartFinder
{
    public string SearchPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return "";

        int l = 0, r = 0;
        Span<char> source = ConvertToSpan(s);
        int[] radii = new int[source.Length];
        int maxR = 0;
        int center = 0;
        radii[0] = 0;
        for (int i = 1; i < source.Length - 1; i++)
        {
            if (i >= r)
            {
                int radius = SearchPalindrome(source, i);
                radii[i] = radius;
            }
            else
            {
                radii[i] = radii[l + r - i];
                if (i + radii[i] >= r)
                {
                    int radius = SearchPalindrome(source, i);
                    radii[i] = radius;
                }
            }

            if (radii[i] > 0 && i + radii[i] > r)
            {
                r = i + radii[i];
                l = i - radii[i];
            }

            if (radii[i] == 1 && source[i - radii[i]] == '|')
                continue;

            if (radii[i] > maxR)
            {
                maxR = radii[i];
                center = i;
            }
        }

        if (center == 0)
            center = 1;
        string result = source.Slice(center - maxR, 2 * maxR + 1).ToString().Replace("|", "");
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

    private Span<char> ConvertToSpan(string s)
    {
        Span<char> source = new char[s.Length * 2 + 1];
        for (int i = 0; i < s.Length; i++)
        {
            source[2 * i + 1] = s[i];
            source[2 * i] = '|';
        }

        source[0] = '$';
        source[^1] = '#';
        return source;
    }
}