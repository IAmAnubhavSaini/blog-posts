#include "IntFrequency.h"

bool Contains(int key, struct IntFrequency * cf);
int GetValue(int key, struct IntFrequency * cf);
void PrintFrequencyList(struct IntFrequency * cf);
void PrintFrequencyMap(struct IntFrequency * cf);
int * Keys(struct IntFrequency * cf);
void Remove(int key, struct IntFrequency * cf);

void Initialize(int input[], int count, struct IntFrequency * cf);
struct IntFrequency * CreateEmptyIntFrequency();
struct IntIntNode * CreateEmptyIntIntNode();
struct IntIntNode * Insert(int key, struct IntIntNode * head);
void BumpFrequency(int key, struct IntIntNode * head);

bool Contains(int key, struct IntFrequency * cf)
{
	struct IntIntNode * curr = cf->first;
	if(curr == NULL){
		return false;
	}
	while(curr != NULL){
		if(curr->key == key)
			return true;
		curr = curr -> next;
	}
	return false;
}

int GetValue(int key, struct IntFrequency * cf)
{
	struct IntIntNode * curr = cf->first;
	if(curr == NULL){
		return 0;
	} 
	while(curr != NULL){
		if(curr->key == key)
			return curr->value;
		curr = curr -> next;
	}
	return 0;
}

void PrintFrequencyList(struct IntFrequency * cf)
{
	struct IntIntNode * curr = cf->first;
	printf("\nPrinting frequency list:");
	while(curr != NULL){
		printf("\n %i - %i.", curr->key, curr->value);
		curr = curr->next;
	}
	printf("\n");
}

void PrintFrequencyMap(struct IntFrequency * cf)
{
	struct IntIntNode * curr = cf->first;
	int i = 0, j = 0;
	printf("\nPrinting frequency map:");
	while(curr != NULL){
		printf("\n");
		for(i = 0; i < curr->value; i++)
			printf("%i", curr->key);
		curr = curr->next;
	}
	printf("\n");
}

int * Keys(struct IntFrequency * cf)
{
	struct IntIntNode * curr = cf->first;
	int * keys = (int*)malloc(sizeof(int)*cf->Count);
	int i = 0;
	while(curr != NULL){
		keys[i++] = curr->key;
		curr = curr->next;
	}
	return keys;
}

void Remove(int key, struct IntFrequency * cf)
{
	struct IntIntNode * prev, * curr;
	prev = curr = cf->first;
	if(curr == NULL)
		return;
	if(curr->key == key){
		curr = curr -> next;
		free(prev);
		cf->first = curr;
		cf->Count--;
	}
	while(curr != NULL){
		if(curr->key == key){
			prev->next = curr->next;
			free(curr);
			cf->Count--;
			return;
		}
		prev = curr;
		curr = curr->next;
	}
}

void Initialize(int input[], int count, struct IntFrequency * cf)
{
	int i = 0;
	if(cf == NULL) return;
	while(i < count){
		if(!(cf->Contains(input[i], cf))){
			cf->first = Insert(input[i], cf->first);
			cf->Count++;
		}
		else {
			BumpFrequency(input[i], cf->first);
		}
		i++;
	}
}

struct IntFrequency * SetupIntFrequency(int input[], int count)
{
	struct IntFrequency * cf = CreateEmptyIntFrequency();
	cf->Contains = Contains;
	cf->GetValue = GetValue;
	cf->PrintFrequencyList = PrintFrequencyList;
	cf->PrintFrequencyMap = PrintFrequencyMap;
	cf->first = NULL;
	cf->Count = 0;
	cf->Keys = Keys;
	cf->Remove = Remove;
	Initialize(input, count, cf);
	return cf;
}

struct IntFrequency * CreateEmptyIntFrequency()
{
	struct IntFrequency * cf = (struct IntFrequency *)malloc(sizeof(struct IntFrequency));
	if(cf == NULL){
		cf = (struct IntFrequency *)malloc(sizeof(struct IntFrequency));
	}
	return cf;
}

struct IntIntNode * CreateEmptyIntIntNode()
{
	struct IntIntNode * iin = (struct IntIntNode *)malloc(sizeof(struct IntIntNode));
	if(iin == NULL){
		iin = (struct IntIntNode *)malloc(sizeof(struct IntIntNode));
	}
	return iin;
}

struct IntIntNode * Insert(int key, struct IntIntNode * head)
{
	struct IntIntNode * tmp = CreateEmptyIntIntNode();
	tmp->key = key;
	tmp->value = 1;
	tmp -> next = head;
	head = tmp;
	return head;
}

void BumpFrequency(int key, struct IntIntNode * head)
{
	struct IntIntNode * curr = head;
	if(curr == NULL){
		return;
	}
	while(curr != NULL){
		if(curr->key == key) {
			curr->value = curr->value + 1;
			return;
		}
		curr = curr -> next;
	}
}