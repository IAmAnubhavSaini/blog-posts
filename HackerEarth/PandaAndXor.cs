using System;

namespace HackerEarthProblemSolving
{
    class PandaAndXorSolution
    {
        long MOD =  (long)(1e9 + 7);
        long [] arr = new long[100006];
        long [] flagit = new long[134];
        long [] flg = new long[134];

        long CalculateC2(long a, long n, long MOD)
        {
	        long res = 1;
            for (long y = a; n > 0; n /= 2)
            {
                Console.WriteLine("N : {0}; res : {1}; y : {2}.", n, res, y);
                if (n % 2 == 1)
                {
                    res = (res * y) % MOD;
                }
                y = (y * y) % MOD;
            }
	        return res % MOD;
        }

        long Sanitize(long calc)
        {
	        while (calc < 0)
		        calc += MOD;
	        calc %= MOD;
	        return calc;
        }

        long GetInputs(){

            long numberOfInputs = long.Parse(Console.ReadLine());

	        for (long i = 0; i < numberOfInputs; i++)
	        {
                arr[i] = long.Parse(Console.ReadLine());
	        }
	        return numberOfInputs;
        }

        void SetArrayToZero(long [] arr)
        {
            for (long i = 0; i < arr.Length; i++)
                arr[i] = 0;
        }

        long CalculateC1(long index, long c2)
        {
	        long c1 = Sanitize(flagit[index] * (flagit[index] - 1));
            Console.WriteLine("C1: {0}; C2: {1}; c1*c2 % MOD: {2}, C1*C2: {3}", c1, c2, (c1*c2) %MOD, c1*c2);
	        return (c1*c2) % MOD;
        }

        long CalculateNumberOfSetsWithEqualXOR()
        {
	        long i = 0, ans = 0, c2 = CalculateC2(2, MOD - 2, MOD);

            Console.WriteLine("C2: {0}", c2);
	        for (i = 0; i < 129; i++)
	        {
		        ans = (ans + CalculateC1(i, c2)) % MOD;
                Console.WriteLine("i: {1}; Intermediate ans: {0}", ans, i);
	        }
	        return ans;
        }

        void ProcessInput(long i)
        {
	        SetArrayToZero(flg);
	        for (long j = 0; j < 129; j++)
	        {
		        if (flagit[j] != 0)
		        {
			        long calc = j^arr[i];
			        flg[calc] = (flg[calc] + flagit[j]) % MOD;
		        }
	        }
	        for (long j = 0; j < 129; j++)
	        {
                flagit[j] = (flagit[j] + flg[j]) % MOD;
	        }
	        flagit[arr[i]] = (flagit[arr[i]]+1) % MOD;
        }

        void ProcessAllInputs(long numberOfInputs)
        {
	        for (long i = 0; i < numberOfInputs; i++)
	        {
		        ProcessInput(i);
	        }
        }

        long CalculateNumberOfMatchingXORSets(){
	        long numberOfInputs = GetInputs();
	        SetArrayToZero(flagit);
	        ProcessAllInputs(numberOfInputs);
	        return CalculateNumberOfSetsWithEqualXOR();
        }

        public long Solve()
        {
	        return CalculateNumberOfMatchingXORSets();
        }

    }
    class PandaAndXorRunner
    {
        static void Main(){
            PandaAndXorSolution paxs = new PandaAndXorSolution();
            Console.WriteLine(paxs.Solve());
        }
    }
}
