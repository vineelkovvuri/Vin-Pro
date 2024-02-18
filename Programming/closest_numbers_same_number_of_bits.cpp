// Program to find the closest numbers to the given number with the same bits
// one smaller and one larger than the given number

// 0b110110011
//         ^^  switching these bits will give us next higher number
//       ^^    switching these bits will give us next lower number

// 16-06-2016 07:16:02 PM

#include <iostream>

using namespace std;

static int get_bit(int n, int i)
{
	return (n >> i) & 1;
}

int get_lowest(int n)
{
	int i = 0;
	for (i = 0; i < 31; i++)
		if (get_bit(n, i) == 0 && get_bit(n, i + 1) == 1)
			return n ^ (3 << i); 
	return n;
}

int get_highest(int n)
{
	int i = 0;
	for (i = 0; i < 31; i++)
		if (get_bit(n, i) == 1 && get_bit(n, i + 1) == 0)
			return n ^ (3 << i); 
	return n;
}

int closest_numbers_same_number_of_bits()
{
	int n;
	cin >> n;
	cout << "\nlowest = " << get_lowest(n);
	cout << "\nhighest = " << get_highest(n);
	return 0;
}
