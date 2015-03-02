#include "tree.h"

#define SIZE 20

char in_output[SIZE];
char pre_output[SIZE];
char post_output[SIZE];

void ClearOutput(){
	int i = 0;
	for(i = 0; i < SIZE; i++){
		in_output[i] = '\0';
		pre_output[i] = '\0';
		post_output[i] = '\0';
	}
}
void SetOutput(char *in, char * pre, char *post){
	int i = 0;
	ClearOutput();
	for(i = 0; i < SIZE && in[i] != '\0'; i++)
		in_output[i] = in[i];
	for(i = 0; i < SIZE && pre[i] != '\0'; i++)
		pre_output[i] = pre[i];
	for(i = 0; i < SIZE && post[i] != '\0'; i++)
		post_output[i] = post[i];
}

struct BinarySearchTree *  LeftHeavyTree1(){
	struct BinarySearchTree * tree = CreateBST();
	ClearOutput();
	tree->Insert(tree, 1);
	tree->Insert(tree, 2);
	tree->Insert(tree, 3);
	tree->Insert(tree, 4);
	tree->Insert(tree, 5);
	SetOutput("12345", "12345", "54321");
	return tree;
}

struct BinarySearchTree * SampleTree1()
{
	struct BinarySearchTree * tree = CreateBST();
	ClearOutput();
	tree->Insert(tree, 1);
	tree->Insert(tree, 2);
	tree->Insert(tree, 3);
	tree->Insert(tree, 4);
	tree->Insert(tree, 5);
	SetOutput("12345", "12345", "54321");
	return tree;
}

void Test(struct BinarySearchTree * inputTree){
	struct bstNode * root = inputTree->root;
	if(root == NULL) return;
	printf("\nTesting tree --------------");
	printf("\npre order output: "); print_binary_tree_pre_order_recursive(root);
	printf("\t; should be: %s", pre_output);
	printf("\nin order output: "); print_binary_tree_in_order_recursive(root);
	printf("\t; should be: %s", in_output);
	printf("\npost order: "); print_binary_tree_post_order_recursive(root);
	printf("\t; should be: %s", post_output);
	printf("\nTesting Ends --------------\n\n");
}

int main()
{
	Test(LeftHeavyTree1());
	Test(SampleTree1());
	return 0;
}
