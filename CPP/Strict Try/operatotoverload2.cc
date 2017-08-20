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

		Complex& operator+(int  x)
		{
			re += x;
			im += x;
			return *this;
		}	
		
};


int main()
{
	Complex a(1,2),b(3,4);
	
	b = 1+a;
	//a.re = 19;
	cout<<a.re<<endl;
	//cout<<c.re<<endl;
	
}
