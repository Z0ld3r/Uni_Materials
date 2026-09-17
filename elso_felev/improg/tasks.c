#include <stdio.h>
int main() {
	int a, b;
	printf("Number #1: ");
	scanf("%d", &a);
	printf("Number #2: ");
	scanf("%d", &b);
	if(a>b) {
		int c = a;
		a = b;
		b = c;
	}
	while(b > 0){
		int c = b;
		b = a%b;
		a = b;
	}
		printf("LNKO: %d\n", a);
	
	
	return 0;
}