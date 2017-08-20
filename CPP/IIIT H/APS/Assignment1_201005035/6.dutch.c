#include<stdio.h>



int main()
{
   int a[]={0,1,2,1,2,0,0,2,1};
   int low,mid,i;					//intialize low,mid to 0 and high to max no of array
   int high=8;


   low=mid=0;
   while(mid<=high)					//to check the boundry condition,whem mid > size then terminate
      {
	 if(a[mid]==0)					//when checked elem is 0 than swap is with next member og lower bound and inc low and mid
	 {
		   a[low]=a[low]+a[mid];
		   a[mid]=a[low]-a[mid];
		   a[low]=a[low]-a[mid];
		   low++;
		   mid++;
	 }

	 else if(a[mid]==1)				//when no is 1 than simply inc mid
	 mid++;

	 else if(a[mid]==2)				//when no is 2 than swap is previou no of upper bound and dec upper bound
	 {
		   a[high]=a[high]+a[mid];
		   a[mid]=a[high]-a[mid];
		   a[high]=a[high]-a[mid];

		   high--;


	 }
      }

    for(i=0;i<9;i++)
    printf("%d",a[i]);
return 0;
}

