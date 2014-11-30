#include "integer linked list test.h"

void TEST_search1(){
	if (search_list(2)){
		printf("\nFound 2 in list.");
	}
	else{
		printf("\nNot found 2 in list.");
	}
	if (search_list(4)){
		printf("\nFound 4 in list.");
	}
	else{
		printf("\nNot found 4 in list.");
	}
}

void TEST_delete1(){
	if (delete_first_value_matching_node(2)){
		printf("\nDeleted first 2.");
		print_list();
	}
	if (delete_first_value_matching_node(4)){
		printf("\nDeleted first 4.");
		print_list();
	}
	else{
		printf("\n4 Not found.");
		print_list();
	}
	if (delete_first_value_matching_node(1)){
		printf("\nDeleted first 1.");
		print_list();
	}
	else{
		printf("\n1 Not found.");
		print_list();
	}
}

void TEST_setup1(){
	add_to_list(1, false);
	add_to_list(2, false);
	add_to_list(3, false);
	add_to_list(8, true);
	add_to_list(2, false);
	print_list();
}

void TEST_delete2(){
	if (delete_all_value_matching_nodes(2)){
		printf("\nAll 2s deleted from list.");
	}
	else{
		printf("\n2 not found.");
	}
	print_list();
}

void      TEST_circular_list(){
	TEST_setup1();
	print_list();
	printf("Circular list test: list should not be circular.");
	if (is_list_circular()){
		printf("\nlist is circular.");
	}
	else{
		printf("\nlist is not circular.");
	}
	make_list_circular();
	printf("\nCircular list test: list should be circular.");
	print_list();
	if (is_list_circular()){
		printf("\nlist is circular.\n");
	}
	else {
		printf("\nlist is not circular.\n");
	}

}