#include <stdio.h>

char getChar(){
		char c;
		do {
			c=getchar();
		} while (c );
		return c;
}
void change() {
	char c;
	do {	
		printf("The letter:");
		c = getChar();
		if (c>= 'a' && c<= 'z') {
			c -= 32;
		}
		else if (c>= 'A' && c<='Z') {
			c += 32;
		}
		else {
			printf("%c is not a lower or uppercase letter",c);
		}
		printf("c: %c\n",c);
	} while ( c!=EOF);
}

int main() {
	change();

	return 0;
}