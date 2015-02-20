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
	char key;
	int value;
	struct CharIntNode * next;
};

struct CharFrequency {
	bool (*Contains)(char key, struct CharFrequency * cf);
	int (*GetValue)(char key, struct CharFrequency * cf);
	void (*PrintFrequencyList)(struct CharFrequency * cf);
	void (*PrintFrequencyMap)(struct CharFrequency * cf);
	char * (*Keys)(struct CharFrequency * cf);
	int Count;
	struct CharIntNode * first;
};

struct CharFrequency * SetupCharFrequency(char * input);

#endif