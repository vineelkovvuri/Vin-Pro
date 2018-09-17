/*program to convert given number in to words */
#include<stdio.h>
#include<math.h>
main()
{
unsigned long int n,k=1,s=0,j;char x[][10]={"one","two","three","four","five","six","seven","eight","nine","ten"};
char z[][10]={"twenty","thirty","fourty","fifty","sixty","seventy","eighty","ninty"};
char y[][10]={"eleven","tweleve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"};
printf("\nEnter n:");
scanf("%lu",&n);
/*k=(int)log10(n)+1; */
k=n;
for(j=1;k!=0;j++)
 {
  s=10*s+k%10;
  k/=10;
 }
    if(n>9999999){j=s%10;s/=10;n/=10;printf("%s crore ",x[j-1]);}

    if(n>999999){j=s%10;s/=10;n/=10;if(j==1)goto lakhs;else {printf("%s ",z[j-2]);goto lakh;}}
    lakhs:{j=s%10;s/=10;n/=10;printf("%s lakhs ",y[j-1]);}
    lakh:if(n>99999){j=s%10;s/=10;n/=10;printf("%s lakhs ",x[j-1]);}

    if(n>9999){j=s%10;s/=10;n/=10;if(j==1)goto thous;else {printf("%s ",z[j-2]);goto thou;}}
    thous:{j=s%10;s/=10;n/=10;printf("%s thousand ",y[j-1]);}
    thou:if(n>999){j=s%10;s/=10;n/=10;printf("%s thousand ",x[j-1]);}

    if(n>99){j=s%10;s/=10;n/=10;printf("%s hundred and ",x[j-1]);}

    if(n>9){j=s%10;s/=10;n/=10;if(j==1)goto tens;else {printf("%s ",z[j-2]);goto ten;}}
    tens:{j=s%10;s/=10;n/=10;printf("%s ",y[j-1]);}
    ten:if(n>0){j=s%10;s/=10;n/=10;printf("%s ",x[j-1]);}
     getch();
}
