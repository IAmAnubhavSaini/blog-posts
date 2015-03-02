#include "tree.h"

void Insert(struct BinarySearchTree * tree, int value)
{
	insert(&tree->root, value);
	tree->Count += 1;
}

struct BinarySearchTree * CreateBST()
{
	struct BinarySearchTree * tmp = (struct BinarySearchTree *)malloc(sizeof(struct BinarySearchTree));
	tmp->Count = 0;
	tmp->root = NULL;
	tmp->Insert = Insert;
	return tmp;
}

struct bstNode * create_empty_node(void)
{
	return (struct bstNode *)malloc(sizeof(struct bstNode));
}

struct bstNode * create_node(int value)
{
	struct bstNode * tmp = create_empty_node();
	if (!tmp){
		printf("\nERROR: cannot create another node for binary tree.");
		abort(); // come down crashing.
	}
	tmp->left = NULL;
	tmp->right = NULL;
	tmp->value = value;
	return tmp;
}

void insert(struct bstNode ** root, int value)
{
	struct bstNode * curr = *root;
	struct bstNode * tmp = NULL;
	if(curr == NULL){
		*root = create_node(value);
		return;
	}
	
	if (value <= curr->value){
		if(curr->left != NULL){
			insert(&curr->left, value);
		} else{
			tmp = create_node(value);
			curr->left = tmp;
			printf("\nInserting in left: %i -left> %i.", curr->value, curr->left->value);
		}
	}
	else {
		if(curr->right != NULL){
			insert(&curr->right, value);
		} else{
			tmp = create_node(value);
			curr->right = tmp;
			printf("\nInserting in right: %i -right> %i.", curr->value, curr->right->value);
		}
	}
}

void print_binary_tree_pre_order(struct bstNode *root)
{

}
void print_binary_tree_post_order(struct bstNode *root);
void print_binary_tree_in_order(struct bstNode *root);

void print_binary_tree_pre_order_recursive(struct bstNode *root)
{
	// root, left, right traversal
	struct bstNode * curr = root;
	if (curr){
		printf("%i", curr->value);
		print_binary_tree_pre_order_recursive(curr->left);
		print_binary_tree_pre_order_recursive(curr->right);
	}
}

void print_binary_tree_post_order_recursive(struct bstNode *root)
{
	struct bstNode * curr = root;
	if (curr){
		print_binary_tree_post_order_recursive(curr->left);
		print_binary_tree_post_order_recursive(curr->right);
		printf("%i", curr->value);
	}
}
void print_binary_tree_in_order_recursive(struct bstNode *root)
{
	struct bstNode * curr = root;
	if (curr){
		print_binary_tree_in_order_recursive(curr->left);
		printf("%i", curr->value);
		print_binary_tree_in_order_recursive(curr->right);
	}
}
