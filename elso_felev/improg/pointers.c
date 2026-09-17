#include <stdio.h>

int main() {
	int a = 10;
	printf("%a : %d\n", &a);
	
	int* p = &a;
	printf("p: %d\n", p);
	printf("p*: %d\n", p*);
	
	*p = 20;
	printf("a : %d\n", a)
	
	int** q = &p;


	return 0;
}