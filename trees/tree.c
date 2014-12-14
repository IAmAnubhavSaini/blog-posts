#include "tree.h"

struct binaryTree * create_empty_node(void)
{
	return (struct binaryTree *)malloc(sizeof(struct binaryTree));
}

struct binaryTree * create_node(int value)
{
	struct binaryTree * tmp = create_empty_node();
	if (!tmp)
		printf("\nERROR: cannot create another node for binary tree.");
	tmp->left = NULL;
	tmp->right = NULL;
	tmp->value = value;
	return tmp;
}

bool insert(struct binaryTree * root, int value, enum position pos)
{
	struct binaryTree * curr = root;
	struct binaryTree * tmp = NULL;
	if (!curr)
		return false;

	tmp = create_node(value);
	if (pos == LEFT){
		while (curr->left){
			curr = curr->left;
		}
		curr->left = tmp;
	}
	else{
		while (curr->right){
			curr = curr->right;
		}
		curr->right = tmp;
	}
	return true;
}

void print_binary_tree_pre_order(struct binaryTree *root)
{

}
void print_binary_tree_post_order(struct binaryTree *root);
void print_binary_tree_in_order(struct binaryTree *root);

void print_binary_tree_pre_order_recursive(struct binaryTree *root)
{
	// root, left, right traversal
	struct binaryTree * curr = root;
	if (curr){
		printf(" %d ", curr->value);
		print_binary_tree_pre_order_recursive(curr->left);
		print_binary_tree_pre_order_recursive(curr->right);
	}
}

void print_binary_tree_post_order_recursive(struct binaryTree *root)
{
	struct binaryTree * curr = root;
	if (curr){
		print_binary_tree_pre_order_recursive(curr->left);
		print_binary_tree_pre_order_recursive(curr->right);
		printf(" %d ", curr->value);
	}
}
void print_binary_tree_in_order_recursive(struct binaryTree *root)
{
	struct binaryTree * curr = root;
	if (curr){
		print_binary_tree_pre_order_recursive(curr->left);
		printf(" %d ", curr->value);
		print_binary_tree_pre_order_recursive(curr->right);
	}
}


struct binaryTree * create_sample_tree()
{
	struct binaryTree * tree = create_node(1);
	insert(tree, 2, LEFT);
	insert(tree, 3, RIGHT);
	insert(tree, 4, LEFT);
	insert(tree, 5, RIGHT);
	return tree;
}

int main()
{
	struct binaryTree * tree = create_sample_tree();
	printf("\npre order: "); print_binary_tree_pre_order_recursive(tree);
	printf("\nin order: "); print_binary_tree_in_order_recursive(tree);
	printf("\npost order: "); print_binary_tree_post_order_recursive(tree);
	return 0;
}