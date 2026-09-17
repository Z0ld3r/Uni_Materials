#include <stdio.h>
#include <math.h>
int main() {
	int a, b;
	/* printf("Első szám:");
	scanf("%d", &a);
	printf("Második szám:");
	scanf("%d", &b);
	printf("%d\n",a+b);
	printf("%d\n",a-b);
	printf("%d\n",a*b);
	printf("%.2f\n", (float)a/b);*/
	
	
	
	
	printf("háromszög egyik oldal:");
	scanf("%d", &a);
	printf("háromszög azonos oldalak:");
	scanf("%d", &b);
	float c = sqrt((b*b)-((a/2.)*(a/2.)));
	printf("Kerulet: %d\n", a+(2*b));
	printf("Terulet: %.2f\n", c*(a/2));
	printf("téglalap oldalak:");
	scanf("%d", &a);
	scanf("%d", &b);
	printf("Kerulet: %d\n", (2*a)+(2*b));
	printf("Terulet: %d\n", a*b);
	return 0;
}