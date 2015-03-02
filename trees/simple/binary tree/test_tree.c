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

struct binaryTree * LeftHeavyTree1(){
	struct binaryTree * tree = create_node(1);
	insert(tree, 2, LEFT);
	insert(tree, 3, LEFT);
	insert(tree, 4, LEFT);
	insert(tree, 5, LEFT);
	SetOutput("54321", "12345", "54321");
	return tree;
}

struct binaryTree * SampleTree1()
{
	struct binaryTree * tree = create_node(1);
	ClearOutput();
	insert(tree, 2, LEFT);
	insert(tree, 3, RIGHT);
	insert(tree, 4, LEFT);
	insert(tree, 5, RIGHT);
	SetOutput("42135", "12435", "42531");
	return tree;
}

void Test(struct binaryTree * inputTree){
	struct binaryTree * tree = inputTree;
	if(tree == NULL) return;
	printf("\nTesting tree --------------");
	printf("\npre order output: "); print_binary_tree_pre_order_recursive(tree);
	printf("\npre should be: %s", pre_output);
	printf("\nin order output: "); print_binary_tree_in_order_recursive(tree);
	printf("\nin should be: %s", in_output);
	printf("\npost order: "); print_binary_tree_post_order_recursive(tree);
	printf("\npost should be: %s", post_output);
	printf("\nTesting Ends --------------\n\n");
}

int main()
{
	Test(LeftHeavyTree1());
	Test(SampleTree1());
	return 0;
}
