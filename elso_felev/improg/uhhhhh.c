#include <stdio.h>
int main(){
	int g[] = {1,2,3,4,5};
		int minis = g[0];
		int maxis = g[0];
		
		for (unsigned i=1; i<(sizeof(g)/sizeof(g[0])); ++i){
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
		printf("%d %d\n", g[0], g[(sizeof(g)/sizeof(g[0])-1)]);
		return 0;
}