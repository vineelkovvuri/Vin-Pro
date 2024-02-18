#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Test{
	static int objCount;	
	public:
	int a;
	Test(int aa){
			a = aa;
	}
};			
int Test::objCount = 10;
void mystring(Test t)
{
	cout<< Test::objCount<<endl;
	cout<< t.a<<endl;
}

int main()
{
	Test t(10);
	mystring(t);
	Test tt = 1000;
}

