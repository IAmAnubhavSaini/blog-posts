#ifndef TREE_H
#define TREE_H

#include <stdio.h>
#include <stdlib.h>

#ifndef bool
#define bool int
#endif

#ifndef true
#define true 1
#endif

#ifndef false
#define false 0
#endif

struct binaryTree {
	int value;
	struct binaryTree * left;
	struct binaryTree * right;
};
enum position{
	LEFT, RIGHT
};

struct binaryTree * create_empty_node(void);
struct binaryTree * create_node(int value);
bool insert(struct binaryTree * root, int value, enum position pos);
void print_binary_tree_pre_order(struct binaryTree *root);
void print_binary_tree_post_order(struct binaryTree *root);
void print_binary_tree_in_order(struct binaryTree *root);
void print_binary_tree_pre_order_recursive(struct binaryTree *root);
void print_binary_tree_post_order_recursive(struct binaryTree *root);
void print_binary_tree_in_order_recursive(struct binaryTree *root);



#endif // TREE_H