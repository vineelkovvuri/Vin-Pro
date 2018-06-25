#include <iostream>
#include <string>
#include <vector>

#include <dirent.h>
using namespace std;

struct result_item
{
    string attrs;
    string size;
    string date;
    string name;
	string print();
};

string result_item::print()
{
	string result;
	result = attrs + " " + size + " " + date + " " + name;
	return result; 
}

enum class date_type
{
    modified,
    created,
    accessed,
};

enum class sort_type
{
    name,
    size,
    date,
};

class command_options
{
public:
    bool recursive;
    date_type datetype;
    sort_type sorttype;
    string root;
};

void usage();
command_options parse_arguments(int argc, char *argv[]);

command_options parse_arguments(int argc, char *argv[])
{
    command_options co;

    if (argc < 2) {
        usage();
        return co;
    }
    
    string cmdline{""};
    for (int i = 0; i < argc; i++)
        cmdline += argv[i] + string(" ");
    
    if (cmdline.find(" -r ") != string::npos)
        co.recursive = true;
    else
        co.recursive = false;

    if (cmdline.find(" -d:c") != string::npos)
        co.datetype = date_type::created;
    else if (cmdline.find(" -d:a") != string::npos)
        co.datetype = date_type::accessed;
    else
        co.datetype = date_type::modified;
    
    if (cmdline.find(" -s:s") != string::npos)
        co.sorttype = sort_type::size;
    else if (cmdline.find(" -s:d") != string::npos)
        co.sorttype = sort_type::date;
    else
        co.sorttype = sort_type::name;

    co.root = argv[argc - 1];
    if (co.root.back() == '/')
        co.root.pop_back();
    
    cout << co.recursive << endl
         << (int)co.datetype << endl
         << (int)co.sorttype << endl
         << co.root << endl
         << cmdline << endl;
         
    return co;
}

void usage()
{
  cout << "ls.exe [-r] [-d:<c|m|a>] [-s:<s|d|n>] <path>" << endl;
  cout << "     -r recursive listing" << endl;
  cout << "     -d:c list created date" << endl;
  cout << "     -d:m list modified date" << endl;
  cout << "     -d:a list last accessed date" << endl;
  cout << "     -s:s sort by file size" << endl;
  cout << "     -s:d sort by file date" << endl;
  cout << "     -s:n sort by file name" << endl;
}

//string get_attributes()

result_item create_long_listing_item(dirent *entry)
{
	result_item item;

#if 0
    item.attrs = GetAttributesString(entry->d_type);
    item.size = GetFileSizeString(fdata);
    item.date = GetDateString(fdata);
#endif
    item.name = entry->d_name;

    return item;
}
vector<result_item> generate_long_listing(string path)
{
	vector<result_item> file_list;
	DIR *dir;
	struct dirent *entry;
	result_item item;

    dir = opendir(path.c_str());
    if (dir) {
		while ((entry = readdir(dir))) {

#if 0
            // Skip . and .. directories
            if (!IsValidDirectoryName(&fdata))
                continue;
#endif
            item = create_long_listing_item(entry);
			file_list.push_back(item);
        }

		closedir(dir);
    }
#if 0
    //sort the list
    SortLongListing(longFileList, i);
#endif
    return file_list;
}

void populate_long_listing(string path)
{
	vector<result_item> file_list;
    file_list = generate_long_listing(path);

    for (auto& item : file_list)
		cout << item.print() << endl;

    return;
}

int main(int argc, char *argv[])
{
    command_options co = parse_arguments(argc, argv);
    if (co.root.empty())
        return 0;
	populate_long_listing(co.root);
}
