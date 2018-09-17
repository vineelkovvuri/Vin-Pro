#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;



class Test{
	int x;	
	public :
		Test()
		{
			x = 0;
		}
		Test(int xx)
		{
			x = xx;
		}
		
};

class Book{
	Test t1,t2;
	
	public:
	int y;
		Book(int yy):t1(yy)
		{
			y = yy;
		}
};	
	
int main()
{
	Book b1(10);
	cout<< b1.y;
}
