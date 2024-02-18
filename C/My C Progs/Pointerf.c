#include<stdio.h>
struct book{char title[30];char author[30];int price;};
main()
{
struct book b={"vineel","text",3545},*p=&b;
printf("%s,%s,%d\n",b.title,b.author,b.price);
printf("pointer %s,%s,%d",(*p).title,(*p).author,(*p).price);
getch();
return(0);
}
