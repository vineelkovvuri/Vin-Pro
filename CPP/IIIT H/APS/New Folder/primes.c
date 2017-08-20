#include<Stdio.h>
#include<math.h>
int main()
{
	int i,n,count=0;
	for(n=3; count <= 500; n++){
		int squrt = sqrt(n);
		for(i = 2;i <= squrt;i++)
			if(n%i == 0) break;
		if(i > squrt) {
			printf("%d\t",n);	
			count++;
		}
	}
}

