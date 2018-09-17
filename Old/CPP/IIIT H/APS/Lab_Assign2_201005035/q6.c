#include<stdio.h>
#include<stdlib.h>

int * mul(int *op1,int *op2,int op1Size,int op2Size,int * res,int *resSize) //here a and two poerand and res is result and op1Size,op2Size,resSize is size
{
	int i,j,k,temp,carry;
	for(j=0;j<op2Size;j++){
		*resSize=0;
		carry=0;
		for(i=0;i<op1Size;i++){
			if(*resSize <= i+j)*resSize = i+j;
			temp=op1[i]*op2[j]+carry;
			carry=0;
			carry=(res[i+j]+temp)/10;
			res[i+j]=(res[i+j]+temp)%10;
		}
		while(carry>0){
			if(*resSize <= i+j)*resSize = i+j;
			res[i+j]=carry%10;
			carry=carry/10;
		}
	}
	*resSize=*resSize+1;
	return res;
}
void factorial(int num)
{
	int *op1,op2[500],*res,op1Size,op2Size,resSize,capacity=100;
	int i,j;

	op1=(int *)calloc(capacity,sizeof(int));
	res=(int *)calloc(capacity,sizeof(int));
	op1[0]=2;
	op1Size=1;

	for(i=1;i<num;i++){
		j=i;
		op2Size=resSize=0;
		while(j>0){
			op2[op2Size++]=j%10;
			j=j/10;
		}
		res=mul(op1,op2,op1Size,op2Size,res,&resSize);
		if(resSize > ( capacity - 10 ) ){
			capacity+=50;   
			op1=realloc(op1,capacity *  sizeof(int));
			res=realloc(res,capacity *  sizeof(int));	   
		}
		for(j=0;j<resSize;j++)
			op1[j]=res[j];
		op1Size=resSize;
	}

	for(i=resSize-1;i>=0;i--)
		printf("%d",res[i]);
	//printf("size:%d",resSize);

}

int main()
{

	int op1Size;
	//printf("Enter the Number:");
	scanf("%d",&op1Size);

	factorial(op1Size);


	return 0;
}
