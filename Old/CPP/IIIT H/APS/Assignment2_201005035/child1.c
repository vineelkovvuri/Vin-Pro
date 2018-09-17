#include<stdio.h>

long long int D(long long int X)
{
    long long int sum = 0;
    while(X != 0){
        sum += X%10;
        X /= 10;
    }    
    return sum;
}

int main()
{
    long long int A = 61,B = 65, n = 0,i = 0,count = 0; //repetition
    scanf("%lld",&A);
    scanf("%lld",&B);
    for(n = A; n <= B ; n++){
        for(i = 1; i <= 81; i+=1){
            long long int prd = i*n;
            if( D(prd) == i ){
                count++;
                break;
            }
        }
    }
    printf("%lld",B-A-count+1);
    
    return 0;    
}    
