using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace blogposts
{
    class PrimeGapGenerator
    {
        public PrimeGapGenerator()
        {
            Primes = InitiatePrimes();
            GeneratePrimeGaps();
        }

        public List<long> Primes { get; private set; }

        string ReadFileName = "int_primes_input_for_gaps.txt";
        string WriteFileName = "int_prime_gaps.txt";

        private List<long> InitiatePrimes()
        {
            List<long> primes = new List<long>();
            if (File.Exists(WriteFileName) && File.Exists(ReadFileName))
            {
                StreamReader sr = new StreamReader(ReadFileName);
                string allPrimes = sr.ReadToEnd();
                string[] primeArr = allPrimes.Split(',');
                long i = 0;
                for (i = 0; i < primeArr.Length; i++)
                {
                    primes.Add(long.Parse(primeArr[i].Trim()));
                }
                sr.Close();
                sr.Dispose();
            }
            return primes;
        }

        public void GeneratePrimeGaps()
        {
            StreamWriter sw = new StreamWriter(WriteFileName, true);
            StringBuilder sb = new StringBuilder();
            for (int num = 1; num < Primes.Count - 1; num++)
            {
                sb.AppendLine(string.Format("{3}. {0} - {1} = {2}", Primes[num], Primes[num - 1], Primes[num] - Primes[num - 1], num));
            }
            sw.WriteLine(sb.ToString());
            sb.Clear();
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }

    class Runner
    {
        static void Main()
        {
            var primeGapGenerator = new PrimeGapGenerator();
        }
    }
}