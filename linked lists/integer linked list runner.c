#include "integer linked list test.h"

void fireTests(){
	printf(FT_1);
	TEST_setup1();
	printf(FT_2);
	TEST_search1();
	printf(FT_3);
	TEST_delete1();
	printf(FT_4);
	TEST_setup1();
	printf(FT_5);
	TEST_delete2();
	printf(FT_6);
	TEST_circular_list();
}

int main(){
	fireTests();
	return 0;
}

