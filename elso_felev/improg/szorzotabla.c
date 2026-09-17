#include <stdio.h>
int main() {
	int i, o;
	for(i=1; i<=10; i++){
		for (o=1; o<=10; o++){
			printf("%d	",i*o);
		}
		printf("\n");
	}
}