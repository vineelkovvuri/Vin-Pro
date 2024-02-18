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

int main() {

    ifstream in(R"(C:\vin-pro\a.cpp)");
    string from = "cout";
    auto switch_word = [](string &line, int n) -> string & {
        srand(time(nullptr));
        int len = line.length();
        if (len > 1) {
            for (int i = 0; i < n; i++) {
                int rnd1 = rand() % len, rnd2;
                while ((rnd2 = rand() % len) && rnd2 == rnd1)
                    ;
                swap(line[rnd1], line[rnd2]);
            }
        }
        return line;
    };

    int n = 3;
    for (string word; in >> word;) {
        cout << switch_word(word, n) << " ";
    }

    return 0;
}
