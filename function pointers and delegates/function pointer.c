#include<stdio.h>

void ActionCarrier(int(*action)(int, int), int a, int b);

int sum(int a, int b);
int difference(int a, int b);
int product(int a, int b);
int quotient(int a, int b);
int modulus(int a, int b);

int main(){
	int a = 20, b = 7;
	ActionCarrier(sum, a, b);
	ActionCarrier(difference, a, b);
	ActionCarrier(product, a, b);
	ActionCarrier(quotient, a, b);
	ActionCarrier(modulus, a, b);
}

void ActionCarrier(int(*action)(int, int), int a, int b){
	printf("\n%d %p %d = %d", a, action, b, action(a, b));
}

int sum(int a, int b){
	return a + b;
}
int difference(int a, int b){
	return a - b;
}
int product(int a, int b){
	return a*b;
}
int quotient(int a, int b){
	return a / b;
}
int modulus(int a, int b){
	return a%b;
}
