
/*********************************************************************************

	Program Name: 4033. Phone List
	Program Code: PHONELST
	Author: Vineel Kumar Reddy Kovvuri
	Date: Thu Oct  2 13:10:28 2014
	Idea:
		Cool learning about Trie data structure.
		- Idea is to scan all the strings in to a vector
		- vector is sorted for obvious reasons explained in insert function
		- We try to insert string from the vector in to the Trie
		- During insertion if we come across a new character that is not already
		- present in the trie we add it to the trie. But if the character is already
		- present then we should check if that is the end of another previously
		- inserted string. If this is the case then we false.
		- Else return true

	References:

*********************************************************************************/

#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>
#include <string>

using namespace std;

struct trie {
	struct trie *nodes[11];
	int word_ended;
} *root;

int insert(string &s) {
	struct trie *p = root;
	for (int i = 0; s[i]; i++) {
		int pos = s[i] - '0';
		if (p->nodes[pos] == NULL)
			p->nodes[pos] = new trie();
		else if (p->nodes[pos]->word_ended)//For this to work array should be sorted
			return false;			//So that string 911 comes before 9114568
		p = p->nodes[pos];
	}
	return p->word_ended = true;
}

int main()
{
	int t;
	vector<string> v;
	scanf("%d", &t);
	while (t--) {
		int n, i;
		v.clear();
		scanf("%d", &n);
		for (i = 0; i < n; i++) {
			string temp;
			cin >> temp;
			v.push_back(temp);
		}
		sort(v.begin(), v.end());
		root = new trie();
		for (i = 0; i < n; i++) {
			if (!insert(v[i])) {
				printf("NO\n");
				break;
			}
		}
		if (i >= n)
			printf("YES\n");
	}
	return 0;
}
