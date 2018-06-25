#include <algorithm>
#include <cctype>
#include <cstdlib>
#include <ctime>
#include <fstream>
#include <iostream>
#include <memory>
#include <set>
#include <string>
#include <utility>
#include <vector>

using namespace std;
template <int MaxNum>
struct Random
{
    int maxNum;
    Random() ;
    int GetRandom();
};

template <int MaxNum>
Random<MaxNum>::Random(): maxNum(MaxNum)
{
    srand(time(nullptr));
}

template <int MaxNum>
int Random<MaxNum>::GetRandom()
{
    int rnd = rand();
    return rnd % maxNum;
}

int main() {
    Random<1> r1;
    for (int i = 0; i < 10; i++)
        cout << r1.GetRandom() << endl;

    cout << "\n=========\n";
    Random<2> r2;
    for (int i = 0; i < 10; i++)
        cout << r2.GetRandom() << endl;

    return 0;
}
