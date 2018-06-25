#include <iostream>
#include <string>

using namespace std;

int print_each_char_in_string()
{
    string str;
    cout << "Enter string:" ;
    cin >> str;
    
    for (auto c : str)
        cout << c << " ";
    return 0;
}