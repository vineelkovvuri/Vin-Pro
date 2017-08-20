#include <iostream>
#include <string>
using namespace std;
int main()
{
	while (1) {
		int n, i, v = 0, pv[7] = {1, 20, 360 /* not 20x20 */, 360*20, 360*20*20, 360*20*20*20, 360*20*20*20*20};
		string s;
		cin >> n;
		if (n == 0) break;
		for (i = n - 1; i >= 0; ) { /* i is decremented only if valid input is read */
			getline(cin, s); /* also read \n as empty string!!!!! so i is decremented only on valid inputs */
			if (s.compare("S")				 == 0) v += pv[i--] * 0;
			else if (s.compare(".")			 == 0) v += pv[i--] * 1;
			else if (s.compare("..")		 == 0) v += pv[i--] * 2;
			else if (s.compare("...")		 == 0) v += pv[i--] * 3;
			else if (s.compare("....")		 == 0) v += pv[i--] * 4;
			else if (s.compare("-") 		 == 0) v += pv[i--] * 5;
			else if (s.compare(". -") 		 == 0) v += pv[i--] * 6;
			else if (s.compare(".. -")		 == 0) v += pv[i--] * 7;
			else if (s.compare("... -")		 == 0) v += pv[i--] * 8;
			else if (s.compare(".... -")	 == 0) v += pv[i--] * 9;
			else if (s.compare("- -")		 == 0) v += pv[i--] * 10;
			else if (s.compare(". - -")		 == 0) v += pv[i--] * 11;
			else if (s.compare(".. - -")	 == 0) v += pv[i--] * 12;
			else if (s.compare("... - -")	 == 0) v += pv[i--] * 13;
			else if (s.compare(".... - -")	 == 0) v += pv[i--] * 14;
			else if (s.compare("- - -")		 == 0) v += pv[i--] * 15;
			else if (s.compare(". - - -")	 == 0) v += pv[i--] * 16;
			else if (s.compare(".. - - -")	 == 0) v += pv[i--] * 17;
			else if (s.compare("... - - -")	 == 0) v += pv[i--] * 18;
			else if (s.compare(".... - - -") == 0) v += pv[i--] * 19;
		}
		cout << v << endl;
	}
	return 0;
}
