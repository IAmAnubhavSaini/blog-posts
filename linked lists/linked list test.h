#ifndef INTEGER_LINKED_LIST_TEST_H
#define INTEGER_LINKED_LIST_TEST_H

#include "testing constants.h"
#include "linked list.h"


Node *    TEST_should_setup_and_confim_via_printing(void);
void      TEST_should_find_number_in_list(void);
void      TEST_should_not_find_number_in_list(void);
void      TEST_should_delete_numbers_first_occurence(void);
void      TEST_should_delete_all_occurences_on_a_number(void);
void      TEST_shoud_not_be_a_circular_list(void);
void      TEST_shoud_be_a_circular_list(void);
void      TEST_stack_should_be_reverse_of_the_list(void);
void      TEST_should_make_a_circular_list_acircular(void);
void      TEST_should_add_node_at_beginning_of_list(void);
void      TEST_should_add_node_at_end_of_list(void);
void      TEST_should_add_node_at_mid_of_list(void);

#endif //INTEGER_LINKED_LIST_TEST_H