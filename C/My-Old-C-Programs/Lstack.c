#include<stdio.h>
struct lstack {int d;struct lstack *n;};
typedef struct lstack ls;
ls *push(ls *,int);
ls *pop(ls *);
void display(ls *p)
{ ls *t=p;
  if(p==NULL){printf("\nEmpty stack;");return;} 
  while(t!=NULL){printf("\n%d",t->d);t=t->n;}
}
ls * push(ls *q,int x)
 {ls *p=(ls*)malloc(sizeof(ls));
  if(p==NULL){printf("\n NO MEMORY");exit(1);}
  p->d=x;p->n=q;
  return p;
}
ls*pop(ls*q)
 { ls*p=q->n;
   printf("poped element=%d",q->d);
   free(q);
   return p;
 }
main()
{ls s,*top=NULL;int ch,el;
while(1){printf("\n1.push\n2.pop\n3.display\n4.exit\nEnter your choice");
          scanf("%d",&ch);
          if(ch==4)break;
         switch(ch)
          { case 1:printf("Enter elements");
                   scanf("%d",&el);
                   top=push(top,el);break;
            case 2:if(top==NULL)printf("\nStack is empty");
                   else top=pop(top);break;
            case 3:if(top==NULL)printf("\nStack is empty");
                   else display(top);break;
            default:printf("\nIMPROPER CHOICE");
          }
        }
}

      
    
     
