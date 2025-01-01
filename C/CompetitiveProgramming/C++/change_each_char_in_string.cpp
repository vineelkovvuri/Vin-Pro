#include <iostream>
#include <string>
#include <cctype>

using namespace std;

int change_each_char_in_string()
{
    string str;
    cout << "Enter string:" ;
    cin >> str;
    
    // &c will refer to each char in the string
    for (auto &c : str)
        c = toupper(c);
    
    for (auto c : str)
        cout << c << " ";

    return 0;
}