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
  printf("\nEnter n:");
  scanf("%d",&n);

  perm(a,0,n);
printf("\n%d",c);
  getch();
}
int perm(int a[],int k,int n)
{
   int t=0,i=0;
   c++;
  if(k==n){display(a);return 0;}
  else
  {
	for(i=k;i<n;i++)
    {t=a[k];a[k]=a[i];a[i]=t;
      display(a);
      printf("<--");
      perm(a,k+1,n);
      display(a);
      printf("<--");
    t=a[k];a[k]=a[i];a[i]=t;
    }
 }
 }
