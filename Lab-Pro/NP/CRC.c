
#include<stdio.h>
#include<conio.h>
#include<string.h>
void CRC(int ply[] ,int plylen, int in[],int inlen)
{

	int rem[40]={0},i,j;

	inlen = inlen + (plylen - 1);				
	memmove(rem,in,sizeof(int)*plylen);
	for(j=plylen;j<=inlen;j++)
	{
		if(rem[0] == 1)
			for(i=1;i<plylen;i++)
				rem[i] = ply[i]^rem[i];
		memmove(rem,rem+1,sizeof(int)*(plylen-1));
		if(j<inlen)rem[plylen-1] = in[j];
	}
	inlen = inlen - (plylen - 1);	
	printf("\nCRC is : ");
	for(i=0;i<inlen;i++)
		printf("%d",in[i]);

//	for(i=0;rem[i]!=1;i++);
	i=0;
	for(;i<plylen-1;i++)
		printf("%d",rem[i]);
}

main()
{	

	int crc12[40] = {1,0,0,0,0,0,0,0,1,1,1,1,1},
		crc16[40] = {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		crcitu[40] = {1,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1},
		plylen,in[40]={0}, inlen,i,ch;
	clrscr();
	printf("\n1.CRC12\n2.CRC16\n3.CRCITU\nEnter your choice:");
	scanf("%d",&ch);
	printf("\nEnter the length of the input string : ");
	scanf("%d",&inlen);
	printf("\nEnter the input string(ex: 1011 should be given as 1 0 1 1): ");
	for(i=0;i<inlen;i++)
		scanf("%d",&in[i]);
	switch(ch)
	{
		case 1:
			CRC(crc12,13,in,inlen);
			break;
		case 2:
			CRC(crc16,17,in,inlen);
			break;
		case 3:
			CRC(crcitu,17,in,inlen);
			break;
	}
	getch();
}

