#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Test{
	public:
	int a;
	Test(int aa){
		cout<<"constructor called..." << endl;
		a = aa;
	}
	Test(const Test & t){
		cout<<"copy constructor called..." << endl;
		a = t.a;
	}
	Test& operator=(const Test& t){
		cout<<"operator called..." << endl;
		a = t.a;
		return *this;
	}
		
};			
void mystring(Test t)
{
	
	cout<< t.a<<endl;
}

int main()
{
	Test t(10);		//calls normal construtor
	
	Test t1 = t;	//calls copy construtor becoz t1 is being created from existing object
	
	t1 = t;			//calls operator = because both sides of the assignments are valid to be invoked for operator =
	
	mystring(t);	//calls copy construtor becoz this is same as Test t = t;
	
	Test tt = 1000;	//calls the normal construtor becoz in C++ a construtor with single argument is used to  
					//construtor an object from that parameter type..
}

