#include<iostream>
#include<cstdio>
#include<cstdlib>

using namespace std;

int * get()
{
    int *t = new int; //(char *)malloc(sizeof(int));
    return t;
}

main()
{
    
    int *i= get();
    
    cout<< *i;
    
    *i=20;
       
    cout<< *i;
    
    delete i;
    
    system("pause");
}
