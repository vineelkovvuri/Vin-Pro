#include <Windows.h>
#include <string>

using namespace std;
class FindFile {
public:
    class FindFileIterator;
    FindFile(const wstring& directory);
private:
    wstring directory;
};

FindFile::FindFile(const wstring& directory) :directory{ directory }
{

}

class FindFile::FindFileIterator {
public:
    FindFileIterator();
private:
    HANDLE handle;
};

FindFileIterator::FindFileIterator()
{
    handle = FindFirstFile(dir_pathc_str(), ffd.get());
    if (handle == INVALID_HANDLE_VALUE) {
        wcerr << L"Error opening FindFirstFile for " << dir_path << L"\n";
        return flist;
    }
}
