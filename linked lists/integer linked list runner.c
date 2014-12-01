#include "integer linked list test.h"

void fireTests(){
	printf(FTN, 1);
	TEST_should_setup_and_confim_via_printing();
	printf(FTN, 2);
	TEST_should_find_number_in_list();
	printf(FTN, 3);
	TEST_should_delete_numbers_first_occurence();
	printf(FTN, 4);
	TEST_should_delete_all_occurences_on_a_number();
	printf(FTN, 5);
	TEST_shoud_not_be_a_circular_list();
	printf(FTN, 6);
	TEST_shoud_be_a_circular_list();
	printf(FTN, 7);
	TEST_should_not_find_number_in_list();
	printf(FTN, 8);
	TEST_stack_should_be_reverse_of_the_list();
}

int main(){
	fireTests();
	return 0;
}

