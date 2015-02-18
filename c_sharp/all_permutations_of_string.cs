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

        private string Swap(string str, int i, int j)
        {
            char[] mutableStr = str.ToCharArray();
            char temp = mutableStr[i];
            mutableStr[i] = mutableStr[j];
            mutableStr[j] = temp;
            return new string(mutableStr);
        }

        public void Permute()
        {
            if (start == end)
                Console.WriteLine(current);
            else
            {
                for (int j = start; j <= end; j++)
                {
                    string tmp = Swap(current, start, j);
                    (new Permuter(tmp, start + 1, end)).Permute();
                }
            }
        }
    }

    class Runner{
        static void Main(){
            Permuter p = new Permuter("abc", 0, 2);
            p.Permute();
        }
    }
}