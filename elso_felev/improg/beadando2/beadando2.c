#include <stdio.h>
#include <string.h>
#include "beautils.h"


int main(){
	int inp = 0;
	int tomb[128];
	int size = 0;
	do {
		menu();
		scanf("%d",&inp);
		if (inp == 1){
			add(tomb,&size);
		}
		else if (inp == 2) {
			rremove(tomb,&size);
		}
		else if (inp == 3) {
			print(tomb,&size);
		}
		else if (inp == 4) {
			count(tomb,&size);
		}
		else if (inp == 5) {
			clear(tomb,&size);
		}
		else if (inp == 6) {
			exiting();
		}
		else {
			input_error();
		}
	}
	while ((inp != 6) && (inp != EOF));
	return 0;
}