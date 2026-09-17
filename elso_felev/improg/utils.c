#include "utils.h"
#include <stdio.h>

void f() {}
void static_test() {
	static int var = 0;
	var += 1;
	printf("var: %d\n",var);

}