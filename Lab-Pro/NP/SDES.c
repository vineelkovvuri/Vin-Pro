//Simple Data Encryption 
#include<stdio.h>
#include<conio.h>


void KeyGeneration(int k[],int *k1,int *k2);
void Fk(int p1[], int k1[], int *res);
void SW(int *res);
void Print(int a[],int n,char *name);
void Scan(int *a,int n);

main()
{
	int i, pt[10], k[10], k1[10], k2[10], res1[10], res2[10], p1[10],CipTxt[8],
		IP[10] = { 2, 6, 3, 1, 4, 8, 5, 7 },
		IP1[8] = { 4, 1, 3, 5, 7, 2, 8, 6 };

	printf("\nEnter an 8 bit binary plain text : ");
	Scan(pt,8);
	//  Print(pt,8,"P");

	printf("\nEnter an 10 bit binary key : ");
	Scan(k,10);

	//generating keys k1 , k2 basing on k
	KeyGeneration(k,k1,k2);
	printf("\n");
	Print(k1,8,"Generated Key k1");
	Print(k2,8,"Generated Key k2");

	//initial permutation
	for(i=0; i<8; i++)
		p1[i] = pt[IP[i]-1];

	Print(p1,8,"Initial Permutation");
	//apply function Fk 
	Fk(p1,k1,res1);

	Print(res1,8,"Resul1 after applying Function Fk");

	//apply switch function
	SW(res1);

	Print(res1,8,"Switch Function of Resul1");

	//apply function Fk 
	Fk(res1,k2,res2);

	Print(res2,8,"Resul2 after applying Function Fk");


	//inverse permutation
	for(i=0; i<8; i++)
		CipTxt[i] = res2[IP1[i]-1];

	Print(CipTxt,8,"Encrypted Text");
	getch();
}
void KeyGeneration(int k[],int *k1,int *k2)
{
	int a1[10], i, j, t,
		P10[10] = { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 },
		P8[8] = { 6, 3, 7, 4, 8, 5, 10, 9 };


	for(i=0; i<10; i++)
		a1[i] = k[P10[i]-1];

	//LS1 for the 1st 5 bits
	t = a1[0];
	for(i=0; i<4; i++)
		a1[i] = a1[i+1];
	a1[4] = t;

	//LS1 for the 2nd 5 bits
	t = a1[5];
	for(i=5; i<9; i++)
		a1[i] = a1[i+1];
	a1[9] = t;

	// applying P8 permutation and reducing a1 to 8 bits
	//to find k1
	for(i=0; i<8; i++)
		*(k1+i) = a1[P8[i]-1];


	for(j=0; j<2; j++)
	{
		//LS1 for the 1st 5 bits
		t = a1[0];
		for(i=0; i<4; i++)
			a1[i] = a1[i+1];
		a1[4] = t;

		//LS1 for the 2nd 5 bits
		t = a1[5];
		for(i=5; i<9; i++)
			a1[i] = a1[i+1];
		a1[9] = t;
	}

	// applying P8 permutation and reducing a1 to 8 bits
	//to find k2
	for(i=0; i<8; i++)
		*(k2+i) = a1[P8[i]-1];

	return;
}
void Fk(int p1[], int k[], int *res)
{
	int p2[10], p3[10],  m, n, i, bin, pos, p5[4],
		E_P[10] = { 4, 1, 2, 3, 2, 3, 4, 1 },
		S0[4][4] = { { 1, 0, 3, 2 },
		         	 { 3, 2, 1, 0 },
			         { 0, 2, 1, 3 },
			         { 3, 1, 3, 2 }
		           },	 
		S1[4][4] = { { 0, 1, 2, 3 },
			         { 2, 0, 1, 3 },
			         { 3, 0, 1, 0 },
			         { 2, 1, 0, 3 }
		           },	 
		P4[4] = { 2, 4, 3, 1 };

	//applying expansion/permutation operation for the last 4 bits
	for(i=0; i<8; i++)
		p2[i] = p1[ 4 + E_P[i]-1];

	//xor p2 and k1
	for(i=0; i<8; i++)
		p2[i] = p2[i] ^ k[i];

	//reducing to 4 bit 
	for(i=0; i<2; i++)
	{
		pos = i*4;
		m = p2[pos]*2+p2[pos+3];
		n = p2[pos+1]*2+p2[pos+2]; 

		bin = (i==0)?(S0[m][n]):(S1[m][n]);

		pos = i*2;
		p3[pos] = bin/2;
		p3[pos+1] = bin%2;
	}

	//applying p4 function
	for(i=0; i<4; i++)
		p5[i] = p3[P4[i]-1];

	//keeping the values in the res array 
	for(i=0; i<4; i++)
		*(res+i) = p1[i]^p5[i];

	for(i=4; i<8; i++)
		*(res+i) = p1[i];

	return;   
}
void SW(int *res)
{
	int i, t;
	for(i=0; i<4; i++)
	{
		t = *(res+i);
		*(res+i) = *(res+i+4);
		*(res+i+4) = t;
	}

	return;
}
void Print(int a[],int n,char *name)
{
	int i;
	printf("\n%s : ",name);
	for(i=0; i<n; i++)
		printf("%d",a[i]);
}
void Scan(int *a,int n)
{
	int i=0, t;
	while(1)
	{	
		t = getch();
		if(i==n && t!=8)  
			break;
		if(t==48 || t==49)  // t == 0 or t==1
		{
			*(a+i) = t-'0';
			printf("%d",*(a+i));
			i++;
		}
		else
			if(t==8 && i>0)
			{	
				printf("\b \b");
				i--;
			}
	}
	return;
}


/*
Logic :
=======
u have to do 6 thing 
1) generating keys  (k1 , k2)
2) apply initial permutation for the given txt
3) apply function Fk to the permutated o/p using the key k1
4) apply switch function to o/p of Fk (which just exchanges the right and left 4 bits)
5) apply function Fk to the switched o/p using the key k2
6) apply inverse permutation 

input: 
======
Enter an 8 bit binary plain text : 10111101
Enter an 10 bit binary key : : 1010000010

output :
=======
Generated Key k1 : 10100100
Generated Key k2 : 01000011
Initial Permutation : 01111110
Resul1 after applying Function Fk : 11001110
Switch Function of Resul1 : 11101100
Resul2 after applying Function Fk : 11101100
Encrypted Text : 01110101

*/

