#include<stdio.h>
#include<conio.h>
#define M 30
struct stack{char a[M];int top;};
typedef struct stack st;
void push(st *p,char x)
{ p->a[++p->top]=x;
}
char pop(st *p)
{ return p->a[p->top--];
}
int isempty(st *p)
{ return(p->top==-1);
}
int isalnum(char x)
{ return ((x>='0'&&x<='9')||(x>='a'&&x<='z')||(x>='A'&&x<='Z'));
}
int pri(char x) 
{ switch(x)
  { case ')': return 0;
    case '+': case '-': return 1;
    case '*': case '/': return 2;
    case '$': return 3;
    case '(': return 4;
    default: printf("\nIMPROPER CHOICE!");exit(1);
  }
}

void intopost(char in[],char post[])
{ int i,j=0;
  char c,cp;
  st s;
  s.top=-1;
  for(i=0;(c=in[i])!='\0';i++)
  if(isalnum(c)) post[j++]=c;
  else
  { while(!isempty(&s)&&(pri(s.a[s.top])>=pri(c)))
    { cp=pop(&s);
      if(cp!='(') post[j++]=cp;
      else break;
    }
    if(c!=')') push(&s,c);
  }
  while(!isempty(&s)) post[j++]=pop(&s);
  post[j]='\0';
}

main()
{ char in[M],post[M];
  printf("\nEnter infix expression: ");
  scanf("%s",in);
  intopost(in,post);
  printf("\nPOSTFIX EXPRESSION IS %s\n",post);
getch();
}
