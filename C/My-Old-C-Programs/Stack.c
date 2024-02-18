#include<stdio.h>
main()
{
int x[5],c,top=-1,m=0,i;
while(1)
 {
  printf("\n1.push\n2.pop\n3.make empty\n4.display\n5.exit\nEnter your choice");
  scanf("%d",&c);
  switch(c)
   {case 1:if(top==4)printf("\nStack is full");
           else if(top!=5-1){printf("\nEnter the element");
                             scanf("%d",&x[++top]); m=top;}
           else if(top==5-1)printf("\nStack is full"); break;
    case 2:if(top==-1) printf("\nStack is already empty");
           else m=--top;break;
    case 3:if(top!=-1)top=-1;
           else if(top==-1)printf("\nStack is empty");m=top;break;
    case 4:if(top!=-1)for(i=top;i>=0;printf("\nstack no:%d,stack element is %d",i+1,x[i]),i--); 
        else printf("\nStack is already empty");break;
 case 5:return;
}           
}
}                

