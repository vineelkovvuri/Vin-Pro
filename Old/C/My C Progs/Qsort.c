 #include<stdio.h>
 int qsort(int,int);
 int a[20];
 main()
 {int l=0,h,i;
 printf("\nEnter the size of the array:");
 scanf(" %d",&h);--h;/*Enter the total number of elements in an array*/
 printf("\nEnter the elements:");
 for(i=l;i<=h;i++)
 scanf("%d",&a[i]);
 qsort(l,h);
 for(i=0;i<=h;i++)
 printf("%d ",a[i]);
 }
 int qsort(int l,int h)
 {int r,i,j,t;
  r=(l+h)/2;
 if(l!=h){ for(i=l;i<r;)
          if(a[i]>a[r]){for(j=i;j<r;j++)
                         {t=a[j];a[j]=a[j+1];a[j+1]=t;}
			if(r!=l)--r; if(i!=l)--i;
		       }
	   else ++i;
          for(i=r+1;i<=h;i++)
	    if(a[i]<a[r]){for(j=i;j>r;j--)
			   {t=a[j];a[j]=a[j-1];a[j-1]=t;}
			  ++r;
			 }
        if(r!=l)qsort(l,r-1);
        if(r!=h)qsort(r+1,h);
       }
 else return;
 }	
