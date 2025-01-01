#include <iostream>
#include <string>

using namespace std;

int print_each_char_in_string_using_subscript()
{
    string str;
    cout << "Enter string:" ;
    cin >> str;
    
    for (int i = 0; i < (int)str.size(); i++)
        cout << str[i] << " ";

    cout << endl;
    // str.size() return different type of size variables
    // so assuming i as int is not appropriate.
    // Here we can use decltype to correctly declare the type of i
    for (decltype(str.size()) i = 0; i < str.size(); i++)
        cout << str[i] << " ";
    
    // auto cannot be used here because auto deduces the type of i
    // from the initializer which here happens to be 0 so it 
    // results in int!
    return 0;
}