#include <stdio.h>
int main(){
	int array[10];
	int T[]= {1, 2, 3, 4, 5};
	
	printf("%d\n", sizeof(array));
	
	int sum = 0;
	
	for (int i=0; i<(sizeof(T)/sizeof(T[0])); i++){
		sum += T[i];
	}
	printf("%d\n", sum);
	
	int maxt = 0;
	for (int i=0; i<(sizeof(T)/sizeof(T[0])); i++) {
		if (T[i] > maxt) {maxt = T[i];}
	}
	printf("%d\n", maxt);
	
	int mini, mini2;
	if (T[0] > T[1]) {
		mini = T[1];
		mini2= T[0];
	}
	else {
		mini = T[0];
		mini2 = T[1];
	}
	for (int i=2; i<(sizeof(T)/sizeof(T[0])); i++) {
		if (T[i] < mini) 
		{mini2 = mini;
		 mini = T[i];}
		else if(mini2 > T[i])
		{mini2 = T[i];}
	}
	printf("%d\n", mini2);
	
	
	int T1[] = {1,2,3,4,5};
	int T2[] = {1,2,3,4,5};
	int sumi = 0;
	for (int i=0; i<sizeof(T1)/sizeof(T1[0]); i++)
	{sumi += (T1[i]*T2[i]);
	}
	printf("%d\n", sumi);
	
	
	char str[128];
	printf("Give me a word");
	scanf("%s", str);
	int str_length = 0;
	while (str[str_length] != '\0'){
		++str_length;
	}
	printf("%d\n", str_length);
	
	
	
	int g[] = {1,2,3,4,5};
	int minis = g[0];
	int maxis = g[0];
	
	for (int i=1; i<sizeof(g)/sizeof(g[0]); ++i){
		if (minis>g[i]){ 
			minis = g[i];}
		if (maxis<g[i]){
			maxis = g[i];}
	}
	printf("%d %d\n", minis, maxis);
	minis = minis + maxis;
	maxis = minis - maxis;
	minis = minis - maxis;
	g[0] = minis;
	g[(sizeof(g)/sizeof(g[0])-1)] = maxis;
	printf("%d %d\n", g[0], g[-1]);
	return 0;
}