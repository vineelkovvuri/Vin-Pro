 #include<stdio.h>
 struct tree {int d;struct tree *l,*r;};
 typedef struct tree nd;
 nd *p=NULL,*root=NULL,*del=NULL,*q=NULL,*s=NULL;
 insert(nd *p,int y)
 {if(y<p->d&&p->l!=NULL)insert(p->l,y);
  else if(y<p->d&&p->l==NULL)
                        {p->l=(nd*)malloc(sizeof(nd));
                         (p->l)->d=y;
	                 (p->l)->l=(p->l)->r=NULL;
			}
  if(y>p->d&&p->r!=NULL)insert(p->r,y);
  else if(y>p->d&&p->r==NULL)
                        {p->r=(nd*)malloc(sizeof(nd));
			 (p->r)->d=y;
			 (p->r)->l=(p->r)->r=NULL;
			}
 }   	
 deletion(nd *p,int y)
{if(y<p->d){q=p;deletion(p->l,y);}
 if(y>p->d){q=p;deletion(p->r,y);}
 if(y==p->d){ del=p;if(p->l!=NULL){p=p->l;    
                                   while(p->r!=NULL)
                                         {s=p;p=p->r;}
                                       if(p->l==NULL){if(s!=NULL)s->r=NULL;}
                                       else if(p->l!=NULL){if(s!=NULL)s->r=p->l;}               
                                       if(q==NULL)root=p;
                                       else {if(y>q->d)q->r=p;else q->l=p;}
                                             if(del->r!=NULL)p->r=del->r;
                                             else if(del->r==NULL)p->r=NULL; 
                                             if(del->l!=p)p->l=del->l;
                                             free(del);
                                  }             
                   else if(p->r==NULL){if(q!=NULL){if(y>q->d)q->r=NULL;else q->l=NULL;}
                                       else root=NULL;
                                        free(del);}
                   else if(p->r!=NULL){if(q!=NULL){if(y>q->d)q->r=p->r;else q->l=p->r;}
                                       else root=del->r;
                                       free(del);}
                   
            }
}	 
 inorder(nd*p)
 {if(p==NULL)return ;
 else {  inorder(p->l);
         printf("%d ",p->d);
         inorder(p->r);
      }
 }
 preorder(nd*p)
 {if(p==NULL)return;
  else {printf("%d ",p->d);
        preorder(p->l);
        preorder(p->r);
      }
 }
 postorder(nd*p)
 {if(p==NULL)return;
  else {postorder(p->l);
        postorder(p->r);
        printf("%d ",p->d);
       }
 }
  main()
{int dl,ch;
 while(1)
 { printf("\n1.INSERTION\n2.DELETION\n3.IN-ORDER\n4.PRE-ORDER\n5.POST-ORDER\n6.EXIT\nEnter your choice:");
    scanf("%d",&ch);
        s=NULL;del=NULL;q=NULL;p=NULL;
 switch(ch)
 {case 1:if(root==NULL){ root=(nd*)malloc(sizeof(nd));
                         printf("\nEnter the root:");
                         scanf("%d",&dl);
                         root->d=dl;root->l=root->r=NULL;
                       }
         else  { printf("\nEnter the element:");
                 scanf("%d",&dl);insert(root,dl);
               } break;
  case 3:if(root==NULL) printf("\nNO ELEMENTS...!");
         else  inorder(root);break;
  case 4:if(root==NULL) printf("\nNO ELEMENTS...!");
         else preorder(root);break;
  case 5:if(root==NULL) printf("\nNO ELEMENTS...!");
         else postorder(root);break;
  case 2:if(root==NULL) printf("\nTREE IS EMPTY...!");
         else {printf("\nEnter the element to be deleted:");scanf("%d",&dl);
               deletion(root,dl);
              }
        break;
  case 6:return 0;
  default:printf("****IMPROPER CHOICE TRY AGAIN****");
 }
 } 
 }
