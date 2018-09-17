
#include<iostream>

using namespace std;


inline int add(int a)
{
	add(a-1);
}


int main()
{
	add(10);
}