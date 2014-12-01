#ifndef STACK_H
#define STACK_H

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct stack_head{
	int * values;
	int current_index;
	int size;
};

struct stack_head * init_stack(int size);
void push(struct stack_head * top, int value);
int pop(struct stack_head *head);

#endif // STACK_TEST_H
