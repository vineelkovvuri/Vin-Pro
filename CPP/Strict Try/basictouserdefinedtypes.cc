#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;



class Test{
	public :
		int x;	
		Test()
		{
			x = 0;
			cout<<"constructor with no arguments called"<<endl;
		}
		Test(int xx)
		{
			x = xx;
			cout<<"constructor with single int argument called"<<endl;
		}
		
		
};


int main()
{
	//Test a(10);
	Test aa;
	aa = 10;
	//Test b;
	//b = a;
	cout<<aa.x<<endl;
	//cout<<c.re<<endl;
	
}
