#ifndef GENERIC_STACK_H
#define GENERIC_STACK_H

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

struct stackNode{
	void * data;
	struct stackNode * next;
};

struct Stack{
	struct stackNode * Top;
	int Count;
	void (*Push)(struct Stack * stack, void * data);
	void * (*Pop)(struct Stack * stack);
};

struct Stack * CreateStack();

#endif
