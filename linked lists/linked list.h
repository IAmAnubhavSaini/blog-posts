#ifndef LINKED_LIST_H
#define LINKED_LIST_H

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct link_node
{
	void * val;
	struct link_node *next;
	enum link_node_data_type type;
};

enum link_node_data_type{
	UNKNOWN_DATA_TYPE, INT_TYPE, STRING_TYPE
};

enum node_insertion_position{
	INSERT_AT_END,
	INSERT_AT_START,
	INSERT_AT_MID
};

typedef struct link_node Node; //gives a bit of OOP feel

Node  *   create_node(void* val, enum link_node_data_type type);
void      add_to_list(Node *head, void * val, enum link_node_data_type type);
void      insert_in_list(Node *head, void * val, enum link_node_data_type type, enum node_insertion_position position);
void      tail_insert_in_list(Node *head, void * val, enum link_node_data_type type);
void      mid_insert_in_list(Node *head, void * val, enum link_node_data_type type);
void      head_insert_in_list(Node *head, void * val, enum link_node_data_type type);
void      insert_in_list_after(Node *head, void * insertVal, enum link_node_data_type type, void *searchVal);
void      insert_in_list_before(Node *head, void * insertVal, enum link_node_data_type type, void *searchVal);


void      make_list_circular(Node *head);
void      make_list_acircular(Node *head);
void      print_list(Node *head);

bool      search_list_for_integer(Node *head, int val);
bool      delete_first_integer_value_matching_node(Node *head, int val);
bool      delete_all_integer_value_matching_nodes(Node *head, int val);
bool      is_list_empty(Node *head);
bool      is_list_circular(Node *head);

Node *    create_stack_from_existing_list(Node *otherListHead, Node *otherListUpto);

#endif LINKED_LIST_H
