#include<iostream>
#define _ std:: 
int n,a[110][110],t,i,j,m;int main(){_ cin>>t;while(t--){_ cin>>n;for(i=1;i<=n;i++){m=-1;for(j=1;j<=i;j++){_ cin>>a[i][j];a[i][j]+=_ max(a[i-1][j],a[i-1][j-1]);m=_ max(m,a[i][j]);}} _ cout<<m<<"\n";}return 0;}

