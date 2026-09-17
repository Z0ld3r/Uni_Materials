#include <stdio.h>
#include "utils.h"

int main() {
	f();
	for (int i = 0; i < 10; ++i) {
		static_test();
	}
	int a = 42, b = 69;
	printf("a: %d, b: %d\n", a, b);
	swap(&a, &b);
	printf("a: %d, b: %d\n", a, b);
	int* max_ptr = max(&a, &b);
	printf("Max id: %d, value: %d\n", max_ptr, *max_ptr);
	
	/*
	GCC:
	void swap(int* a, int* b) {
		int c = *a;
		*a = *b;
		*b = c;
		printf("SWAPPED\n");
	}
	swap(&a, &b);
	printf("a: %d, b: %d\n", a, b);
	*/
	for (int i = 1; i < 10; ++i) {
		for (int j = 1; j < i; ++j) {
			printf("%d\n", i*j);
		}
	}
	/*
	1. Hozz létre egy függvényt, ami faktoriálist számol
	   n! = 1*2*...*n (0! = 1)
	   Tartsd számon, hányszor volt a függvény meghívva 0-nál
	   kisebb értékkel (static)
	*/
	for (int i = -2; i < 6; ++i) {
		printf("Factorial of %d is %d\n", i, factor(i));
	}
	for (int i = 0; i < 5; ++i) {
		printf("Factorial of %d is %d\n", i, factor_rec(i));
	}

	return 0;
}