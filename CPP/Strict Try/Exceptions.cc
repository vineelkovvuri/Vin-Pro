#include<iostream>

using namespace std;

struct ZeroError{
	int err;
	ZeroError(int e){err = e;}
};


int div(int a,int b)
{
	if (b == 0)throw int(20);
	return a+b;
}


int main()
{
	try{
		int x = div(10,0);
		cout<< x;
	}
	catch(int z){
		cout<<z;
	}
	
}
