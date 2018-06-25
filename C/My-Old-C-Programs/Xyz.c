 #include<stdio.h>
 struct poly {int xexp,yexp,zexp,co;struct poly *n;};
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
 {int a,x,y,z;char c='y';
  do
  { printf("\nEnter the coefficient,exponent:");
     scanf("%d%d%d%d",&a,&x,&y,&z);
    p=(pl*)malloc(sizeof(pl));
    if(q!=NULL)q->n=p;
    p->co=a;
    p->xexp=x;p->yexp=y;p->zexp=z;
    if(root==NULL)root=p;
    p->n=NULL;
     q=p;
 if((p->xexp+p->yexp+p->zexp)!=0){printf("\nIs the entering of the polynomial ended....!(y/n)");
                                  scanf(" %c",&c);}
   }while((p->xexp+p->yexp+p->zexp)!=0&&c!='y');
  }  
  add(pl*p,pl*q)
  { if(p!=NULL&&q!=NULL){
   if((p->xexp+p->yexp+p->zexp)>(q->xexp+q->yexp+q->zexp)){printf("%d,%d %d %d\n ",p->co,p->xexp,p->yexp,p->zexp);add(p->n,q);}
   else if((p->xexp+p->yexp+p->zexp)<(q->xexp+q->yexp+q->zexp)){printf("%d,%d %d %d\n",q->co,q->xexp,q->yexp,q->zexp);add(p,q->n);}  
   else if((p->xexp+p->yexp+p->zexp)==(q->xexp+q->yexp+q->zexp)){printf("%d,%d %d %d\n ",q->co+p->co,p->xexp,p->yexp,p->zexp);add(p->n,q->n);}
                            }
   else return;
}
