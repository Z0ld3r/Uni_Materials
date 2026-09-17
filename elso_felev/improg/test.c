#include <stdio.h>

int main(){
	int num;
	char term;
	if(scanf("%d%c", &num, &term) !=2 || term !='\n') {
		printf("invalid");
	}
	else {
		printf("%d", num);
	}
	
	
	
	return 0;
}