
//floating point bit pattern in C 

//  1bit 8bits  23bits
//  7|65432107|65432107654321076543210	
//  S|   exp  |xxxxxxxxxxxxxxxxxxxxxxx
//
//	S = Sign Bit
//	exp = Exponent 
//	xxx = decimal notation according to the following formula. Its value will be .000000000000 - .9999999999
//
//	(-1)^S 1.xxxxxxxxxxxxx X 2^(exp-127)
//
//   example : = -5.25 
//	 S = 1
//	 5.25 = 1.3125X2^2 so exp = 2 + 127 = 129 = 10000001 (8 bits exp in binary)
//	 xxxx = .3125 = .0101000000000000000 (23 bits in binary)
//	
//	 1|10000001|01010000000000000000000  
//   S|   exp  | xxxxxxxxxxxxxxxxxxxx
//
#include<stdio.h>

int main()
{
	float t = -5.25;
	int i,f ;

	f = *(int*)&t;   //copies the content of the address of t as it is; where as f = (int)t will convert t to float and spoil the underlying floating representation.

	printf("7|65432107|65432107654321076543210 <-- Bit Position\n");
	for( i=31;i>=0;i--)
	{
		printf("%d",(f>>i)&1);
		if(i==31 || i == 23 ) printf("|");
	}	
}



