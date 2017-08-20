#include<stdio.h>
#include<string.h>
void function(char[],int );
void function1(char[],int);
void function2(float);
void function3(int);
main()
{int i,m,c,p;char s1[20],s2[20];float f;
printf("\nPROGRAM TO PRINT THE DETAILS OF BOOKS IN A LIBRARY ON DIFFERENT FACTORS");
printf("\nEnter the total number of books in the library");
scanf("%d",&m);
struct library{char name[20];char author[20];float price;int pages;}b[m];
printf("\nEnter respective book name, author, price, no/..of pages");
for(i=0;i<m;i++)
scanf("%s%s%f%d",b[i].name,b[i].author,&b[i].price,&b[i].pages);
printf("\nON WHAT BASIS YOU WANT TO SEARCH:\n1.books of same name\n2.books on same author\n3.books whose price is greater than requested value \n4.books whose pages are  greater than requested number\nEnter your choice");
scanf("%d",c);
switch(c)
{case 1:printf("\nEnter the name of the book");scanf("%s",s1);function(b[].name,m);break;
case 2:printf("\nEnter the author you want to search for");scanf("%s",s2);function1(b[].author,m);break;
 case 3:printf("\nEnter the price above which you want to search");scanf("%f",f);function2(b[].price,f,m);break;
 case 4:printf("\nEnter the no/.. of pages above which you want to search");scanf("%d",p);function3(b[].pages,p,m);break;
}
{
void function1( b[],int m)
//struct library b;
{int i;for(i=0;i<m;i++)
if(strcmpi(s2,b[i].author))printf("\n%s\n%s\n%f\n%d",b[i].name,b[i].author,b[i].price,b[i].pages);}
void function2(b[],float f,int m)
//struct library b; 
{int i;for(i=0;i<m;i++)
       if(b[i].price>f)printf("\n%s\n%s\n%f\n%d",b[i].name,b[i].author,b[i].price,b[i].pages);   }
void function3(b[],int p,int m)
//struct library b;
{int i;for(i=0;i<m;i++)
       if(b[i].pages>p)printf("\n%s\n%s\n%f\n%d",b[i].name,b[i].author,b[i].price,b[i].pages);
}
void function( b[],int m)
//struct library b;
{int i;for(i=0;i<m;i++)
if(strcmpi(b[i].name,s1))printf("\n%s\n%s\n%f\n%d",b[i].name,b[i].author,b[i].price,b[i].pages);
}
