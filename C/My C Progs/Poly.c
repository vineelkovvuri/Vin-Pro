#include<stdio.h>
#include<conio.h>
struct poly {int exp,co;struct poly *n;};
typedef struct poly pl;
pl *p,*q=NULL,*root=NULL,*root1=NULL,*root2=NULL;
void create();
int add(pl*,pl*);
main()
{   printf("\nFirst polynomial");
    printf("\n----------------");
    create();
    root1=root;root=NULL; q=NULL;p=NULL;
    printf("\nSecond polynomial");
    printf("\n-----------------");
    create();
    root2=root;  
    add(root1,root2);
getch();
}
void create()
{int x;
 do
 { printf("\nEnter the coefficient:");
   scanf("%d",&x);
   p=(pl*)malloc(sizeof(pl));
   if(q!=NULL)q->n=p;
   p->co=x;
   printf("\nEnter the exponent:");
   scanf("%d",&x);
   p->exp=x;
   if(root==NULL)root=p;
   p->n=NULL;
   q=p;
//   if(p->exp==0)break;
 }while(p->exp!=0);
} 
add(pl*p,pl*q)
{ if(p!=NULL&&q!=NULL){
   if(p->exp>q->exp){printf("%dX%d ",p->co,p->exp);add(p->n,q);}
   else if(p->exp<q->exp){printf("%dX%d ",q->co,q->exp);add(p,q->n);}  
   else if(p->exp==q->exp){printf("%dX%d ",q->co+p->co,p->exp);add(p->n,q->n);}
                            }
  else return;
}           
                          		 
