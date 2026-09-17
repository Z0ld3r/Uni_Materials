#include <stdio.h>
#include <math.h>
char getChar(){
	char c;
	do{
		c = getchar();
	} while (c=='\n');
	return c;
}

void convertIntFromHex(char* hex_n, int hex_c_n){
	int result;
	for (int i=0; i< hex_c_n; i++){
		int n;
		if ('0' < hex_n[i] && hex_n[i] < '9'){
			n = hex_n[i] - '0';
		}
		if('a' < hex_n[i] && hex_n[i] < 'f'){
			n = hex_n[i] - 87;
		}
		if('A' < hex_n[i] && hex_n[i] < 'F'){
			n = hex_n[i] - 55;
		}
		result +=n* pow(16, hex_c_n -i-1);
	}
	printf("The number in decimal is %d\n", result);
}

int main (int argc, char** argv) {
	char c;
	char hex_num[16];
	int character_num = 0;
	do {
		c = getChar();
		if (c==' '){
			convertIntFromHex(hex_num, character_num);
			character_num=0;
		}
		else {
			hex_num[character_num++] = c;
		}
	} while (c != EOF);
	
	return 0;
}