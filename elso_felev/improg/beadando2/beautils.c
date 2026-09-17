#include "beautils.h"
#include <stdio.h>
#include <string.h>


void menu() {
	printf(
	"\n-- Menu --\n1. Add\n2. Remove\n3. Print\n4. Count\n5. Clear\n6. Exit\n");
}

void exiting(){
	printf("Exiting...");
}

void input_error(){
	printf("Please enter one of the options!\n");
}


void add(int* tomb, int* ps) {
	int ad;
	if (*ps != 128){
		printf("Enter the number you'd like to add!\n");
		scanf("%d",&ad);
		tomb[*ps] = ad;
		(*ps)++;
		printf("%d added successfully.\n",ad);
	}
	else {
		printf("The array is already full, remove something to add a new element!\n");
	}
}

void rremove(int* tomb, int* ps){
	int n, i;
	printf("Enter the index of the element you'd like to remove!\n");
	scanf("%d",&n);
	if ((n<*ps) && (n>=0)){
		printf("%d removed successfully.\n",tomb[n]);
		for(i = 0; i<(*ps-n); ++i){
			tomb[n] = tomb[n+i];
		}
		(*ps)--;
	}
	else{
		printf("You've entered an index out of the array's range.\nPlease enter a different index!\n");
	}
}





void print(int* tomb, int* ps){
	int i;
	if (*ps != 0){	
		printf("The elements of the array in an order:\n");
		for (i=0; i<*ps;i++){
			printf("%d ",tomb[i]);
		}
		printf("\n");
	}
	else{
		printf("The array is empty.\n");
	}
}


void count(int* tomb, int* ps){
	int in, i, c = 0;
	printf("Please enter the number you'd like to count!\n");
	scanf("%d",&in);
	for (i=0;i<*ps;i++){
		if(tomb[i]==in){
			c++;
		}
	}
	if (c==0){
		printf("There is no occurrance of %d in the array.\n",in);
	}
	else if (c==1){
		printf("There is %d occurrence of %d in the array.\n",c,in);
	}
	else{
		printf("There are %d occurrences of %d in the array.\n",c,in);
	}
}

void clear(int* tomb, int* ps){
	int i;
	for (i=0;i<*ps;i++){
		tomb[i]=0;
	}
	*ps = 0;
	printf("The array has been cleared successfully.\n");
}
