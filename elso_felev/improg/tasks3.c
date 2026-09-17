#include <stdio.h>
#include <stdlib.h>
#include <time.h>

char getChar(){
	char c;
	do{
		c = getchar();
	} while (c=='\n');
	return c;
}

void rand50(){
	int T[100];
	int len = 100;
	int count = 0;
	for (int i=0; i<(len-1); i++){
		T[i] = rand()%100;
		if (T[i]>50){
			count++;
		}
	}
	printf("%d\n", count);
}

int main(){
	srand(time(NULL));
	/*
	int clen = 127;
	char c[128];
	printf("Enter a number");
    int ch;
	int i =0;
    while ((ch = getchar()) != '\n' && ch != EOF && i < clen) {
        c[i++] = ch;
    }
	char temp = c[0];
	c[0] = c[clen];
	c[clen] = temp;
	printf("%c\n", c);
	
	*/
	
	rand50();
	
	return 0;
}