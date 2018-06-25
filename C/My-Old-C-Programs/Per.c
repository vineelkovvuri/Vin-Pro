#include<stdio.h>
#include<conio.h>
int perm(int [],int ,int );
int n;
static int c;
void display(int a[])
{
  int i=0;
  printf("\n\n");
  for( i=0;i<n;i++)
  printf("%d ",a[i]);
}

main()
{
  int a[10]={1,2,3,4,5,6,7,8,9};
  clrscr();
  printf("\nEnter no of digit :"); //if you enter 3 then 3 places will be consideres _ _ _
								   //if you enter 4 then 4 places will be consideres _ _ _ _
  scanf("%d",&n);
  perm(a,0,n);
  printf("\nTotal Permuatations = %d",c);
  getch();
}
int perm(int a[],int k,int n)
{
	int t=0,i=0;

	if(k==n){ c++;display(a);return 0;}
	else
	{
		for(i=k;i<n;i++)
		{
			t=a[k];a[k]=a[i];a[i]=t;
			perm(a,k+1,n);
			t=a[k];a[k]=a[i];a[i]=t;
		}
	}
}
