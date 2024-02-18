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
template <typename T> struct Stack {
    T element;
    Stack();
};

template <typename T> Stack<T>::Stack() {
    typedef typename T tt;
    srand(time(nullptr));
}

int main() { return 0; }
