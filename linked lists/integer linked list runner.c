#include "integer linked list test.h"

void fireTests(){
	printf(FT_1);
	TEST_should_setup_and_confim_via_printing();
	printf(FT_2);
	TEST_should_find_number_in_list();
	printf(FT_3);
	TEST_should_delete_numbers_first_occurence();
	printf(FT_4);
	TEST_should_delete_all_occurences_on_a_number();
	printf(FT_5);
	TEST_shoud_not_be_a_circular_list();
	printf(FT_6);
	TEST_shoud_be_a_circular_list();
	printf(FT_7);
	TEST_should_not_find_number_in_list();
}

int main(){
	fireTests();
	return 0;
}

