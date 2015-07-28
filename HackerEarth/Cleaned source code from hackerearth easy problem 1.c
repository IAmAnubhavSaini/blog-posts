#include <stdio.h>

#define HugeInt long long int
#define MOD (int)(1e9 + 7)

HugeInt CalculateC2(HugeInt a, HugeInt n, HugeInt temp)
{
	HugeInt res = 1, y = a;
	while (n > 0) {
		if (n & 1){
			res = (res*y) % temp;
		}
		y = (y*y) % temp;
		n /= 2;
	}
	return res % temp;
}

HugeInt arr[100006], flagit[134], flg[134];

inline HugeInt Sanitize(HugeInt calc)
{
	while (calc < 0)
		calc += MOD;
	calc %= MOD;
	return calc;
}

HugeInt GetInputs(){
	HugeInt numberOfInputs, i;

	scanf("%lld", &numberOfInputs);
	for (i = 0; i < numberOfInputs; i++)
	{
		scanf("%lld", &arr[i]);
	}
	return numberOfInputs;
}

void SetArrayToZero(HugeInt arr[], HugeInt count)
{
	HugeInt i = 0;
	for (i = 0; i < count; i++) {
		arr[i] = 0;
	}
}

HugeInt CalculateC1(HugeInt index, HugeInt c2)
{
	HugeInt c1 = Sanitize(flagit[index] * (flagit[index] - 1));
	return (c1*c2) % MOD;
}

HugeInt CalculateNumberOfSetsWithEqualXOR(void)
{
	HugeInt i = 0, ans = 0, c2 = CalculateC2(2, MOD - 2, MOD);

	for (i = 0; i < 129; i++)
	{
		ans = (ans + CalculateC1(i, c2)) % MOD;
	}
	return ans;
}

void ProcessInput(HugeInt i)
{
	HugeInt j = 0, calc = 0;

	SetArrayToZero(flg, 135);
	for (j = 0; j < 129; j++)
	{
		if (flagit[j] != 0)
		{
			calc = j^arr[i];
			flg[calc] += flagit[j];
			flg[calc] = flg[calc] % MOD;
		}
	}
	for (j = 0; j < 129; j++)
	{
		flagit[j] += flg[j];
		flagit[j] = flagit[j] % MOD;
	}
	flagit[arr[i]]++;
	flagit[arr[i]] = flagit[arr[i]] % MOD;
}

void ProcessAllInputs(HugeInt numberOfInputs)
{
	HugeInt i = 0;
	for (i = 0; i < numberOfInputs; i++)
	{
		ProcessInput(i);
	}
}

HugeInt CalculateNumberOfMatchingXORSets(){
	HugeInt numberOfInputs = GetInputs();
	SetArrayToZero(flagit, 135);
	ProcessAllInputs(numberOfInputs);
	return CalculateNumberOfSetsWithEqualXOR();
}

int main()
{
	HugeInt numberOfMatchingXORSets = CalculateNumberOfMatchingXORSets();
	printf("%lld\n", numberOfMatchingXORSets);
	return 0;
}
