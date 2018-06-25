#include <iostream>
#include <string>

using namespace std;

int using_stmt()
{
    std::string name = "Vineel";
    getline(cin, name);
    cout << name;
    return 0;
}