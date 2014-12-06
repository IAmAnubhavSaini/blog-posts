#include "stack test.h"

void TEST_should_abort_when_empty_integer_stack_popped()
{
	struct integer_stack_head * head = init_integer_stack(1);
	pop(head);
}

void TEST_should_resize_integer_stack_on_push_to_full_integer_stack()
{
	struct integer_stack_head * integer_stack = init_integer_stack(3);
	printf("\nRunning: TEST_should_resize_integer_stack_on_push_to_full_integer_stack.");
	printf("\nCurrent integer_stack size: %d,", integer_stack->size);
	push(integer_stack, 1);
	push(integer_stack, 2);
	push(integer_stack, 3);
	push(integer_stack, 4); // should be aborted here.
	printf("\nStack size after 4th push: %d,", integer_stack->size);
}

void TEST_should_push_and_pop_three_integers_to_integer_stack()
{
	struct integer_stack_head * integer_stack = init_integer_stack(3);
	printf("\nRunning: TEST_should_push_and_pop_three_integers_to_integer_stack.");
	push(integer_stack, 1);
	push(integer_stack, 2);
	push(integer_stack, 3);
	printf("\nStack top: %d,", pop(integer_stack));
	printf("\nStack top: %d,", pop(integer_stack));
	printf("\nStack top: %d,", pop(integer_stack));
}
