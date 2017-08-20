#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int main()
{
	int t, i, j;
	int gMax = 0, mMax = 0, ng, nm;
	scanf("%d", &t);
	while (t--) {
		scanf("%d%d", &ng, &nm);
		gMax = -1;
		mMax = -1;
		for (i = 0; i < ng; i++) {
			scanf("%d", &j);
			if (j > gMax) gMax = j;
		}
		for (i = 0; i < nm; i++){
			scanf("%d", &j);
			if (j > mMax) mMax = j;
		}
		if (gMax >= mMax)
			printf("Godzilla\n");
		else
			printf("MechaGodzilla\n");
	}
	return 0;
}

