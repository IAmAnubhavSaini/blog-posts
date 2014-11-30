#include "integer linked list.h"

Node *head = NULL;
Node *curr = NULL;

Node* create_list(int val){
	Node *ptr = (Node*)malloc(sizeof(Node));
	if (ptr == NULL){
		abort();
	}

	ptr->val = val;
	ptr->next = NULL;

	head = curr = ptr;
	return ptr;
}

Node* add_to_list(int val, bool before_head){
	Node *newTS = (Node*)malloc(sizeof(Node));
	if (is_list_empty()){
		return(create_list(val));
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
}

void make_list_circular(){
	Node * tmp = head;
	while(tmp && tmp->next){
		tmp = tmp->next;
	}
	tmp->next = head;
}

void print_list(){

	Node *ptr = head;
	if (is_list_circular()){
		printf("\nCircular list.");
	}
	else {
		if (ptr != NULL){
			printf("\nThe values of the list are\n");
			while (ptr){
				printf("[%d]->", ptr->val, ptr);
				ptr = ptr->next;
			}
			printf("[NULL]\n");
		}
		else{
			printf("\nEmpty list.");
		}
	}
}

bool search_list(int val){
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

bool delete_first_value_matching_node(int val){
	Node * prev = head;
	Node * curr = NULL;
	bool isDeleted = false;
	if (head->next != NULL){
		curr = head->next;
		// add a debugging compiler switch printf("\ndebug: at least two nodes exists.");
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
		// use compiler switch printf("\ndebug: only one node exists.");
		if (prev->val == val){
			isDeleted = true;
			//free prev
			prev = NULL;
		}
	}
	return isDeleted;
}

bool delete_all_value_matching_nodes(int val){
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

bool is_list_circular(){
	Node *slow = head;
	Node *fast = head;
	while (slow && fast && fast->next && fast->next){
		fast = fast->next->next;
		slow = slow->next;
		if (slow == fast){
			return true;
		}
	}
	if (!fast || !fast->next || !fast->next->next){
		return false;
	}
}

bool is_list_empty(){
	if (!head)
		return true;
	else
		return false;
}