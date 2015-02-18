#include <stdio.h>

void swap(char *x, char *y){
	char temp = *x;
	*x = *y;
	*y = temp;
}

void permute(char *str, int start, int end){
	int j = start;
	if(start == end){
		printf("%s\n", str);
	}
	else {
		for(j = start; j <= end; j++){
			swap((str+start), (str+j));
			permute(str, start+1, end);
			swap((str+start), (str+j));
		}
	}
}

int main(){
	char a[] = "abc";
	permute(a, 0, 2);
	return 0;
}