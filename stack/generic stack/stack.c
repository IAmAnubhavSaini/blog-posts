#include "stack.h"

void Push(struct Stack * stack, void * data);
void * Pop(struct Stack * stack);

struct Stack * CreateStack()
{
	struct Stack * stack = (struct Stack *)malloc(sizeof(struct Stack));
	if(stack == NULL){
		printf("\nCannot create stack. Aborting.");
		abort();
	}
	stack -> Top = NULL;
	stack -> Push = Push;
	stack -> Pop = Pop;
	return stack;
}

struct stackNode * CreateNode(void * data)
{
	struct stackNode * node = (struct stackNode *)malloc(sizeof(struct stackNode));
	if(node == NULL){
		printf("\nCannot create a stack node. Aborting.");
		abort();
	}
	node -> next = NULL;
	node -> data = data;
	return node;
}

void Push(struct Stack * stack, void * data)
{
	
}
void * Pop(struct Stack * stack)
{
}