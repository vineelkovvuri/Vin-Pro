#include<stdio.h>
struct sort{char name[10];}s[5];
main()
{
int i,j,m;
printf("\nEnter the number of letters");
scanf("%d",&m);
printf("\nEnter the names:");
for(i=0;i<m;i++)
scanf("%s",s[i].name);
for(i=97;i<123;i++)
for(j=0;j<m;j++)
if(s[j].name[0]==i){printf("\n%s",s[j].name);}
//if(s[k-1].name[f]==s[k].name[f]){redhat(struct
}
