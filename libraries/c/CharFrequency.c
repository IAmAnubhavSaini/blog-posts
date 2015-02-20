#include "CharFrequency.h"

struct CharFrequency * SetupCharFrequency(char * input);
bool Contains(char key, struct CharFrequency * cf);
int GetValue(char key, struct CharFrequency * cf);
void PrintFrequencyList(struct CharFrequency * cf);
void PrintFrequencyMap(struct CharFrequency * cf);
char * Keys(struct CharFrequency * cf);

void Initialize(char *input, struct CharFrequency * cf);
struct CharFrequency * CreateEmptyCharFrequency();
struct CharIntNode * CreateEmptyCharIntNode();
struct CharIntNode * Insert(char key, struct CharIntNode * head);
void BumpFrequency(char key, struct CharIntNode * head);

bool Contains(char key, struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
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

int GetValue(char key, struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
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

void PrintFrequencyList(struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
	printf("\nPrinting frequency list:");
	while(curr != NULL){
		printf("\n %c - %i.", curr->key, curr->value);
		curr = curr->next;
	}
	printf("\n");
}

void PrintFrequencyMap(struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
	int i = 0, j = 0;
	printf("\nPrinting frequency map:");
	while(curr != NULL){
		printf("\n");
		for(i = 0; i < curr->value; i++)
			printf("%c", curr->key);
		curr = curr->next;
	}
	printf("\n");
}

char * Keys(struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
	char * keys = (char*)malloc(sizeof(char)*(cf->Count + 1));
	int i = 0;
	keys[cf->Count] = '\0';
	while(curr != NULL){
		keys[i++] = curr->key;
		curr = curr->next;
	}
	return keys;
}

void Initialize(char *input, struct CharFrequency * cf)
{
	if(cf == NULL) return;
	if(input == NULL) return;
	while(*input){
		if(!(cf->Contains(*input, cf))){
			cf->first = Insert(*input, cf->first);
			cf->Count++;
		}
		else {
			BumpFrequency(*input, cf->first);
		}
		input++;
	}
}

struct CharFrequency * SetupCharFrequency(char * input)
{
	struct CharFrequency * cf = CreateEmptyCharFrequency();
	cf->Contains = Contains;
	cf->GetValue = GetValue;
	cf->PrintFrequencyList = PrintFrequencyList;
	cf->PrintFrequencyMap = PrintFrequencyMap;
	cf->first = NULL;
	cf->Count = 0;
	cf->Keys = Keys;
	Initialize(input, cf);
	return cf;
}

struct CharFrequency * CreateEmptyCharFrequency()
{
	struct CharFrequency * cf = (struct CharFrequency *)malloc(sizeof(struct CharFrequency));
	if(cf == NULL){
		cf = (struct CharFrequency *)malloc(sizeof(struct CharFrequency));
	}
	return cf;
}

struct CharIntNode * CreateEmptyCharIntNode()
{
	struct CharIntNode * cin = (struct CharIntNode *)malloc(sizeof(struct CharIntNode));
	if(cin == NULL){
		cin = (struct CharIntNode *)malloc(sizeof(struct CharIntNode *));
	}
	return cin;
}

struct CharIntNode * Insert(char key, struct CharIntNode * head)
{
	struct CharIntNode * tmp = CreateEmptyCharIntNode();
	tmp->key = key;
	tmp->value = 1;
	tmp -> next = head;
	head = tmp;
	return head;
}

void BumpFrequency(char key, struct CharIntNode * head)
{
	struct CharIntNode * curr = head;
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