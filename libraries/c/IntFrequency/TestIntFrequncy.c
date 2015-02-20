#include "IntFrequency.c"

void PrintKeys(int * keys, int count);

int main()
{
	int i = 0;
	int * keys = NULL;
	int arr[] = {1, 2, 3};
	int carr = 3;
	int arr2[] = {1, 2, 3, 1, 1, 2, 4};
	int carr2 = 7;
	
	struct IntFrequency * cf = SetupIntFrequency(arr, carr);
	printf("\nTesting in '123'.\n");
	printf("\nFrequency of '1': %i\n", cf->GetValue(1, cf));
	printf("\nFrequency of '2': %i\n", cf->GetValue(2, cf));
	printf("\nFrequency of '3': %i\n", cf->GetValue(3, cf));
	printf("\nFrequency of '4': %i\n", cf->GetValue(4, cf));
	cf->PrintFrequencyList(cf);
	cf->PrintFrequencyMap(cf);
	printf("\nCount: %i\n", cf->Count);
	PrintKeys(cf->Keys(cf), cf->Count);
	printf("\nRemoving 2 from keys.");
	cf->Remove(2, cf);
	PrintKeys(cf->Keys(cf), cf->Count);
	free(cf);
	
	cf = SetupIntFrequency(arr2, carr2);
	printf("\nTesting in '1231124'.\n");
	printf("\nFrequency of '1': %i\n", cf->GetValue(1, cf));
	printf("\nFrequency of '2': %i\n", cf->GetValue(2, cf));
	printf("\nFrequency of '3': %i\n", cf->GetValue(3, cf));
	printf("\nFrequency of '4': %i\n", cf->GetValue(4, cf));
	cf->PrintFrequencyList(cf);
	cf->PrintFrequencyMap(cf);
	printf("\nCount: %i\n", cf->Count);
	PrintKeys(cf->Keys(cf), cf->Count);
	printf("\nRemoving 2 from keys.");
	cf->Remove(2, cf);
	PrintKeys(cf->Keys(cf), cf->Count);
	
	return 0;
}

void PrintKeys(int * keys, int count)
{
	int i;
	printf("\nKeys:");
	for(i = 0; i < count; i++){
		printf(" %i ",keys[i]);	
	}
}
