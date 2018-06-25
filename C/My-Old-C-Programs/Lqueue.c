#include<stdio.h>
#define m 5
struct lqueue
{
	int d; 
	struct lqueue *n;
};
typedef struct lqueue lq;

lq *f=NULL,*r=NULL;

void display()
{ 
	lq *p=f;
  	while(p!=NULL)
	{
		printf("%d\n",p->d);
		p=p->n;
	}
}

void insert(int x)
{ 
	lq *p=(lq*)malloc(sizeof(lq));
	if(p==NULL)
	{
		printf("\nNO MEMORY");
		exit(0);
	}
	p->d=x;
	p->n=NULL;//r->n=p;
  	if(f==NULL)f=p;
        else r->n=p;
        r=p; 
}

void delete()
{
	lq *p=f->n;
	printf("\nDelete =%d",f->d); 
	free(f);f=p;
        if(f==NULL) r=NULL;
}
/*void make_empty()
{ lq *p;
 while(f!=NULL)
 {p=f;
  f=f->n;
  free(p);
 }
} */
main()
{ 	
	int el,ch;
	while(1)
	{
		printf("\n1.insert\n2.delete\n3.display\n4.exit\nEnter your choice");
		scanf("%d",&ch);
		if(ch==4)break;
		switch(ch)
		{
			case 1:	printf("\nEnter el");
				scanf("%d",&el);
        			insert(el);
				break;
 			case 2:	if(f==NULL)
				printf("\nQueue empty");  
        			else 
				{
					delete(); 
					if(f==NULL)
					r=NULL;
				}
        			break;
 			case 3:	if(f==NULL)	
				printf("\nQueue is empty");
        			else display(); 
				break;
 			default:printf("\nImproper choice");
          			break;
		}
	}
}
