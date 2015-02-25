#include <stdio.h>

void normal_var_and_pointers();
void constant_var_and_pointers();

int main(){
	normal_var_and_pointers();
	constant_var_and_pointers();
	return 0;
}

void normal_var_and_pointers()
{
	int other = 20;
	int i = 10;
	int * ptrToVar = &i;
	int * const ptrToConstantLoc = &i;
	const int * ptrToConstantVar = &i;
	const int * const ptrToConstantVarAndLoc = &i;

	printf("\nOriginal value of i: %i", i);
	printf("\n\tIncrementing value of i via i.");
	i++;
	printf("\n\t\tNew value of i: %i", i);

	printf("\n\tDecrementing value of i via pointer `int * ptrToVar`.");
	--*ptrToVar;
	printf("\n\t\tNew value of i: %i", *ptrToVar);

	printf("\n\tIncrementing value of i via pointer to constant location: `int * const ptrToConstantLoc`.");
	++*ptrToConstantLoc;
	printf("\n\t\tNew value of i: %i", *ptrToConstantLoc);

	printf("\n\tDecrementing value of i via pointer to constant var: `const int * ptrToConstantVar`.");
	//--*ptrToConstantVar; // compilation warning as the value to which it points cannot be modified.
	printf("\nERROR: cannot decrement as to what it points cannot be modified for `const int * ptrToConstantVar`.");
	printf("\nINFO: Though we can point to entirely different variable.");
	ptrToConstantVar = &other;
	printf("\n\t\tNew value of i: %i", *ptrToConstantVar);

	printf("\n\tIncrementing value of i via pointer to constant var and location: `const int * const ptrToConstantVarAndLoc`.");
	//++*ptrToConstantVarAndLoc;		// same as ptrToConstantVar;
	//ptrToConstantVarAndLoc = &other;	// except, due to second const in the declaration, we cannot change the location.
	printf("\nERROR: Cannot change location or value for `const int * const ptrToConstantVarAndLoc`.");
	printf("\n\t\tNew value of i: %i", *ptrToConstantVarAndLoc);
}

void constant_var_and_pointers()
{
	const int other = 20;
	const int c = 10;
	int * ptrToVar = &c; // `const` mis match warning
	int * const ptrToConstantLoc = &c; // `const` mis match warning
	const int * ptrToConstantVar = &c;
	const int * const ptrToConstantVarAndLoc = &c;

	printf("\nOriginal value of c: %i", c);
	printf("\n\tIncrementing value of c.");
	//c++; // value of a constant cannot be updated
	printf("\n\t\tNew value of c: %i", c);

	printf("\n\tDecrementing value of c via pointer.");
	--*ptrToVar;
	printf("\n\t\tNew value of c: %i", *ptrToVar);

	printf("\n\tIncrementing value of c via pointer to constant location.");
	++*ptrToConstantLoc;
	printf("\n\t\tNew value of c: %i", *ptrToConstantLoc);

	printf("\n\tDecrementing value of c via pointer to constant var.");
	//--*ptrToConstantVar; // value of constant cannot be changed via this pointer.
	ptrToConstantVar = &other;
	printf("\n\t\tNew value of c: %i", *ptrToConstantVar);

	printf("\n\tIncrementing value of c via pointer to constant var and location.");
	//++*ptrToConstantVarAndLoc; // same as ptrToConstantVar
	//ptrToConstantVarAndLoc = &other; // also, location cannot be altered/
	printf("\n\t\tNew value of c: %i", *ptrToConstantVarAndLoc);
}