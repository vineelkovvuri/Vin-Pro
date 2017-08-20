#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Test{
	public:
	int a;
	Test(int aa){
		cout<<"constructor called..." << endl;
		a = aa;
	}
	bool operator!=(bool hj){
		return a;
	}
	operator void* () const{
		return 0;
	}	
};			

int main()
{
	Test t(10);		//calls normal construtor
	
	if(t)
	cout<<"true"<<endl;
	else 
	cout<<"false"<<endl;
}

