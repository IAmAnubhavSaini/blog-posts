#include "stack.h"

struct stack_head * init_stack(int size){
	struct stack_head * stack = (struct stack_head *)malloc(sizeof(struct stack_head));
	if (stack == NULL){
		fprintf(stderr, "\nMemory cannot be allocated for stack.");
		abort();
	}
	if (size <= 0){
		fprintf(stderr, "\nSize cannot be zero or less for stack.");
		abort();
	}
	stack->values = (int *)malloc(sizeof(int)*size);
	if (stack->values == NULL){
		fprintf(stderr, "\nCannot allocate memory for stack content.");
		abort();
	}
	stack->size = size;
	stack->current_index = 0;
	return stack;
}

void push(struct stack_head * head, int value){
	if (head->size == head->current_index){
		abort(); // for now, resize later.
	}
	head->values[head->current_index] = value;
	head->current_index = head->current_index + 1;
}

int pop(struct stack_head *head){
	if (head->current_index == 0){
		abort(); // for now, throw error later
	}
	head->current_index = head->current_index - 1;
	return head->values[head->current_index];
}

