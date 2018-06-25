 #include<stdio.h>
 struct poly{int co,exp;struct poly *n;};
 typedef struct poly pl;
 pl *p=NULL,*q=NULL,*r=NULL,*root=NULL,*root1=NULL,*root2=NULL,*root3=NULL;
 mull(pl *p,pl *q,pl *r)
 {int g=1,x=-1;
   if(p!=NULL) {for(;r!=NULL&&g!=0;)
                {if(r->exp==p->exp+q->exp){x=0;g=0;}
                  else r=r->n;}
                if(x==0)r->co+=p->co*q->co;
                else {r=(pl*)malloc(sizeof(pl));if(root3==NULL)root3=r;
		      if(root!=NULL)root->n=r;
                      r->co=p->co*q->co;
                      r->exp=p->exp+q->exp;
                      r->n=NULL;
                      root=r;
		      }
                if(q->n!=NULL)mull(p,q->n,root3);
                else  mull(p->n,root2,root3);
              }
  else return;
 }
 void create()
 {int x,y;char c='n';
  do
  {
    printf("\nEnter the coefficient,exponent:");
    scanf("%d%d",&x,&y);
    p=(pl*)malloc(sizeof(pl));
    if(q!=NULL)q->n=p;
    p->co=x;
    p->exp=y;
    if(root==NULL) root=p;
    p->n=NULL;
    q=p;
    if(p->exp!=0){printf("\nIs the equation ended...!(y/n)");
                  scanf(" %c",&c);}
   }while(c!='y'&&p->exp!=0);
 }
 main()
 { printf("\nFirst polynomial");
   create();
   root1=root;root=NULL;q=NULL;p=NULL;
   printf("\nSecond polynomial");
   create();
   root2=root;root=NULL;
    mull(root1,root2,root3);
   r=root3;
  for(;r!=NULL;)
   {printf("\nco=%d  exp=%d",r->co,r->exp);r=r->n;}
 }
 INPUT:
 First polynomial
 Enter the coefficient,exponent:5 3
 Is the equation ended...!(y/n) n
 Enter the coefficient,exponent:2 2
 Is the equation ended...!(y/n) n 
 Enter the coefficient,exponent:4 1
 Is the equation ended...!(y/n) n
 Enter the coefficient,exponent:5 0
 Second polynomial
 Enter the coefficient,exponent:3 1
 Is the equation ended...!(y/n) n
 Enter the coefficient,exponent:1 0
 OUTPUT:
 co=15  exp=4
 co=11  exp=3
 co=14  exp=2
 co=19  exp=1
 co=5  exp=0
