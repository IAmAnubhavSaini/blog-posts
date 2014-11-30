#include "integer linked list.h"


Node* create_node(int val){
#ifdef DEBUG
	printf("\ndebug: entering create_node with value : %d.", val);
#endif
	Node *ptr = (Node*)malloc(sizeof(Node));
	if (ptr == NULL){
		abort();
	}
	ptr->val = val;
	ptr->next = NULL;

	return ptr;
#ifdef DEBUG
	printf("\ndebug: exiting create_node.");
#endif
}

Node* add_to_list(Node *head, Node *curr, int val, bool before_head){
#ifdef DEBUG
	printf("\ndebug: entering add_to_list with value : %d.", val);
#endif
	Node *newTS = (Node*)malloc(sizeof(Node));
	if (is_list_empty(head)){
		return(create_node(val));
	}

	if (before_head) {
		newTS->val = val;
		newTS->next = head;
		head = newTS;
		return head;//try returning head so that further manipulation can start from right there.
	}
	else{
		newTS->val = val;
		newTS->next = NULL;
		curr->next = newTS;
		curr = newTS;
		return curr;//try returning current so that further manipulation can start from right there.
	}
#ifdef DEBUG
	printf("\ndebug: entering add_to_list.");
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
				printf(" [%d]-> ", ptr->val, ptr);
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

bool search_list(Node *head, int val){
	Node * start = head;
	bool isFound = false;
	while (start != NULL){
		if (start->val == val){
			isFound = true;
			break;
		}
		start = start->next;
	}
	return isFound;
}

bool delete_first_value_matching_node(Node *head, int val){
	Node * prev = head;
	Node * curr = NULL;
	bool isDeleted = false;
	if (head->next != NULL){
		curr = head->next;
#ifdef DEBUG
		printf("\ndebug: at least two nodes exists.");
#endif
		while (curr != NULL && !isDeleted){
			if (curr->val == val){
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
		if (prev->val == val){
			isDeleted = true;
			//free prev
			prev = NULL;
		}
	}
	return isDeleted;
}

bool delete_all_value_matching_nodes(Node *head, int val){
	Node * prev = head;
	Node * curr = NULL;
	bool isDeleted = false;
	if (head->next != NULL){
		curr = head->next;
		while (curr != NULL){
			if (curr->val == val){
				isDeleted = true;//at least deleted once.
				prev->next = curr->next;
				//free curr
			}
			prev = curr;
			curr = curr->next;
		}
	}
	else{//there is only one node
		if (prev->val == val){
			isDeleted = true;
			prev = NULL;
		}
	}
	return isDeleted;
}

bool is_list_circular(Node *head){
	Node *slow = head;
	Node *fast = head;
	while (slow && fast && fast->next && fast->next){
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
	Node *head = NULL;
	Node *tmp = NULL;

	if (!otherListHead){ // we don't really care about NULL Upto, since, that case we will be copying whole  ll.
		abort(); // reach violently to bad cases.
	}

	tmp = otherListHead;
	while (tmp != NULL && tmp != otherListUpto){
		head = add_to_list(head, NULL /* I know what I am doing */, tmp->val, true);
		tmp = tmp->next;
	}

	return head;
}
