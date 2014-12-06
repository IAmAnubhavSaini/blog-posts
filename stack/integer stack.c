#include "integer stack.h"

struct integer_stack_head * init_integer_stack(int size){
	struct integer_stack_head * integer_stack = (struct integer_stack_head *)malloc(sizeof(struct integer_stack_head));
	if (integer_stack == NULL){
		fprintf(stderr, "\nMemory cannot be allocated for integer_stack.");
		abort();
	}
	if (size <= 0){
		fprintf(stderr, "\nSize cannot be zero or less for integer_stack.");
		abort();
	}
	integer_stack->values = (int *)malloc(sizeof(int)*size);
	if (integer_stack->values == NULL){
		fprintf(stderr, "\nCannot allocate memory for integer_stack content.");
		abort();
	}
	integer_stack->size = size;
	integer_stack->current_index = 0;
	return integer_stack;
}

void push(struct integer_stack_head * head, int value){
	if (head->size == head->current_index){
		resize(head, head->size*2);
	}
	head->values[head->current_index] = value;
	head->current_index = head->current_index + 1;
}

int pop(struct integer_stack_head *head){
	if (head->current_index == 0){
		abort(); // for now, throw error later
	}
	head->current_index = head->current_index - 1;
	return head->values[head->current_index];
}

void resize(struct integer_stack_head *head, int newSize)
{
	int * values = (int*)realloc(head->values, newSize);
	if (values == NULL){
		printf("Cannot resize integer_stack.");
		return;
	}
	head->values = values;
	head->size = newSize;
}