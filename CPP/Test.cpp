#include<cstdio>
#include<iostream>
#include<memory>

using namespace std;



class test{
	public:
		int i;

		test()
		{
			//i = 10;
			cout<< "\ncons";
		}
		test(const test&)
		{
			//i = 10;
			cout<< "\ncopy cons";
		}
		
		/*~test()
		{
			cout<< "\ndes";
		}*/
};

test fun(test &a)
{
	return a;
}

 __declspec(dllexport) int add(int a,int b)
{
	return a+b;
}
 __declspec(dllexport) int add(int a,int b,int c)
{
	return a+b+c;
}

int main()
{
	 test p; //con
	 fun(p);
}