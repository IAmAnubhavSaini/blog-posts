#include "integer linked list test.h"

void fire(){
	printf("\n\nFiring test 1\n");
	TEST_setup1();
	printf("\n\nFiring test 2\n");
	TEST_search1();
	printf("\n\nFiring test 3\n");
	TEST_delete1();
	printf("\n\nFiring test 4\n");
	TEST_setup1();
	printf("\n\nFiring test 5\n");
	TEST_delete2();
	printf("\n\nFiring test 6\n");
	TEST_circular_list();

}

int main(){
	fire();
	return 0;
}

