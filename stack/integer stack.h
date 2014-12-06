#ifndef STACK_H
#define STACK_H

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct integer_stack_head{
	int * values;
	int current_index;
	int size;
};

struct integer_stack_head * init_integer_stack(int size);
void push(struct integer_stack_head * top, int value);
int pop(struct integer_stack_head *head);
void resize(struct integer_stack_head *head, int newSize);

#endif // STACK_TEST_H
