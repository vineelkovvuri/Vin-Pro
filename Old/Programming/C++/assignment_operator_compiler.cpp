#include <iostream>

using namespace std;

struct sample
{
    const int x;
    sample (int y): x{y} {};
};

int main()
{
    int k = 10;
    int k1 = 10;
    sample s1(k);
    sample s2(k1);

    //s1 = s2;

    return 0;
}

