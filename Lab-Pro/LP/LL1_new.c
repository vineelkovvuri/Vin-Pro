
//This is auto generated C template by vim 
//To move to Body field press CTRL+j


#include<stdio.h>
#include<stdlib.h>
#include<math.h>

char *gm[]={
	"ETX",		//E  -> TE'
	"X+TX",		//E' -> +TE'
	"X#",		//	  | epsilon
	"TFY",		//T  -> FT'
	"Y*FY",		//T' -> *FT'
	"Y#",		//	  | epsilon
	"F(E)",		//F  -> (E)
	"Fi",		//    | id
};
char fitab[10][10];//first table
//char FlTab[10][10];

int idx;

int getindex(char ch)
{
	int i;
	for(i = 0;i < 8; i++)
		if(gm[i][0] == ch)return i;
	return -1;
}


first(int t)
{
	if(gm[t][1] >= 'A' && gm[t][1] <= 'Z'){
		int i;
		i = getindex(gm[t][1]);	
		do{
			first(i);
		}while(gm[i][0] == gm[++i][0]);
	}
	else {
		fitab		
	}
}



main()
{
	int i;
	for(i=0;i<8;i++)
		first(idx = i);	
}



