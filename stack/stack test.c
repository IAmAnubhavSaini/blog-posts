#include "stack test.h"

void TEST_should_abort_when_empty_stack_popped()
{
	struct stack_head * head = init_stack(1);
	pop(head);
}