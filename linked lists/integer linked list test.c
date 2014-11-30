#include "integer linked list test.h"

void TEST_search1(){
	Node *head = TEST_setup1();
	if (search_list(head,2)){
		printf("\nFound 2 in list.");
	}
	else{
		printf("\nNot found 2 in list.");
	}
	if (search_list(head, 4)){
		printf("\nFound 4 in list.");
	}
	else{
		printf("\nNot found 4 in list.");
	}
}

void TEST_delete1(){
	Node *head = TEST_setup1();
	if (delete_first_value_matching_node(head, 2)){
		printf("\nDeleted first 2.");
		print_list(head);
	}
	if (delete_first_value_matching_node(head, 4)){
		printf("\nDeleted first 4.");
		print_list(head);
	}
	else{
		printf("\n4 Not found.");
		print_list(head);
	}
	if (delete_first_value_matching_node(head, 1)){
		printf("\nDeleted first 1.");
		print_list(head);
	}
	else{
		printf("\n1 Not found.");
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
	if (delete_all_value_matching_nodes(head, 2)){
		printf("\nAll 2s deleted from list.");
	}
	else{
		printf("\n2 not found.");
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

