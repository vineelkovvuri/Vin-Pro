#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Test{
	public:
	int a;
	Test(int a):a(a){}
	
	operator int()
	{
		return a;
	}
};			

int main()
{
	Test t(11);		
	cout<< t.a<< endl;
	cout<< t << endl; 
	cout<< int()<<endl;
}

