#include<iostream>

using namespace std;


int main()
{
	int x[5] = { 1,2,3,4,5};
	int *p1,*p2,*p3;
	p1 = &x[0];
	p2 = &x[1];
	p3 = p1 + p2;
//	cout<< p3;

}
