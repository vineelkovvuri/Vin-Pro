#include <iostream>
#include <cstdio>

using namespace std;

class a{}; 
int main()
{
   int test = 0;
   float fvalue = 3.111f;
   cout << (test ? fvalue : 0) << endl;
   
   cout<< sizeof(a);	
   return 0;
}


