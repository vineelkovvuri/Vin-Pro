#include <algorithm>
#include <cctype>
#include <fstream>
#include <iostream>
#include <memory>
#include <string>
#include <utility>
#include <vector>
using namespace std;

template <class T1, class T2> void add(T1 &&x, T2 &&y) {
    cout << "add(string &&x int &&y)\n";
}
// template< class T1, class T2 >
// void add(T1 x, T2 y) { cout << "add(string x int y)\n"; }

struct number {
    int i;
    number(int i) : i{i} {}
    int operator*(number &num) { return this->i + num.i; }
    int operator*() { return this->i; }
};

int main() {


    // ifstream in(R"(C:\vin-pro\a.cpp)");
    // string line;
    // string from = "cout";
    // string to = "cin";
    // auto lowercase = [](string& line) -> string & {
    //     for (auto &c : line)
    //         c = tolower(c);
    //     return line;
    // };
    // auto replace = [&](string &line, string &from, string &to) -> string & {
    //     string line_lower(line);
    //     string from_lower(from);
    //     line_lower = lowercase(line_lower);
    //     from_lower = lowercase(from_lower);
    //     for (int pos = 0;
    //          (pos = line_lower.find(from_lower, pos)) && pos != string::npos;
    //          pos += from.length())
    //         line.replace(pos, from.length(), to);
    //     return line;
    // };

    // while (getline(in, line))
    //     cout << replace(line, from, to) << "\n";

    // in.close();

    // ifstream in(R"(C:\vin-pro\a.cpp)");
    // string line;
    // string from = "cout";
    // string to = "cin";
    // auto replace = [](string &line, string &from, string &to) -> string & {
    //     for (int pos = 0; (pos = line.find(from, pos)) && pos !=
    //     string::npos;pos += from.length())
    //         line.replace(pos, from.length(), to);
    //     return line;
    // };

    // while (getline(in, line))
    //     cout << replace(line, from, to) << "\n";

    // in.close();


    // []{
    //     string sentense{"Able was I, ere I saw Elba"};
    //     bool is_palandrome = true;
    //     for (auto i = sentense.begin(), j = sentense.end() - 1;
    //         i < j;) {
    //         if (isalpha(*i) && isalpha(*j)) {
    //             if (tolower(*i) != tolower(*j)) {
    //                 is_palandrome = false;
    //                 break;
    //             }
    //             i++;
    //             j--;
    //         }
    //         else if (!isalpha(*i)) i++;
    //         else if (!isalpha(*j)) j--;
    //     }
    //     if (is_palandrome)
    //         cout << "String is a palendrome\n";
    //     else
    //         cout << "String is not a palendrome\n";
    // }();

    // string name{"Vineel"};
    // // 1
    // string reverse_name(name.rbegin(), name.rend());
    // cout << reverse_name << "\n";
    // // 2
    // for (int i = 0, j = name.length() - 1; i < j; i++, j--)
    //     swap(name[i], name[j]);
    // cout << name << "\n";
    // // 3
    // for (string::iterator i = name.begin(), j = name.end() - 1; i < j; i++,
    // j--)
    //     swap(*i, *j);
    // cout << name << "\n";

    // string name {"Vineel "};
    // name.erase(3);
    // cout << name <<"|\n";

    // string name{"Vineel Kumar Reddy Kovvuri"};
    // cout << name.find_first_not_of("Var") << endl;

    // number n1{10}, n2{20};
    // int total = n1 * n2;
    // total = n1.operator*(n2);
    // cout << total << "\n";
    // cout << *n1 << "\n";

    // struct book {
    //     string name;
    //     book(): name{""} {
    //         cout << "Default\n";
    //     }
    //     book(const book& name) {
    //         cout << "Const\n";
    //     }
    // };
    // book b1;
    // book b2 = b1;
    // book b3(b1);

    // struct Date {
    //     Date(const Date& date) {
    //         day   = date.day;
    //         month = date.month;
    //         year  = date.year;
    //     }
    //     void read_date(){
    //         cout << "enter day month year";
    //         cin >> day >> month >> year;
    //     }
    //     void write_date() {
    //         cout << day << month << year;
    //     }
    // private:
    //     int day, month, year;
    // };

    // struct types {
    //     bool b;         //1  bytes
    //     char c;         //1  bytes
    //     double d;       //8  bytes
    //     float f;        //4  bytes
    //     int a;          //4  bytes
    //     long double ld; //16 bytes
    //     long l;         //4  bytes
    // };

    // cout << sizeof(types) << "\n"; //64 bytes

    // string match = "ab";
    // string text = "xabaacbaxabb";
    // int count = 0, pos = 0;
    // while ((pos = text.find(match, pos + 1)) != string::npos)
    //     count++;
    // cout << match << " occurred " << count << " times\n";

    // using UC = unsigned char;
    // UC alpha = 'a';

    // int alphabet = 65;
    // cout << static_cast<char>(alphabet) << " " << alphabet << "  " << hex <<
    // alphabet << "\n";

    // vector <int> numbers;
    // string delim;
    // int number;
    // ifstream in(R"(C:\vin-pro\test.cpp)");
    // while (in >> number >> delim)
    //     numbers.push_back(number);

    // for (int& number: numbers)
    //     cout << number << "\n";

    // ofstream out(R"(C:\vin-pro\test.cpp)");
    // if (out.fail())
    //     return -1;
    // for (int i = 0; i < 100; i++)
    //     out << i << "|\n";
    // out.close();

    // vector<string> names {"Vineel", "Nischala", "Riya"};
    // sort(names.begin(), names.end());
    // for (auto &name : names)
    //     cout << name << "\n";

    // vector<pair<string, int>> names_ages{};
    // string name;
    // int age;
    // while (cin >> name >> age) {
    //     names_ages.emplace_back(make_pair(std::move(name), age));
    // }

    // for (pair<string, int> &p : names_ages) {
    //     cout << p.first << "  " << p.second << "\n";
    // }

    // string name = "Vineel";
    // int age = 10;
    // add(name, age);
    // cout << name << endl;

    // string s1{"Vineel"};
    // string s2 = std::move(s1);
    // cout << s1 << endl;
    // cout << s2 << endl;
    return 0;
}
