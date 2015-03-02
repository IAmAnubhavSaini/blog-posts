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


struct bstNode {
	int value;
	struct bstNode * left;
	struct bstNode * right;
};

struct BinarySearchTree {
	int Count;
	struct bstNode * root;
	void (*Insert)(struct BinarySearchTree * root, int value);
};

struct BinarySearchTree * CreateBST();
struct bstNode * create_empty_node(void);
struct bstNode * create_node(int value);
void insert(struct bstNode ** root, int value);
void print_binary_tree_pre_order(struct bstNode *root);
void print_binary_tree_post_order(struct bstNode *root);
void print_binary_tree_in_order(struct bstNode *root);
void print_binary_tree_pre_order_recursive(struct bstNode *root);
void print_binary_tree_post_order_recursive(struct bstNode *root);
void print_binary_tree_in_order_recursive(struct bstNode *root);

#endif // TREE_H