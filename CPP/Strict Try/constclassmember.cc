#include<iostream>
#include<cstdlib>
#include<cstring>
#include<cstdio>
using namespace std;

class Employee{
		mutable int salary;
	public:
		Employee(int sal)
		{
			salary = sal;
		}	
		Employee(){}
		
		void incSalary(int val)
		{
			salary += val;
		}
		int getSalary() const 
		{
			
			salary += 100;
			return salary;
		}
};

int main()
{
	Employee b1(1000);
	const Employee b2 = b1;
	
	//b1.incSalary(100);
	cout<<b1.getSalary();
	
	//b2.incSalary(100);
	//cout<<b2.getSalary();
}
