#ifndef CHAR_STACK
#define CHAR_STACK

#include <stdio.h>
#include <stdlib.h>

typedef struct char_stack_item CharStackItem;
struct char_stack_item {
	char value;
	struct char_stack_item * next;
};

typedef struct char_stack CharStack;

void Push(CharStack * stack, char value);
char Pop(CharStack * stack);
CharStackItem * CreateEmptyCharStackItem();
CharStackItem * CreateCharStackItem(char value);

struct char_stack {
	struct char_stack_item * top;
	int count;
	int size;
	char (*Pop)(CharStack * stack);
	void (*Push)(CharStack * stack, char value);
};

void AbortIfMemoryAllocationFailed(void * ptr, char * whatIsNotAllocated, char * message){
	if(ptr == NULL){
		fprintf(stderr, "\nFatal ERROR while allocating memory for: %s.", whatIsNotAllocated);
		fprintf(stderr, message);
		abort();
	}
}

void CheckNullArgumentError(void * ptr, char * whatIsNull, char * message){
	if(ptr == NULL){
		fprintf(stderr, "\nArgument provided cannot be null: %s.", whatIsNull);
		fprintf(stderr, message);
		abort();
	}
}

void InvalidOperationError(char * function, char * message){
	fprintf(stderr, "\nInvalid operation performed in function %s.", function);
	fprintf(stderr, message);
}


void Push(CharStack * stack, char value){
	CharStackItem *item;
	if(stack->count < stack->size){
		item = CreateCharStackItem(value);
		stack->count++;
		item->next = stack->top;
		stack->top = item;
	}
}

char Pop(CharStack * stack){
	char value;
	CheckNullArgumentError(stack, "stack", "\nStack cannot be null while poping char value from it.");
	if(stack->top == NULL)
		InvalidOperationError("Pop", "Popping from stack");
	value = stack->top->value;
	stack->top = stack->top->next;
	stack->count--;
	return value;
}


CharStackItem * CreateEmptyCharStackItem(){
	return (CharStackItem*)malloc(sizeof(CharStackItem));
}

CharStackItem * CreateCharStackItem(char value){
	CharStackItem * item = CreateEmptyCharStackItem();
	AbortIfMemoryAllocationFailed(item, "item", "\nNot able to allocate memory");
	item->next = NULL;
	item->value = value;
	return item;
}

CharStack * CreateEmptyCharStack(){
	return (CharStack*)malloc(sizeof(CharStack));
}

CharStack * CreateCharStack(int size){
	CharStack * stack = CreateEmptyCharStack();
	AbortIfMemoryAllocationFailed(stack, "stack", "\nNot able to allocate memory");
	stack->size = size;
	stack->count = -1;
	stack->Pop = Pop;
	stack->Push = Push;
	return stack;
}

#endif //CHAR_STACK

int main(){
	CharStack * stack = CreateCharStack(100);
	stack->Push(stack, 'a');
	printf("\nPopped value : %c.", stack->Pop(stack));
	return 0;
}
