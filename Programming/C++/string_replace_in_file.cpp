#include <algorithm>
#include <cctype>
#include <fstream>
#include <iostream>
#include <memory>
#include <string>
#include <utility>
#include <vector>
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
    auto replace = [&](string &line, string &from, string &to) -> string & {
        string line_lower(line);
        string from_lower(from);
        line_lower = lowercase(line_lower);
        from_lower = lowercase(from_lower);
        for (int pos = 0;
             (pos = line_lower.find(from_lower, pos)) && pos != string::npos;
             pos += from.length())
            line.replace(pos, from.length(), to);
        return line;
    };

    while (getline(in, line))
        cout << replace(line, from, to) << "\n";

    in.close();

    return 0;
}
