#include <stdio.h>
/*
int sum(int t[], int l) {
	int s = 0;
	for (int i = 0; i<l; i++){
		s += t[i];
	}
}

int sum3(int* t[], int l) {
	int s = 0;
	for (int i = 0; i<l; i++){
		s += *(t+i);
	}
}
	
int sum4(int* first, int* after_last) {
	int s = 0;
	for (int* i = first; i<after_last; i++){
		s += *i;
	}
}

// nem jo mert valtozo return utan megszunik
int* local_var() {
	int a= 10;
	return &a;
}
*/
int maxp(int t[], int l) {
	for (int i = 0; i<l; i++) {
		int* p = &t[i];
	}
	return *p;
}

00



int main() {
	int t[] = {1,2,3};
	printf("The memory adress of the last number in t: %d\n", maxp(t, sizeof(t)/sizeof(t[0])));
	
	return 0;
}

