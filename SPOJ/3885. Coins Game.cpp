/*********************************************************************************

	Program Name: 3885. Coins Game 
	Program Code: MCOINS
	Author: Vineel Kumar Reddy Kovvuri
	Date: Sat Oct  4 08:56:41 2014
	Idea:

	References:

*********************************************************************************/
#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>

using namespace std;

vector <bool> v(1000010);
int k, l;
void coins_game()
{
	v[0] = false;
	int maxlk = max(l, k);
	for (int i = 1; i <= 1000010; i++) {
		v[i] = !v[i-1];
		if (i - k >= 0 && v[i - k] == false)v[i] = true;
		if (i - l >= 0 && v[i - l] == false)v[i] = true;
	}
#if 0
	for (int j = 1; j <= 1000010;) {
		for (int i = 1; i <= maxlk + 1; i++)
			v[j++] = v[i]; 
	}
#endif
#if 1
	for (int j = 1; j <= 1000010;) {
		for (int i = 1; i <= maxlk + 1; i++)
			cout << v[j++] << " ";
		cout <<endl;
	}
#endif

}
int main()
{
	int m, i;
	scanf("%d%d%d", &k, &l, &m);
	coins_game();
	for (i = 0; i < m; i++) {
		int coins;
		scanf("%d", &coins);
		printf("%c", v[coins]? 'A' : 'B');
	}

	return 0;
}


