#include "CharFrequency.h"

bool Contains(char ch, struct CharFrequency * cf);
int GetFrequency(char ch, struct CharFrequency * cf);
void Initialize(char *input, struct CharFrequency * cf);
struct CharFrequency * SetupCharFrequency(char * input);
struct CharFrequency * CreateEmptyCharFrequency();

struct CharIntNode * CreateEmptyCharIntNode();
struct CharIntNode * Insert(char ch, struct CharIntNode * head);
void BumpFrequency(char ch, struct CharIntNode * head);

bool Contains(char ch, struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
	if(curr == NULL){
		return false;
	}
	while(curr != NULL){
		if(curr -> ch == ch)
			return true;
		curr = curr -> next;
	}
	return false;
}

int GetFrequency(char ch, struct CharFrequency * cf)
{
	struct CharIntNode * curr = cf->first;
	if(curr == NULL){
		return 0;
	} 
	while(curr != NULL){
		if(curr -> ch == ch)
			return curr -> f;
		curr = curr -> next;
	}
	return 0;
}

void Initialize(char *input, struct CharFrequency * cf)
{
	if(cf == NULL) return;
	if(input == NULL) return;
	while(*input){
		if(!(cf->Contains(*input, cf))){
			cf->first = Insert(*input, cf->first);
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
	cf->GetFrequency = GetFrequency;
	cf->first = NULL;
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
	struct CharIntNode * cin = (struct CharIntNode *)malloc(sizeof(struct CharIntNode *));
	if(cin == NULL){
		cin = (struct CharIntNode *)malloc(sizeof(struct CharIntNode *));
	}
	return cin;
}

struct CharIntNode * Insert(char ch, struct CharIntNode * head)
{
	struct CharIntNode * tmp = CreateEmptyCharIntNode();
	tmp -> ch = ch;
	tmp -> f = 1;
	tmp -> next = head;
	head = tmp;
	return head;
}

void BumpFrequency(char ch, struct CharIntNode * head)
{
	struct CharIntNode * curr = head;
	if(curr == NULL){
		return;
	}
	while(curr != NULL){
		if(curr -> ch == ch) {
			curr -> f = curr -> f + 1;
			return;
		}
		curr = curr -> next;
	}
}