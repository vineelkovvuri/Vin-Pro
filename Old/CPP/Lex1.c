

#include<stdio.h>
#include<string.h>
void print(int,int);
char x[15],keys[]={'(',')','+','/','*','-','\0'};
main(int argc,char **argv){
	int i=0,n,end=0,str=-1,Key=0,j;
    strcpy(x,argv[1]);
	n = strlen(x);
	for(i=0;i<=n;i++){
		if(str==-1)str = i;
		for(j=0;j<7;j++)
			if(x[i]==keys[j]){
				Key = 1;break;
			}
		if(Key){
			print(str,i);
			str=-1;
			printf("\t%c",x[i]);
			Key = 0;
		}
	}
}
void print(int str,int end){
   int i=0;
   printf("\t");
   for(i=str;i<end;i++)
	   printf("%c",x[i]);
}

