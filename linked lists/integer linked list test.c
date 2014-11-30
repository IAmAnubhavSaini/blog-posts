#include "integer linked list test.h"

void TEST_should_find_number_in_list(){
	Node *head = TEST_should_setup_and_confim_via_printing();
	int num = 2;
	if (search_list(head, num)){
		printf(FNIL, num);
	}
	else{
		printf(DNFNIL, num);
	}

}

void TEST_should_not_find_number_in_list(){
	Node *head = TEST_should_setup_and_confim_via_printing();
	int num = 4;
	if (search_list(head, num)){
		printf(FNIL, num);
	}
	else{
		printf(DNFNIL, num);
	}
}

void TEST_should_delete_numbers_first_occurence(){
	Node *head = TEST_should_setup_and_confim_via_printing();
	int num = 2;
	if (delete_first_value_matching_node(head, num)){
		printf(DFN, num);
		print_list(head);
	}
	num = 4;
	if (delete_first_value_matching_node(head, num)){
		printf(DFN, num);
		print_list(head);
	}
	else{
		printf(DNFNIL, num);
		print_list(head);
	}
	num = 1;
	if (delete_first_value_matching_node(head, 1)){
		printf(DFN, num);
		print_list(head);
	}
	else{
		printf(DNFNIL, num);
		print_list(head);
	}
}

Node * TEST_should_setup_and_confim_via_printing(){
	Node *head = NULL;
	Node *curr = NULL;
	head = curr = add_to_list(head, curr, 1, false);
	add_to_list(head, curr, 2, false);
	add_to_list(head, curr, 3, false);
	add_to_list(head, curr, 8, true);
	add_to_list(head, curr, 2, false);
	print_list(head);
	return head;
}

void TEST_should_delete_all_occurences_on_a_number(){
	Node *head = TEST_should_setup_and_confim_via_printing();
	int num = 2;
	if (delete_all_value_matching_nodes(head, num)){
		printf(ANDFL, num);
	}
	else{
		printf(DNFNIL, num);
	}
	print_list(head);
}

void TEST_shoud_not_be_a_circular_list(){
	Node *head = TEST_should_setup_and_confim_via_printing();
	print_list(head);
	printf(CLTLSNBC);
	if (is_list_circular(head)){
		printf(LIC);
	}
	else{
		printf(LINC);
	}
}


void TEST_shoud_be_a_circular_list(){
	Node *head = TEST_should_setup_and_confim_via_printing();
	print_list(head);
	make_list_circular(head);

	printf(CLTLSBC);
	print_list(head);
	if (is_list_circular(head)){
		printf(LIC);
	}
	else {
		printf(LINC);
	}
}

