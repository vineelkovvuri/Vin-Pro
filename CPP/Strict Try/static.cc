#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Employee{
	int sal;	
	public :
		 static int minSalary = 10000;	
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
		virtual int getSalary()
		{
//			cout<< "Salary is: "<< sal;
			return sal;
		}
};

int main()
{
	
	cout<<Employee::minSalary<<endl;
	
	
	//Manager aa(10);
	
	//aa = 10;
	
	
	//Employee b;
	//b = a;
	//cout<<aa.getSalary()<<endl;
	//cout<<c.re<<endl;
	
}
