#include<stdio.h>
struct dlist{struct dlist *l;
             int d;
             struct dlist *r;};       
 typedef struct dlist dl;
 dl * head=NULL,* p=NULL,* tail=NULL;
 
 void insert(int x)
 {tail=p;
 dl *p=(dl*)malloc(sizeof(dl));
  if(head==NULL)head=p;
  p->d=x;
  p->r=NULL; 
  p->l=tail;
  if(tail!=NULL)tail->r=p;
 }
 void delete_()
 { tail=tail->l;
   p=p->l;
   printf("Freed Element is:%d\n",(p->r)->d);
   free (p->r);
 }
 void display()
 {p=head;
  while(p!=NULL)
      {printf("%d\n",p->d);
       p=p->r;
       }
   p=tail->r; 
 }  int el;     
  main()
 { int ch;
   while(1)
   {printf("\n1.Insert\n2.Delete\n3.Display\n4.exit\nEnter your choice:");
    scanf("%d",&ch);
    switch(ch)
    {case 1:printf("\nEnter the Element:");
               scanf("%d",&el);
               insert(el);
               break;
     case 2:delete_();
     case 3:display();
     case 4:return 0;
     default:printf("\nImproper choice:");
    } 
   }
 }
                      
