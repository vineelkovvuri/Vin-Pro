/************************************************************************
 *
 * Purpose: To sort numbers held in an array.
 * Author:  M.J.Leslie
 * Date:    30-Nov-94
 *
 ************************************************************************/
/********** Preprocessor  ***********************************************/
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
/********** Functions ***************************************************/
void display_nums(int *, int);
int comp_nums(const int *, const int *);
/********** main ********************************************************/
main()
{  int numbers[]=			/* Numbers to be sorted.	*/
  {43,76,23,1,100,56,23,99,33,654};
  int how_many=10;			/* Number of numbers entered	*/
  puts("\nThese are the unsorted numbers\n");
  display_nums(numbers, how_many);
					/* SORT the numbers held in 
					 * 'numbers'.			*/
  qsort(
        numbers, 			/* Pointer to elements		*/
        how_many, 			/* Number of elements		*/
        sizeof(int),  			/* size of one element.		*/
        (void *)comp_nums		/* Pointer to comparison function */
       );
  puts("\nThese are the sorted numbers\n");
  display_nums(numbers, how_many);
}
/************************************************************************
 *
 * comp_nums: Compare two numbers.
 *
 ************************************************************************/
int comp_nums(const int *num1, const int *num2)
{
  if (*num1 <  *num2) return -1;
  if (*num1 == *num2) return  0;
  if (*num1 >  *num2) return  1;
}
/************************************************************************
 *
 * display_nums: Display the numbers
 *
 ************************************************************************/

void display_nums(int *array, int count)
{
					/* Print all the elements in 
					 * the array.               	*/
  while ( count-- )
  {
    printf("%d ",*array);
    array++;
  }
  puts("");
}
/******* The Results ****************************************************
 *
 *	These are the unsorted numbers
 *	
 *	43 76 23 1 100 56 23 99 33 654 
 *	
 *	These are the sorted numbers
 *	
 *	1 23 23 33 43 56 76 99 100 654 
 *
 ************************************************************************/

