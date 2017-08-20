#include<iostream>
#include<cstdlib>
using namespace std;


main()
{
    
    float a[3][3];
    int n = 3,k,i,j;
    
    for(i=0;i<n;i++)
    for(j=0;j<n;j++)
    scanf("%f",&a[i][j]);
    
    
    
    
    for(k=0;k<n;k++)          //move diagonally  
    {
        for(i=k+1;i<n;i++)   //top to bottom
        {
          //  k=0;i=1;    
            for(j=k;j<n;j++) //left to right
            a[i][j] -= ((float)a[k][j]/a[k][k])*a[i][k];
        }
    }
                
    
    
    for(int i=0;i<n;i++)
    {
        for(int j=0;j<n;j++)
        printf("%f\t",a[i][j]);
        cout<<endl;
    }
    
    
    
    system("pause");
}
