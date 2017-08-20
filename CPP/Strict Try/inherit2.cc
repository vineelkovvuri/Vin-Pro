#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class A{
	public:
	A(){
		cout<<"A's constructor called..." << endl;
	}
	A(int a){
		cout<<"A's one parameter constructor called..." << endl;
	}
};	


class B: public A{
	public:
	int a;
	B(){
		a = 10;
		cout<<"B's constructor called..." << endl;
	}
	B(int b){
		cout<<"B's one parameter constructor called..." << endl;
	}	
};			

int main()
{
	B t(10);
}

