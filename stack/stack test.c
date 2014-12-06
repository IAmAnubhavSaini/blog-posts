#include "stack test.h"

void TEST_should_abort_when_empty_stack_popped()
{
	struct stack_head * head = init_stack(1);
	pop(head);
}

void TEST_should_resize_stack_on_push_to_full_stack()
{
	struct stack_head * stack = init_stack(3);
	printf("\nRunning: TEST_should_resize_stack_on_push_to_full_stack.");
	printf("\nCurrent stack size: %d,", stack->size);
	push(stack, 1);
	push(stack, 2);
	push(stack, 3);
	push(stack, 4); // should be aborted here.
	printf("\nStack size after 4th push: %d,", stack->size);
}

void TEST_should_push_and_pop_three_integers_to_stack()
{
	struct stack_head * stack = init_stack(3);
	printf("\nRunning: TEST_should_push_and_pop_three_integers_to_stack.");
	push(stack, 1);
	push(stack, 2);
	push(stack, 3);
	printf("\nStack top: %d,", pop(stack));
	printf("\nStack top: %d,", pop(stack));
	printf("\nStack top: %d,", pop(stack));
}
