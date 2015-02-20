#ifndef INT_FREQUENCY_H
#define INT_FREQUENCY_H

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

struct IntIntNode {
	int key;
	int value;
	struct IntIntNode * next;
};

struct IntFrequency {
	bool (*Contains)(int key, struct IntFrequency * cf);
	int (*GetValue)(int key, struct IntFrequency * cf);
	void (*PrintFrequencyList)(struct IntFrequency * cf);
	void (*PrintFrequencyMap)(struct IntFrequency * cf);
	int * (*Keys)(struct IntFrequency * cf);
	void (*Remove)(int key, struct IntFrequency * cf);
	int Count;
	struct IntIntNode * first;
};

struct IntFrequency * SetupIntFrequency(int input[], int count);

#endif