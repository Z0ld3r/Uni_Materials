#include "utils.h"
#include <stdio.h>

void f() {}
void static_test() {
    static int var = 0;
    var += 1;
    printf("var: %d\n", var);
}

void swap(int* a, int* b) {
    int c = *a;
    *a = *b;
    *b = c;
/*
   int* c = a;
   a = b;
   b = c;
   NEM MUKODIK
*/
}

int* max(int* a, int* b) {
    /*
    if (*a < *b) { return b; }
    return a;

    if (*a < *b ) { return b; }
    else { return a; }
    */
   return *a < *b ? b : a;
}

int factor(int n) {
    static int less_than_zero_counter = 0;
    if (n < 0) {
        less_than_zero_counter++;
        printf("Param %d i less than 0\n", n);
        printf("There were %d negative param\n", less_than_zero_counter);
        return 0;
    }
    int result = 1;
    for (int i = 1; i <= n; ++i) {
        result *= i;
    }
    return result;
}

int factor_rec(int n) {
    if (n == 0 || n == 1) { return 1; }
    return n * factor_rec(n-1); 
}