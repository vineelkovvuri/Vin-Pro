#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    vector<int> ages{1,2,3,4,5,6,7,8,9,10};

    auto e = remove_if(ages.begin(), ages.end(), [](int x){
        return x % 2 != 0;
    });
    ages.erase(e, ages.end());

    for (auto &age : ages)
        cout <<  age << "\n";
    return 0;
}

