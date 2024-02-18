#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Employee{
	int sal;	
	public :
	
		Employee()
		{
			sal = 0;
			cout<<"constructor with zero argument called"<<endl;
		}
		Employee(int xx)
		{
			sal = xx;
			cout<<"constructor with single int argument called"<<endl;
		}
		int getSalary()
		{
//			cout<< "Salary is: "<< sal;
			return sal;
		}
};

class Manager : public Employee
{
	public:
		Manager(int x)//:Employee(x)
		{
			
		};
};

int main()
{
	//Employee a(10);
	Manager aa(10);
	//aa = 10;
	
	
	//Employee b;
	//b = a;
	cout<<aa.getSalary()<<endl;
	//cout<<c.re<<endl;
	
}
