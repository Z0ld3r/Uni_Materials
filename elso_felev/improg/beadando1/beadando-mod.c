#include <stdio.h>
void menu() {
	printf("-- Menu --\n");
	printf("1. Letter\n");
	printf("2. Number\n");
	printf("3. Exit\n");
}

void nError(const char* errorMessage) {
	printf("Error: %s\n", errorMessage);
}

char getChar(){
		char c;
		do {
			c=getchar();
		} while (c =='\n' && c != '-');
		return c;
}

int main() {
	char k;
	char b, n;
	int c, i; /*, scanResult; */
	do{
		
		menu();
		do {
		k = getChar();
		} while (k!>= '0' && k!<= '9')
		if (k=='1') {
			printf("A letter:\n");
			b = getChar();
			if ((b >= 'a' && b<= 'z') || (b >= 'A' && b<= 'Z')){
				printf("How many?");
				/* scanResult = ; */
				if (scanf("%d", &c)){
					for(i=0; i<c; i++){
						printf("%c\n", b);
					}
				}
				else{
					nError("Please enter a valid number!");
				}
			}
			else{
				nError("Please enter a valid letter!");
			}
		}
		else if(k=='2') {
			printf("A number:\n");
			n = getChar();
			if (n >= '0' && n<= '9'){
				printf("How many?");
				if (scanf("%d", &c)){
					for(i=0; i<c; i++){
						printf("%c\n", n);
					}
				}
				else{nError("Please enter a valid number!");}
			}
			else{
				nError("Please enter a valid number!");
			}
		}
		else if(k !='3' && k != EOF && k!='1' && k!='2'){
			nError("Not valid input");
		}
	}
	while(k !='3' && k != EOF);
	printf("Exiting...");
	return 0;
}