/*
	Program to calculate Sqrt(x) for 0 < x < 2
	Vineel Kumar Reddy
*/

#include<stdio.h>
#include<math.h>
#include<stdlib.h>

#define MAX_DIG 100

#define GetDigit(x) ((x)%10)
#define GetCarry(x) GetDigit((x)/10)

typedef struct _NUM {
	int digits[MAX_DIG];
	int size;
}Number;



void ReverseNum( Number * op1 )
{
	int i=0,j=0;
	for(i = 0, j = op1->size - 1; i < j; i++, j--){
		int temp = op1->digits[i];
		op1->digits[i] = op1->digits[j];
		op1->digits[j] = temp;
	}
}

void PrintNum( Number * op1 )
{
	int i=0;
	for(i = 0; i < op1->size; i++){
		printf("%d-",op1->digits[i]);
	}
}

void Addition(Number * op1, Number * op2, Number *addVector)
{
	int i = 0,j = 0,k = 0;							   // k moves along the	
	int max,addCarry = 0;
	//Number * addVector = (Number *)calloc(1,sizeof(Number));
	
	ReverseNum(op1);								   // reverse the number
	ReverseNum(op2);



	max = (op1->size < op2->size) ? op2->size : op1->size ;

	for(i = 0; i < max; i++){
		int addValue = op1->digits[i] + op2->digits[i] + addCarry;
		addVector->digits[i] = GetDigit(addValue );
		addCarry =  GetCarry(addValue);
	}
	if(addCarry != 0) {
		addVector->digits[max] = addCarry;
	}
	addVector->size = max + 1;

	ReverseNum(op1);									// restore the number
	ReverseNum(op2);
	ReverseNum(addVector);

}
void Multiplicate(Number * op1, Number * op2, Number *mulVector)
{
	int i = 0,j = 0;
	int k = 0;					                       // k moves along the 

	//Number * mulVector = (Number *)calloc(1,sizeof(Number));

	ReverseNum(op1);								   // reverse the number
	ReverseNum(op2);

	for(j = 0; j < op2->size; j++){
		int mulCarry, addCarry, mulValue, addValue;
		mulCarry = addCarry = mulValue = addValue = 0;
		for(k = j, i = 0; i < op1->size; i++, k++){    // make sure k is moving to right in each level
			mulValue = op1->digits[i] * op2->digits[j] + mulCarry;
			mulVector->digits[k] = GetDigit(mulValue);
			mulCarry = GetCarry(mulValue);
		}
		if(mulCarry != 0) {
			mulVector->digits[k] = mulCarry;
		}


	}
	mulVector->size = k;  									// final result is ready in res...so set the number of digits

	ReverseNum(op1);									// restore the number
	ReverseNum(op2);
	ReverseNum(mulVector);

}

int main()
{
	int i=0,j=0; 
	Number op1 = {{0},0}, op2 = {{0},0}, res = {{0},0};

	printf("\nEnter the number of digits in first operand:");
	scanf("%d",&op1.size);
	printf("\nEnter the digits in first operand:");
	for(i = 0;i < op1.size;i++){
		scanf("%d",&op1.digits[i]);
	}
	
	//PrintNum(&op1);

	printf("\nEnter the number of digits in second operand:");
	scanf("%d",&op2.size);
	printf("\nEnter the digits in second operand:");
	for(i = 0;i < op2.size;i++)
		scanf("%d",&op2.digits[i]);

	//Multiplicate(&op1,&op2,&res);
	Addition(&op1,&op2,&res);
	PrintNum(&res);
}




