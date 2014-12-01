#ifndef INTEGER_LINKED_LIST_H
#define INTEGER_LINKED_LIST_H

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct link_node
{
	int val;
	struct link_node *next;
};

enum node_insertion_position{
	INSERT_AT_END,
	INSERT_AT_START
};

typedef struct link_node Node; //gives a bit of OOP feel

Node  *   create_node(int val);
void      add_to_list(Node *head, int val);

void      make_list_circular(Node *head);
void      make_list_acircular(Node *head);
void      print_list(Node *head);

bool      search_list(Node *head, int val);
bool      delete_first_value_matching_node(Node *head, int val);
bool      delete_all_value_matching_nodes(Node *head, int val);
bool      is_list_empty(Node *head);
bool      is_list_circular(Node *head);

Node *    create_stack_from_existing_list(Node *otherListHead, Node *otherListUpto);

#endif INTEGER_LINKED_LIST_H
