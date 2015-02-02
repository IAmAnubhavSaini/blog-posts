#include <stdio.h>

int hcf_recursive(int a, int b);

int main(){
	int a, b;
	printf("\nEnter number 1: \n");  scanf("%i", &a); 
	printf("\nEnter number 2: \n");  scanf("%i", &b); 
	printf("\nHCF of %i and %i: %i", a, b, hcf_recursive(a, b)); 
	return 0;
}

int hcf_recursive(int a, int b){
	int q, r;
	if(a > 0 && b > 0){
		if(a < b)
			return hcf_recursive(b, a);
		
		q = a / b;
		r = a % b;
		if(r == 0)
			return b;
		else if(r == 1)
			return 1;
		else
			return hcf_recursive(b, r);
	}
	return -1;
}