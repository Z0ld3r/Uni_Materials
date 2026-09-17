#include <stdio.h>
#include <time.h>
#include <stdlib.h>
int menu(){
	int op;
	printf("1. Könnyű\n2. Közepes\n3. Nehéz\n	4. Kilépés\n");
	scanf("%d", &op);
	return op;
}

int main(){
	int t, c, r, op;
	op = menu();
	c = 0;
	do {
		srand(time(NULL));
		if (op == 1){
			r = rand() % 10 + 1;
		}
		else if(op == 2){
			r = rand() % 100+1;
		}
		else if(op ==3){
			r = rand() % 1000+1;
		}
		else{break;}
		do {
			printf("Tipp: ");
			scanf("%d", &t);
			if (t > r) {
				printf("A szám kisebb\n");
			}
			else if (t<r){
				printf("A szám nagyobb\n");
			}
			c+=1;
		}
		while (t != r);
		printf("%d\n", c);
		op = menu();
	}
	while(op != 4);
	return 0;
}

// utf8? while? c?