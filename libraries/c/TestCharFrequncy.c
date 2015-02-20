#include "CharFrequency.c"

int main()
{
	struct CharFrequency * cf = SetupCharFrequency("Abc");
	printf("\nTesting in 'Abc'.\n");
	printf("\nFrequency of 'A': %i\n", cf->GetValue('A', cf));
	printf("\nFrequency of 'b': %i\n", cf->GetValue('b', cf));
	printf("\nFrequency of 'c': %i\n", cf->GetValue('c', cf));
	printf("\nFrequency of 'd': %i\n", cf->GetValue('d', cf));
	cf->PrintFrequencyList(cf);
	cf->PrintFrequencyMap(cf);
	printf("\nCount: %i\n", cf->Count);
	printf("\nKeys: %s\n", cf->Keys(cf));
	cf->Remove('b', cf);
	printf("\nKeys: %s\n", cf->Keys(cf));
	free(cf);
	cf = SetupCharFrequency("AbcAAbdAAAbAcAd");
	printf("\nTesting in 'AbcAAbd'.\n");
	printf("\nFrequency of 'A': %i\n", cf->GetValue('A', cf));
	printf("\nFrequency of 'b': %i\n", cf->GetValue('b', cf));
	printf("\nFrequency of 'c': %i\n", cf->GetValue('c', cf));
	printf("\nFrequency of 'd': %i\n", cf->GetValue('d', cf));
	cf->PrintFrequencyList(cf);
	cf->PrintFrequencyMap(cf);
	printf("\nCount: %i\n", cf->Count);
	printf("\nKeys: %s\n", cf->Keys(cf));
	cf->Remove('A', cf);
	printf("\nKeys: %s\n", cf->Keys(cf));
	return 0;
}