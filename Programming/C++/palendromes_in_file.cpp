#include <algorithm>
#include <cctype>
#include <fstream>
#include <iostream>
#include <memory>
#include <string>
#include <utility>
#include <vector>
#include <set>
using namespace std;

int main() {

    ifstream in(R"(C:\vin-pro\a.cpp)");
    string line;
    string from = "cout";
    string to = "cin";
    auto lowercase = [](string &line) -> string & {
        for (auto &c : line)
            c = tolower(c);
        return line;
    };
    auto is_palendrome = [](const string &word) {
        for (string::const_iterator i = word.cbegin(), j = word.cend() - 1;
             i < j; i++, j--)
            if (*i != *j)
                return false;
        return true;
    };

    set<string> palendromes;
    for (string word; in >> word;)
        if (is_palendrome(word)){
            if (palendromes.find(word) == palendromes.end()) {
                palendromes.insert(word);
                cout << word << "\n";
            }
        }

    in.close();

    return 0;
}
