#include<iostream>
#include<algorithm>
#include<vector>


using namespace std;


int main()
{
	vector<bool> v;
	v.push_back(true);
	v.push_back(false);
	v.push_back(false);
	v.push_back(true);
	v.push_back(true);
	v.push_back(false);
	v.push_back(true);
	v.push_back(true);
	v.push_back(true);
	
	int i = count(v.begin(),v.end(),true);
	int j = count_if(v.begin(),v.end(),[](bool x){ return x==true;});
	
	cout<< i <<endl;
	
}

