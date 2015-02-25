#include <stdio.h>

void int_are_value_type(int i);
void array_are_reference_type(int arr[]);

int main(){
	int i = 10;
	int arr[2] = {10, 20};

	printf("\nBefore calling function that manipulates the input:\ni: %i", i);
	int_are_value_type(i);
	printf("\nAfter calling function that manipulates the input:\ni: %i", i);
	printf("\n\nThe fact that the value of i stays same indicates that it is value type.\n");

	printf("\nBefore calling arr manipulating function:\narr[0], arr[1]: %i, %i", arr[0], arr[1]);
	array_are_reference_type(arr);
	printf("\nAfter calling arr manipulating function:\narr[0], arr[1]: %i, %i", arr[0], arr[1]);	
	printf("\n\nThe fact that the value of arr[0] and arr[1] were swapped indicates that arr is reference type.\n");

	return 0;
}

void int_are_value_type(int i)
{
	i = i*2;
}

void array_are_reference_type(int arr[])
{
	int tmp = arr[0];
	arr[0] = arr[1];
	arr[1] = tmp;
}