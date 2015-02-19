#include "CharFrequency.c"

int main()
{
	struct CharFrequency * cf = SetupCharFrequency("Abc");
	printf("\nTesting in 'Abc'.\n");
	printf("\nFrequency of 'A': %i\n", cf->GetFrequency('A', cf));
	printf("\nFrequency of 'b': %i\n", cf->GetFrequency('b', cf));
	printf("\nFrequency of 'c': %i\n", cf->GetFrequency('c', cf));
	printf("\nFrequency of 'd': %i\n", cf->GetFrequency('d', cf));
	cf->PrintFrequencyList(cf);
	free(cf);
	cf = SetupCharFrequency("AbcAAbd");
	printf("\nTesting in 'AbcAAbd'.\n");
	printf("\nFrequency of 'A': %i\n", cf->GetFrequency('A', cf));
	printf("\nFrequency of 'b': %i\n", cf->GetFrequency('b', cf));
	printf("\nFrequency of 'c': %i\n", cf->GetFrequency('c', cf));
	printf("\nFrequency of 'd': %i\n", cf->GetFrequency('d', cf));
	cf->PrintFrequencyList(cf);
	return 0;
}