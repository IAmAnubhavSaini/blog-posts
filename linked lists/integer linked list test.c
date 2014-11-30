#include "integer linked list test.h"

void TEST_search1(){
	Node *head = TEST_setup1();
	int num = 2;
	if (search_list(head, num)){
		printf("\nFound %d in list.", num);
	}
	else{
		printf("\nDid not find %d in list.", num);
	}
	num = 4;
	if (search_list(head, num)){
		printf("\nFound %d in list.", num);
	}
	else{
		printf("\nDid not find %d in list.", num);
	}
}

void TEST_delete1(){
	Node *head = TEST_setup1();
	int num = 2;
	if (delete_first_value_matching_node(head, num)){
		printf("\nDeleted first %d.", num);
		print_list(head);
	}
	num = 4;
	if (delete_first_value_matching_node(head, num)){
		printf("\nDeleted first %d.", num);
		print_list(head);
	}
	else{
		printf("\nDid not find %d in list.", num);
		print_list(head);
	}
	num = 1;
	if (delete_first_value_matching_node(head, 1)){
		printf("\nDeleted first %d.", num);
		print_list(head);
	}
	else{
		printf("\nDid not find %d in list.", num);
		print_list(head);
	}
}

Node * TEST_setup1(){
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

void TEST_delete2(){
	Node *head = TEST_setup1();
	int num = 2;
	if (delete_all_value_matching_nodes(head, num)){
		printf("\nAll %d deleted from list.", num);
	}
	else{
		printf("\nDid not find %d in list.", num);
	}
	print_list(head);
}

void TEST_circular_list(){
	Node *head = TEST_setup1();
	print_list(head);
	printf("Circular list test: list should not be circular.");
	if (is_list_circular(head)){
		printf("\nlist is circular.");
	}
	else{
		printf("\nlist is not circular.");
	}
	make_list_circular(head);
	printf("\nCircular list test: list should be circular.");
	print_list(head);
	if (is_list_circular(head)){
		printf("\nlist is circular.\n");
	}
	else {
		printf("\nlist is not circular.\n");
	}
}

