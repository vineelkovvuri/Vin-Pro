#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;
int calculate_max_profit(int *stocks, int size)
{
	int max_profit = 0;
	int profit = 0;
	for (int i = 1; i < size; i++) {
		profit += stocks[i] - stocks[i-1];
		if (profit < 0)
			profit = 0;
		
		if (max_profit < profit)
			max_profit = profit;
	}

	return max_profit;
}

int buy_and_sell_stocks()
{
	int stock_prices[] = {310, 315, 275, 295, 260, 270, 290, 230, 255, 250};
	int size = sizeof(stock_prices)/sizeof(int);

	printf("max profit %d\n", calculate_max_profit(stock_prices, size));

	return 0;
}
	
