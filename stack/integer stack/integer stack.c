#include "integer stack.h"

void invalid_argument_error(char * arg, char * message){
	fprintf(stderr, "\nErroring argument: %s.", arg);
	fprintf(stderr, message);
	abort();
}
void memory_allocation_error(char * message){
	fprintf(stderr, message);
	abort();
}

struct integer_stack_head * allocate_integer_stack_head(){
	return (struct integer_stack_head *)malloc(sizeof(struct integer_stack_head));
}
struct integer_stack_head * init_integer_stack(int size){
	struct integer_stack_head * integer_stack = allocate_integer_stack_head();
	if (integer_stack == NULL)
		memory_allocation_error("\nMemory cannot be allocated for integer_stack.");
	if (size <= 0)
		invalid_argument_error("size", "\nSize cannot be zero or less for integer_stack.");

	integer_stack->values = (int *)malloc(sizeof(int)*size);
	if (integer_stack->values == NULL)
		memory_allocation_error("\nCannot allocate memory for integer_stack content.");

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