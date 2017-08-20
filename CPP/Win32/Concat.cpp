#include<windows.h>
#include<tchar.h>
	

char * concat (char *,...);
main()
{
	concat("","asdf","asdfas","asdfas");
}
struct test {
	int a,b;
}x;

char * concat(char * fmt,...)
{

	static char x[1024],temp[1024];
	int x;
	double y;
	char z;
	va_list arg;
	va_start (arg,fmt);

while()
	{
		switch(GetToken())
		{
			case 1:	x = va_arg(arg,int);
					break;
			case 2:	y = va_arg(arg,double);
					break;
			case 3:	z = va_arg(arg,char);
					break;
			case 4:	strcpy(temp,va_arg(arg,char *));
					break;
		}

	}

}
