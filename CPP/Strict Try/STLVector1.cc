#include<iostream>
#include<vector>
#include<string>



using namespace std;


int main()
{
	vector<string> names;
	names.push_back("Vineel");
	names.push_back("Nischala");
	names.push_back("Suneeta");
	names.push_back("Satya");
	names.push_back("Mohan");
	
	
	for(vector<string>::const_iterator cii = names.begin(); cii != names.end();cii++){
		cout<< *cii << endl;
	}
	cout<<endl;
	for(vector<string>::reverse_iterator cii = names.rbegin(); cii != names.rend();cii++){
		cout<< *cii << endl;
	}
	
	cout<< "\n" << names.size();
	cout<< "\n" << names[2];
	swap(names[2],names[1]);
	cout<< "\n" << names[2];
}
