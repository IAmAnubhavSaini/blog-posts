#include <stdio.h>
#include <stdlib.h>

struct linked_node{
	int value;
	struct linked_node * next;
};
typedef struct linked_node node;

struct linked_list{
	node * head;
	node * tail;
	int count;
};
typedef struct linked_list linked_list;

enum position{
	END, START, MID
};
typedef enum position position;


node * create_empty_node(void);
node * create_node(int val);
node * insert_at_end(node* head, int val);
node * insert_at_start(node*head, int val);
node * insert_at_mid(node* head, int val);
node * insert(node*head, int val, position pos);
node * replace_head(node*head, int val);
node * replace_tail(node*head, int val);
node * replace_mid(node * head, int val);
node * replace(node * head, int val, position pos);

void print_list(node*head);

int main(){
	node * head = create_node(1);
	print_list(head);
	head = insert(head, 2, END);
	print_list(head);
	head = insert(head, 3, START);
	print_list(head);
	head = insert(head, 4, MID);
	print_list(head);
	head = replace_head(head, 40);
	print_list(head);
	head = replace_tail(head, 80);
	print_list(head);
	head = replace_mid(head, 120);
	print_list(head);
	head = replace(head, 800, START);
	print_list(head);
	return 0;
}

node * create_empty_node()
{
	return (node*)malloc(sizeof(node));
}

node * create_node(int val)
{
	node * tmp = create_empty_node();
	if (!tmp)
		abort();
	tmp->next = NULL;
	tmp->value = val;
	return tmp;
}

node * insert_at_end(node* head, int val)
{
	node* curr = head;
	if (!curr)
		return NULL;
	while (curr->next)
		curr = curr->next;
	curr->next = create_node(val);
	return head;
}

node * insert_at_start(node*head, int val)
{
	node *curr = NULL;
	if (!head)
		return NULL;
	curr = create_node(val);
	curr->next = head;
	head = curr;
	return head;
}

node * insert_at_mid(node* head, int val)
{
	node *curr = NULL;
	node *slow = head;
	node *fast = head;
	while (fast && fast->next){
		fast = fast->next->next;
		if (fast)
			slow = slow->next;
	}
	curr = create_node(val);
	curr->next = slow->next;
	slow->next = curr;
	return head;
}

node * insert(node*head, int val, position pos)
{
	if (pos == END)
		head = insert_at_end(head, val);
	else if (pos == START)
		head = insert_at_start(head, val);
	else if (pos == MID)
		head = insert_at_mid(head, val);
	return head;
}

void print_list(node *head)
{
	node*tmp = head;
	printf("\n");
	while (tmp){
		printf("\t%d->", tmp->value);
		tmp = tmp->next;
	}
	printf("\n");
}

node * replace_head(node*head, int val)
{
	node *curr = NULL;
	if (!head)
		return NULL;
	curr = create_node(val);
	curr->next = head->next;
	free(head);
	head = curr;
	return head;
}

node * replace_tail(node*head, int val)
{
	node* curr = head;
	if (!curr)
		return NULL;
	while (curr->next && curr->next->next)
		curr = curr->next;
	free(curr->next);
	curr->next = create_node(val);
	return head;
}

node * replace_mid(node * head, int val)
{
	node *curr = NULL;
	node *slow = head;
	node *fast = head;
	while (fast && fast->next){
		fast = fast->next->next;
		if (fast)
			slow = slow->next;
	}
	curr = create_node(val);
	curr->next = slow->next->next;
	free(slow->next);
	slow->next = curr;
	return head;
}

node * replace(node * head, int val, position pos)
{
	if (pos == END)
		head = replace_tail(head, val);
	else if (pos == START)
		head = replace_head(head, val);
	else if (pos == MID)
		head = replace_mid(head, val);
	return head;
}
