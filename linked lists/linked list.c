#include "linked list.h"


Node* create_node(void* val, enum link_node_data_type type){
	int size;
	Node *ptr;
#ifdef DEBUG
	printf("\ndebug: entering create_node with value : %d.", val);
#endif
	size = sizeof(Node);
	ptr = (Node*)malloc(size);
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
	Node *newTS, *tmp;
#ifdef DEBUG
	printf("\ndebug: entering add_to_list with value.");
#endif
	newTS = create_node(val, type);
	tmp = head;
	while (tmp->next != NULL){
		tmp = tmp->next;
	}
	tmp->next = newTS;
#ifdef DEBUG
	printf("\ndebug: exiting add_to_list.");
#endif
}

void make_list_circular(Node *head){
	Node *tmp;
#ifdef DEBUG
	printf("\ndebug: entering make_list_circular.");
#endif
	tmp = head;
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
	Node *ptr;
#ifdef DEBUG
	printf("\ndebug: entering print_list.");
#endif
	ptr = head;
	if (is_list_circular(head)){
		printf("\nCircular list; not printing.");
	}
	else {
		if (ptr){
			printf("\nThe values of the list are : ");
			while (ptr){
				if (ptr->type == INT_TYPE){
					printf(" [%d]-> ", *((int*)ptr->val));
				}
				else if (ptr->type == STRING_TYPE){
					printf(" [%s]-> ", ((char*)ptr->val));
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
	if (head && !head->next){
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

void tail_insert_in_list(Node *head, void * val, enum link_node_data_type type)
{
	add_to_list(head, val, type);
}

void mid_insert_in_list(Node *head, void * val, enum link_node_data_type type)
{
	Node *fast = head;
	Node *slow = head;
	Node *tmp = NULL;
	if (!head)
		return;
	while (fast && slow && fast->next){
		fast = fast->next->next;
		slow = slow->next;
	}
	tmp = create_node(val, type);
	tmp->next = slow->next;
	slow->next = tmp;
}

void head_insert_in_list(Node *head, void * val, enum link_node_data_type type)
{
	Node *tmp = NULL;
	if (!head)
		return;
	tmp = create_node(val, type);
	tmp->next = head;
	head = tmp;
}

void insert_in_list_after(Node *head, void * insertVal, enum link_node_data_type type, void *searchVal)
{
	Node *tmp = NULL;
	Node *curr = head;
	if (!head)
		return;
	// implementation pending.
	//tmp = create_node(val, type);
}

void insert_in_list_before(Node *head, void * insertVal, enum link_node_data_type type, void *searchVal);

void insert_in_list(Node *head, void * val, enum link_node_data_type type, enum node_insertion_position position)
{
	if (position == INSERT_AT_END){
		tail_insert_in_list(head, val, type);
	}
	else if (position == INSERT_AT_START){
		head_insert_in_list(head, val, type);
	}
	else if (position == INSERT_AT_MID){
		mid_insert_in_list(head, val, type);
	}
}