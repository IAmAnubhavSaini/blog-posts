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
typedef struct link_node Node; //gives a bit of OOP feel

Node  *   create_list(int val);
Node  *   add_to_list(Node *head, Node *curr, int val, bool before_head);

void      make_list_circular(Node *head);
void      print_list(Node *head);

bool      search_list(Node *head, int val);
bool      delete_first_value_matching_node(Node *head, int val);
bool      delete_all_value_matching_nodes(Node *head, int val);
bool      is_list_empty(Node *head);
bool      is_list_circular(Node *head);

#endif INTEGER_LINKED_LIST_H
