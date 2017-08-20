#include <stdio.h>
#include <stdlib.h>
int m=1,n=1;
int q[1500], k[1500], p[1500],ans[1500],kcount,pcount,qcount,count=0;
int board[1500][1500];	
void place_knight();
void place_pawn();
void place_queen();
void compute();
void display();
//void view();
int main() 
{
	int i,j;
	scanf("%d",&m);
	scanf("%d",&n);
	while(m != 0 && n != 0)
	{	
		scanf("%d",&qcount);
		for(i=1; i<=2*qcount; i++)
			scanf("%d",&q[i]);
		scanf("%d",&kcount);
		for(i=1; i<=2*kcount; i++)
			scanf("%d",&k[i]);
		scanf("%d",&pcount);
		for(i=1; i<=2*pcount; i++)
			scanf("%d",&p[i]);
		place_knight();
		place_pawn();
		place_queen();
		count++;
		compute();
		//view();
		scanf("%d",&m);
		scanf("%d",&n);
		for(i=1;i<=m;i++)
		for(j=1;j<=n;j++)
		board[i][j]=0;
	}
	display();
	return 0;
}

void place_knight()
{
	int i, x=1, y=2,a,b;
	for(i=1; i<=2*kcount; i=i+2)
	{
		a = k[i];
		b = k[i+1];
		board[a][b] = 2;
		if((a-x) > 0 && (b-y) > 0 && board[a-x][b-y] != 2)
		board[(a-x)][(b-y)] = 1;
	
		if((a+x) <= m && (b+y) <= n && board[a+x][b+y] != 2)
		board[(a+x)][(b+y)] = 1;

		if((a-x) > 0 && (b+y) <= n && board[a-x][b+y] != 2)
		board[(a-x)][(b+y)] = 1;

		if((a+x) <= m && (b-y) > 0 && board[a+x][b-y] != 2)
		board[(a+x)][(b-y)] = 1;

		if((a-y) > 0 && (b-x) > 0 && board[a-y][b-x] != 2)
		board[(a-y)][(b-x)] = 1;

		if((a+y) <= m && (b+x) <= n && board[a+y][b+x] != 2)
		board[(a+y)][(b+x)] = 1;

		if((a-y) > 0 && (b+x) > 0 && board[a-y][b+x] != 2)
		board[(a-y)][(b+x)] = 1;

		if((a+y) <= m && (b-x) <= n && board[a+y][b-x] != 2)
		board[(a+y)][(b-x)] = 1;
	}
}

void place_pawn()
{
	int i,a,b;
	for(i=1; i<=2*pcount; i=i+2)
	{
		a = p[i];
		b = p[i+1];
		board[a][b] = 3;
	}
}

void place_queen()
{
	int i,j,a,b;
	for(i=1; i<=2*qcount; i=i+2)
	{
		a = q[i];
		b = q[i+1];
		board[a][b] = 4;
		for(j=1; ;j++)
		{
			if(board[a+j][b] != 2 && board[a+j][b] != 3 && board[a+j][b] !=4 && (a+j) <= m)
			board[a+j][b]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a-j][b] != 2 && board[a-j][b] != 3 && board[a-j][b] !=4 && (a-j) > 0)
			board[a-j][b]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a][b+j] != 2 && board[a][b+j] != 3 && board[a][b+j] !=4 && (b+j) <= n)
			board[a][b+j]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a][b-j] != 2 && board[a][b-j] != 3 && board[a][b-j] != 4 && (b-j) > 0)
			board[a][b-j]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a-j][b-j] != 2 && board[a-j][b-j] != 3 && board[a-j][b-j] != 4 && (a-j) > 0 && (b-j) > 0)
			board[a-j][b-j]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a+j][b+j] != 2 && board[a+j][b+j] != 3 && board[a+j][b+j] != 4 && (a+j) <= m && (b+j) <= n)
			board[a+j][b+j]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a-j][b+j] != 2 && board[a-j][b+j] != 3 && board[a-j][b+j] != 4 && (a-j) > 0 && (b+j) <= n)
			board[a-j][b+j]=6;
			else break;
		}
		for(j=1; ;j++)
		{
			if(board[a+j][b-j] != 2 && board[a+j][b-j] != 3 && board[a+j][b-j] != 4 && (a+j) <= m && (b-j) > 0)
			board[a+j][b-j]=6;
			else break;
		}
	}
}

void compute()
{
	int i,j,k=0;
	for(i=1; i<=m; i++)
	{
		for(j=1; j<=n; j++)
			if(board[i][j] == 0)
				k++;
	}
	ans[count]=k;
}

void display()
{
	int i;
	for (i=1;i<=count;i++)
	printf("Board %d has %d safe squares.\n",i,ans[i]);
}

/*void view()
{
	int i,j;
	for(i=1; i<=m; i++)
	{
		for(j=1; j<=n; j++)
		printf("%d",board[i][j]);
		printf("\n");
	}
}*/
