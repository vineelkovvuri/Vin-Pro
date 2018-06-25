#include <algorithm>
#include <cctype>
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
    auto lowercase = [](string &line) -> string & {
        for (auto &c : line)
            c = tolower(c);
        return line;
    };

    int count = 0;
    for (string word; in >> word;) {
        lowercase(word);
        for (int pos = 0; (pos = word.find(from, pos)) && pos != string::npos;
             pos += from.length()) {
            count++;
        }
    }
    cout << count << "\n";
    in.close();

    return 0;
}
