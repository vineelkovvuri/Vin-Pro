#include<stdio.h>
struct book{char title[30];char author[30];int price;};
main()
{
struct book b={"vineel","text",3545},*p=&b;
printf("\n%s,%s,%d\n",b.title,b.author,b.price);
printf("using pointer %s,%s,%d\n",(*p).title,(*p).author,(*p).price);
printf("pointer %s,%s,%d",p->title,p->author,p->price);
/*last two printf statements are correct and they are one and the same*/
getch();
return(0);
}
