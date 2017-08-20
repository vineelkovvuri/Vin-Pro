#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;



class Test{
	public:
	int a;
	class A
	{
		public:
			int x;
	};
	Test(int aa){
		cout<<"constructor called..." << endl;
		a = aa;
	}
};			

int main()
{
	Test t(10);		//calls normal construtor
	
	Test::A aa;
	if(t)
		cout<<"true"<<endl;
	else 
		cout<<"false"<<endl;
}

