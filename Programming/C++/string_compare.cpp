#include <iostream>
#include <string>

using namespace std;

int string_compare()
{
    string str1;
    cout << "Enter first string:" ;
    cin >> str1;
    string str2;
    cout << "Enter second string:" ;
    cin >> str2;
    
    if (str1 < str2)
        cout << "str1 < str2";
    else if (str1 > str2)
        cout << "str1 > str2";
    else
        cout << "str1 == str2";
    return 0;
}