#include<iostream>

using namespace std;

namespace Sample{
	int add(int a,int b);
}

namespace Sample2{
	int add(int a,int b);
}

int Sample::add(int a,int b)
{
	return a+b;
}

int Sample2::add(int a,int b)
{
	return a-b;
}

using namespace Sample;
using namespace Sample2;

int main()
{
	using Sample2::add;
	cout<< add(10,2);	
	
}
