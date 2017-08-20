#include<iostream>
#include<cstdio>
using namespace std;
int main()
{
  int a = 10;
  int &x = a;
  int y = 20;
  
  x = y;
  
  cout<< x<<y<<a;
  return 0;
}