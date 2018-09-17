#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Test{
	
	public:
	int a;
	Test(int aa){
			a = aa;
		}
};			

void mystring(Test t)
{
	cout<< t.a<<endl;
}

int main()
{
	Test t(10);
	mystring(t);
	Test tt = 1000;
}
