#include "linked list.h"


Node* create_node(void* val, enum link_node_data_type type){
#ifdef DEBUG
	printf("\ndebug: entering create_node with value : %d.", val);
#endif
	Node *ptr = (Node*)malloc(sizeof(Node));
	if (ptr == NULL ){
		abort();
	}
	ptr->val = val;
	ptr->next = NULL;
	ptr->type = type;

	return ptr;
#ifdef DEBUG
	printf("\ndebug: exiting create_node.");
#endif
}

void add_to_list(Node *head, void* val, enum link_node_data_type type){
#ifdef DEBUG
	printf("\ndebug: entering add_to_list with value.");
#endif
	Node *newTS = create_node(val, type);
	Node *tmp = head;
	while (tmp->next != NULL){
		tmp = tmp->next;
	}
	tmp->next = newTS;
#ifdef DEBUG
	printf("\ndebug: exiting add_to_list.");
#endif
}

void make_list_circular(Node *head){
#ifdef DEBUG
	printf("\ndebug: entering make_list_circular.");
#endif
	Node * tmp = head;
	while (tmp && tmp->next){
		tmp = tmp->next;
	}
	tmp->next = head;
#ifdef DEBUG
	printf("\ndebug: exiting make_list_circular.");
#endif
}

void make_list_acircular(Node *head)
{
	Node *slow;
	Node *fast;
	slow = fast = head;
	if (head == NULL){
		return;
	}
	if (is_list_circular(head)){
		while (true){
			fast = fast->next->next;
			slow = slow->next;
			if (slow == fast){
				break;
			}
		}
		fast = head;
		while (fast != slow){
			fast = fast->next;
			slow = slow->next;
		}
		fast = fast->next;
		while (fast->next != slow){
			fast = fast->next;
		}
		fast->next = NULL;
	}
}

void print_list(Node *head){
#ifdef DEBUG
	printf("\ndebug: entering print_list.");
#endif
	Node *ptr = head;
	if (is_list_circular(head)){
		printf("\nCircular list.");
	}
	else {
		if (ptr != NULL){
			printf("\nThe values of the list are : ");
			while (ptr){
				if (ptr->type == INT_TYPE){
					printf(" [%d]-> ", *((int*)ptr->val), ptr);
				}
				else if (ptr->type == STRING_TYPE){
					printf(" [%s]-> ", ((char*)ptr->val), ptr);
				}
				else{
					printf(" [cannot print @ %p]-> ", ptr);
				}
				ptr = ptr->next;
			}
			printf("[NULL]\n");
		}
		else{
			printf("\nEmpty list.");
		}
	}
#ifdef DEBUG
	printf("\ndebug: exiting print_list.");
#endif
}

bool search_list_for_integer(Node *head, int val){
	Node * start = head;
	bool isFound = false;
	while (start != NULL){
		if (*(int*)start->val == val){
			isFound = true;
			break;
		}
		start = start->next;
	}
	return isFound;
}

bool delete_first_integer_value_matching_node(Node *head, int val){
	Node * prev = head;
	Node * curr = NULL;
	bool isDeleted = false;
	if (head->next != NULL){
		curr = head->next;
#ifdef DEBUG
		printf("\ndebug: at least two nodes exists.");
#endif
		while (curr != NULL && !isDeleted){
			if (*(int*)curr->val == val){
				prev->next = curr->next;
				isDeleted = true;
				//free curr here
			}
			prev = curr;
			curr = curr->next;
		}
	}
	else{
#ifdef DEBUG
		printf("\ndebug: only one node exists.");
#endif
		if (*(int*)prev->val == val){
			isDeleted = true;
			//free prev
			prev = NULL;
		}
	}
	return isDeleted;
}

bool delete_all_integer_value_matching_nodes(Node *head, int val){
	Node * prev = head;
	Node * curr = NULL;
	bool isDeleted = false;
	if (head->next != NULL){
		curr = head->next;
		while (curr != NULL){
			if (*(int*)curr->val == val){
				isDeleted = true;//at least deleted once.
				prev->next = curr->next;
				//free curr
			}
			prev = curr;
			curr = curr->next;
		}
	}
	else{//there is only one node
		if (*(int*)prev->val == val){
			isDeleted = true;
			prev = NULL;
		}
	}
	return isDeleted;
}

bool is_list_circular(Node *head){
	Node *slow = head;
	Node *fast = head;
	if (head && head->next){
		return false;
	}
	while (slow && fast && fast->next){
		fast = fast->next->next;
		slow = slow->next;
		if (slow == fast){
			return true;
		}
	}
	return false;
}

bool is_list_empty(Node *head){
	if (!head)
		return true;
	else
		return false;
}

Node * create_stack_from_existing_list(Node *otherListHead, Node *otherListUpto){
	/* theory : read from list, write to stack; first: implement stack. */
	return NULL;
}
