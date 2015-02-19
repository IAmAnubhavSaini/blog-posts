#ifndef CHAR_FREQUENCY_H
#define CHAR_FREQUENCY_H

#include <stdio.h>
#include <stdlib.h>

#ifndef bool
#define bool int
#endif

#ifndef true
#define true 1
#endif

#ifndef false
#define false 0
#endif

struct CharIntNode {
	char ch;
	int f;
	struct CharIntNode * next;
};

struct CharFrequency {
	bool (*Contains)(char ch, struct CharFrequency * cf);
	int (*GetFrequency)(char ch, struct CharFrequency * cf);
	struct CharIntNode * first;
};

struct CharFrequency * SetupCharFrequency(char * input);

#endif