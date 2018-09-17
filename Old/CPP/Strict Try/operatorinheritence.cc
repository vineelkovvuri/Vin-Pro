#include<iostream>
 
using namespace std;
 
class A {
 public:
   A & operator= (A &a) {
    cout<<" base class assignment operator called ";
    return *this;
   }
};
 
class B: public A { 

public:
	 B & operator= (B &b) {
    cout<<" derived class assignment operator called ";
    return *this;
   }

};
 
int main()
{
  B b1,b2;
  //a.A::operator=(b); //calling base class assignment operator function
                    // using derived class
  
  b1 = b2;  
  return 0;
}