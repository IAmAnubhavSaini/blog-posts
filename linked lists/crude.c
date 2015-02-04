#include <stdio.h>
#include <stdlib.h>

struct linked_node{
	int value;
	struct linked_node * next;
};
typedef struct linked_node node;

struct node_cache{
	int count;
	node *cache;
};

typedef struct node_cache cache;

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

linked_list create_linked_list(int values[]);
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
node * last_node(node *anyNode);
void append(node * tail, int val);
void print_list(node*head);

cache create_cache();

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

linked_list create_linked_list(int values[])
{
	linked_list list;
	int count = sizeof(values)/sizeof(int);
	int i;

	list.tail = list.head = create_node(values[0]);
	list.count = 1;

	for(i = 1; i < count; i++){
		append(list.tail, values[i]);
		list.count++;
	}
	return list;
}

node * last_node(node *anyNode)
{
	node * curr = anyNode;
	if(curr == NULL) return NULL;
	while(curr->next != NULL) curr = curr->next;
	return curr;
}

void append(node * tail, int val)
{
	node * last = last_node(tail);
	last->next = create_node(val);
}


cache create_cache()
{
	cache cache;
	node * tail = NULL;
	int i = 0;
	cache.count = 1024;
	tail = cache.cache = create_node(i);
	for(i = 1; i < cache.count; i++){
		append(tail, i);
	}
	return cache;
}

node * get_node_from_cache(cache cache)
{
	node * tmp;
	if(cache.count > 0){
		tmp = cache.cache;
		cache.cache = cache.cache->next;
		tmp->next = NULL;
		cache.count--;
	}
	else {
		int i = 0;
		node * tail = NULL;
		cache.count = 1024;
		tail = cache.cache = create_node(i);
		for(i = 1; i < cache.count; i++){
			append(tail, i);
		}
		tmp = get_node_from_cache(cache);
	}
	return tmp;
}