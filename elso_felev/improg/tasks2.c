#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void fillMatrix(int row, int column, int T[row][column])
{
	for (int i=0; i<row;++i){
		for (int j=0; j<column; ++j){
			T[i][j]=i*j;
		}
	}
}



int main(int argc, char** argv){
	/*if (argc !=3)
	{
		printf("Error, 2 numbers are required.")
	}
	char* c_end;
	int base = strtol(argv[1], &c_end,10);
	int n =s strtol(argv[2], &c_end, 10);
	for(int i=0; i<n ; ++i){
		printf("%d^%d = %d\n",base,i,(int)pow(base,i));
	}
	*/
	int T[10][10];
	fillMatrix(10,10,T);
	for (int i=0; i<10;++i){
		for (int j=0; j<10; ++j){
			printf("%d, ", T[i][j]);
		}
		printf("\n");
	}
	
	
	
	return 0;
}