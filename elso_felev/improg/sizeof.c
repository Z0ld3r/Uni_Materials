#include <stdio.h>
#include <time.h>
#include <stdlib.h>
/*
int main(){
	printf("char: %d\n", sizeof(char))
	printf("int: %d\n", sizeof(int))
	printf("long int: %d\n", sizeof(long int))
	printf("unsigned int: %d\n", sizeof(unsigned int))
}
*/

void leap_year(){
	printf("A year:");
	int year;
	scanf("%d", year);
	printf("%d year is %sa leapyear\n", year, (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) ? "": "not ");
}

int main(){
	dice();
	return 0;
}

void dice() {
	srand(time(NULL));
	for(int i = 0; i<10; i++){
		int x = rand() % 6 + 1;
		printf("Random number: %d", x);
	}
}