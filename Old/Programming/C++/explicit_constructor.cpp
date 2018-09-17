#include <iostream>

using namespace std;

struct sample
{
    explicit sample(int x);
};

sample::sample(int x)
{
    cout << x << "\n";
}

struct test
{
    test(int x);
};

test::test(int x)
{
    cout << x << "\n";
}

int main()
{
    //sample s = 10;
    sample s(10);
    test t = 10;
    return 0;
}