#include<iostream>

using namespace std;

namespace Sample{
	int add(int a,int b);
}

namespace Sample2{
	using namespace Sample;
	int sub(int a,int b);
}

int Sample::add(int a,int b)
{
	return a+b;
}

int Sample2::sub(int a,int b)
{
	return add(a-b,a+b);
}


int main()
{
	using Sample::add;
	cout<< add(10,2);	
	
}
