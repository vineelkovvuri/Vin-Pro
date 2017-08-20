#include<stdio.h>
#include<conio.h>
main()
{
	char in[100],out[100];
	int i=0,j=0;
	clrscr();
	printf("\nEnter the input string: ");
	scanf("%s",in);
	
	out[0] = 'x';				//for starting x
	for(i=0,j=1;in[i];i++,j++)
	{
		out[j] = in[i];
		if(in[i] == 'x')
			out[++j] = 'x';
	}
	out[j] = 'x';				//ending starting x
	out[j+1] = '\0'; 	

	printf("\nStuffed string is %s",out);
	getch();
}



