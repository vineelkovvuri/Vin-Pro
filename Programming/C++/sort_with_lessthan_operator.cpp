#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

struct student
{
    int total;
    string name;
    student (string name, int total): name{name},total{total} {};
    bool operator<(const student& rhs)
    {
#if 1
        return total < rhs.total;
#else
        return name < rhs.name;
#endif
    }
};

int main()
{
    vector<student> students;
    students.push_back(student("Nischala", 950));
    students.push_back(student("Vineel", 900));
    students.push_back(student("Riya", 990));

    sort(begin(students), end(students));

    for (auto &student : students)
        cout << student.name << " " << student.total << "\n";
    return 0;
}

