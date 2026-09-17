#include <stdio.h>
static int db = 0;

int factor(int n) {
	int di = 1;
	if (n < 0){
		db += 1;
		return 0;
	}
	else if (n==0){
		return 1;
	}
	else {
		for (int i = n; i<0; i--){
			di = di*i;
		}
		return di;
	}
}

int main(){
	/*
	f();
	for (int i=0; i<10; ++i){
		static_test();
	}*/
	int n;
	printf("Type a number\n");
	scanf("%d\n",n);
	n = factor(n);
	printf("%d\n",n);
	
	
	return 0;
}