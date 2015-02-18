#include <stdio.h>
#include <stdlib.h>

void spacer(char str[], char dstr[], int strI, int dstrI, int len){
	int i = 0;
	if(strI == len){
		dstr[dstrI] = '\0';
		printf("%s\n", dstr);
		return;
	}
	
	dstr[dstrI] = str[strI];
	spacer(str, dstr, strI+1, dstrI+1, len);
	
	dstr[dstrI] = ' ';
	dstr[dstrI+1] = str[strI];
	spacer(str, dstr, strI+1, dstrI+2, len);
}

int main(){
	char  str []="abc";
	char * dstr = (char*)malloc(sizeof(char) * strlen(str));
	dstr[0] = str[0];
	spacer(str, dstr, 1, 1, 3);
	return 0;
}