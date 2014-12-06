#include "stack test.h"

int main(){
	// tests that will not stay forever, since aborting will be replaced with better code.
	// TEST_should_abort_when_empty_integer_stack_popped(); // tested. ok.
	TEST_should_resize_integer_stack_on_push_to_full_integer_stack();

	// tests that are there to stay.
	TEST_should_push_and_pop_three_integers_to_integer_stack(); // tested,
	return 0;
}