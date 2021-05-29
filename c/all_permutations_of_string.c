#include <stdio.h>

void swap(char *x, char *y) {
    char temp = *x;
    *x = *y;
    *y = temp;
}

void permute(char *str, int start, int end) {
    int j = start;
    if (start == end) {
        printf("\t%s\n", str);
    } else {
        for (j = start; j <= end; j++) {
            swap((str + start), (str + j));
            permute(str, start + 1, end);
            swap((str + start), (str + j));
        }
    }
}

void sample1() {
    char a[] = "abc";
    printf("\n--- Permutations for %s: \n", a);
    permute(a, 0, 2);
}

void sample2() {
    char a[] = "abcd";
    printf("\n--- Permutations for %s: \n", a);
    permute(a, 0, 3);
}

int main() {
    sample1();
    sample2();
    return 0;
}