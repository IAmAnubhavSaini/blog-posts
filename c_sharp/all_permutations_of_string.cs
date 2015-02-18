using System;

namespace blogposts
{
    public class Permuter
    {
        private int start;
        private int end;
        private string current;

        public Permuter(string str, int startIndex, int endIndex)
        {
            current = str;
            start = startIndex;
            end = endIndex;
        }

        private string Swap(int with)
        {
            char[] mutableStr = current.ToCharArray();
            char temp = mutableStr[start];
            mutableStr[start] = mutableStr[with];
            mutableStr[with] = temp;
            return new string(mutableStr);
        }

        public void Permute()
        {
            if (start == end)
            {
                Console.WriteLine(current);
            }
            else
            {
                for (int j = start; j <= end; j++)
                {
                    (new Permuter(Swap(j), start + 1, end)).Permute();
                }
            }
        }
    }

    class Runner
    {
        static void Main()
        {
            Permuter p = new Permuter("abc", 0, 2);
            p.Permute();
        }
    }
}