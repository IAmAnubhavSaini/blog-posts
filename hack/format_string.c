#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int c, char **args){
	char *name = "Anubhav Saini";
	int count = 13;
	char CSName[255];
	char buf[255];
	sprintf(buf, args[1]);
	//printf("Enter your CS name: \n");
	//scanf("%s", CSName);
	printf("%s is %s in counter_strike.\n", name, buf);
	return 0;
}