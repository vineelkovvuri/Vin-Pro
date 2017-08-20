#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;



class Complex{
	public :
		int re;	
		Complex(int r=0)
		{
			re = r;
			cout<<"1st called"<<endl;
		}
		Complex(Complex& c)
		{
			re = c.re;
			cout<<"2nd called"<<endl;
		}
		
};


int main()
{
	Complex a(1);
	cout<<"afasdf"<<endl;
	Complex b(a);
	
	//b = 1+a;
	//a.re = 19;
	cout<<a.re<<endl;
	//cout<<c.re<<endl;
	
}
