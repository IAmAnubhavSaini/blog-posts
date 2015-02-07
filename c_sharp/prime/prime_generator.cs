using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace blogposts
{
    class PrimeGenerator
    {
        public PrimeGenerator()
        {
            Primes = InitiatePrimes();
            GeneratePrimes();
        }

        public List<long> Primes { get; private set; }

        string ReadFileName = "int_primes.txt";
        string WriteFileName = "int_primes.txt";

        private long upto = 2;

        private List<long> InitiatePrimes()
        {
            List<long> primes = new List<long>();
            if (File.Exists(WriteFileName)  && File.Exists(ReadFileName))
            {
                StreamReader sr = new StreamReader(ReadFileName);
                string allPrimes = sr.ReadToEnd();
                string[] primeArr = allPrimes.Split(',');
                long i = 0;
                for (i = 0; i < primeArr.Length - 1; i++)
                {
                    primes.Add(long.Parse(primeArr[i].Trim()));
                }
                upto = long.Parse(primeArr[i - 1]);
                sr.Close();
                sr.Dispose();
            }
            return primes;
        }

        private bool IsPrime(long number)
        {
            foreach (var prime in Primes.Where(p => p <= Math.Sqrt(number)))
            {
                if (number % prime == 0)
                    return false;
            }
            return true;
        }

        public void GeneratePrimes()
        {
            StreamWriter sw = new StreamWriter(WriteFileName, true);
            StringBuilder sb = new StringBuilder();
            for (long num = upto; num < int.MaxValue; num++)
            {
                if (IsPrime(num))
                {
                    Primes.Add(num);
//                    Console.Write(num + ", ");
                    sb.Append(num + ", ");
                    sw.Write(sb.ToString());
                    sb.Clear();
                }
            }
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
            var primeGenerator = new PrimeGenerator();
        }
    }
}