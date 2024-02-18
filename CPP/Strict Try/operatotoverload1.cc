#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;



class Complex{
	public :
		int re,im;	
		Complex(int r=0,int i=0)
		{
			re = r;
			im = i;
		}
	/*	Complex& operator+(Complex& c)
		{
			re += c.re;
			im += c.im;
			return *this;
		}	*/
		
};
void operator+(Complex& c, Complex& c2)
{
	c.re += c2.re;
	c.im += c2.im;
}	


int main()
{
	Complex a(1,2),b(3,4);
	a+b;
	//a.re = 19;
	cout<<a.re<<endl;
	//cout<<c.re<<endl;
	
}
