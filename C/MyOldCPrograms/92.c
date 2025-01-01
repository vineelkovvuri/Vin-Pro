/*program to introduce structures*/
#include<stdio.h>
main()
{
 struct book{
	    char name[25];
	    int page;
	    float price;
	    };
struct book book1/*={"vineel",256,23.69}*/,book2;/*={"suneeta",326,69.23};*/
printf("\nEnter the details of book1(name,pages,price):");
scanf("%s%d%f",book1.name,&book1.page,&book1.price);
printf("\nEnter the details of book2(name,pages,price):");
scanf("%s%d%f",book2.name,&book2.page,&book2.price);
printf("\nbook1:\n%s\n%d\n%f\nbook2:\n%s\n%d\n%f",book1.name,book1.page,book1.price,book2.name,book2.page,book2.price);
getch();
}
