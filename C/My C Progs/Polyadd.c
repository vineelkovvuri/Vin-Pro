 #include<stdio.h>
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
 }
 void create()
 {int x,y;char c='y';
  do
  { printf("\nEnter the coefficient,exponent:");
     scanf("%d%d",&x,&y);
    p=(pl*)malloc(sizeof(pl));
    if(q!=NULL)q->n=p;
    p->co=x;
    p->exp=y;
    if(root==NULL)root=p;
    p->n=NULL;
     q=p;
    if(p->exp!=0){printf("\nIs the entering of the polynomial ended....!(y/n)");
                  scanf(" %c",&c);}
   }while(p->exp!=0&&c!='y');
  }  
  add(pl*p,pl*q)
  { if(p!=NULL&&q!=NULL){
   if(p->exp>q->exp){printf("%dX%d ",p->co,p->exp);add(p->n,q);}
   else if(p->exp<q->exp){printf("%dX%d ",q->co,q->exp);add(p,q->n);}  
   else if(p->exp==q->exp){printf("%dX%d ",q->co+p->co,p->exp);add(p->n,q->n);}
                            }
   else return;
  }           
  INPUT:   		 
  First polynomial
  ----------------
 Enter the coefficient,exponent:5 3 
 Is the entering of the polynomial ended....!(y/n) n
 Enter the coefficient,exponent:2 2
 Is the entering of the polynomial ended....!(y/n) n
 Enter the coefficient,exponent:4 1
 Is the entering of the polynomial ended....!(y/n) n
 Enter the coefficient,exponent:5 0
 Second polynomial
 -----------------
 Enter the coefficient,exponent:5 2
 Is the entering of the polynomial ended....!(y/n) n
 Enter the coefficient,exponent:2 3
 Is the entering of the polynomial ended....!(y/n) n
 Enter the coefficient,exponent:3 1
 Is the entering of the polynomial ended....!(y/n) n
 Enter the coefficient,exponent:1 0
 OUTPUT:
 5X3 7X2 2X3 7X1 6X0 
