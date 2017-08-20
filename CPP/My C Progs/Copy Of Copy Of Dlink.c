#include<stdio.h>
struct dlink{struct dlink *l,*r;int d;};
 typedef struct dlink dl;
 dl*p=NULL,*q=NULL,*root=NULL;
void insert(int x)
{ p=(dl*)malloc(sizeof(dl));
 if(root==NULL)root=p;
 p->d=x;
 p->r=NULL;
 if(q!=NULL){p->l=q;q->r=p;}
 else p->l=NULL;
 q=p;
}
void delete(int x)
{q=root;
 while(q->d!=x)
   q=q->r ;
if(q->l!=NULL&&q->r!=NULL){(q->l)->r=q->r;(q->r)->l=q->l;printf("\nFreed element is %d ",q->d);free(q);}
 /*else printf("\nElement not found!");*/
 q=p;
}
void display()
{q=root;
 while(q!=NULL) {printf("%d ",q->d);q=q->r;}
 q=p;
}
main()
{int el,ch;
 while(1)
{printf("\n1.Insertion\n2.Deletion\n3.Display\n4.exit\nEnter your choice:");
 scanf("%d",&ch);
  switch(ch)
{case 1:printf("\nEnter the element:");
        scanf("%d",&el);
 	insert(el);
        break;
 case 2:printf("\nEnter the element to deleted:");
        scanf("%d",&el);
        delete(el);
        break;
 case 3:display();
	break;
 case 4:return 0;
 default:printf("****IMPROPER CHOICE****");   
}
}
}
