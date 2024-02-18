#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Book{
	public:
		int a;
		int arr[10];
		Book(int aa,int * arr1, int n)
		{
			a = aa;
			for(int i=0;i<n;i++)
			 arr[i] = arr1[i];
		}	
		Book(){}
		
};
int main()
{
	int a[] = {1,2,3,4};
	Book b1(10,a,4);
	Book b2 = b1;
	b1.arr[2] = 22;
	cout<< b2.a <<endl;
	for(int i=0;i<4;i++)
		cout<< b2.arr[i]<<endl;
}
