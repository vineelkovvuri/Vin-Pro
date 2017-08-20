#include<iostream>
#include<string>
#include<cstring>
using namespace std;

class Test
{
	string r;
	public :
	//		Test():r(ref){};
	void operator=(string ref);
	void print(){cout<<r;}
};

void Test::operator=(string ref)
{
	r=ref;
}

int main()
{
	int *p = new int(10);
	int *q = p;

	delete p;

	cout<<*q;
}
