#include<stdio.h>
#include<math.h>
#include<string.h>
void quad(void);
void lin(int);
void det(int);
void inver(int);
void trans(int ,int );
double fact(int);
main()
{
	float x,y;char c[5];int l,m;
	char a[][6]={"+","-","*","/","pow","asin","acos","atan","sin","cos","tan","abs","hypot","sqrt",
		"cbrt","ceil","exp","sinh","cosh","tanh","asinh","acosh","atanh","exp2","fmax","fmin","%","ln",
		"log","floor","quad","lin","det","inver","trans","fact","ncr","npr","q"};
	while(1)
	{printf("\n+,-,*,/,pow,asin,acos,atan,sin,cos,tan,abs,hypot,sqrt,cbrt,ceil,exp,sinh,cosh,tanh,asinh,acosh,atanh,exp2,fmax,fmin,%,ln,log,floor,quad,lin,det,inver,trans,fact,ncr,npr:");
		printf("\nEnter 'q' to exit:");
		printf("\nEnter the operator :");
		scanf(" %s",c); 
		if(strcmp(c,a[0])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%f",x+y);}
		else if (strcmp(c,a[1])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%f",x-y);}
		else if (strcmp(c,a[2])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%f",x*y);}
		else if (strcmp(c,a[3])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%f",x/y);}
		else if (strcmp(c,a[4])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%lf",pow(x,y));}
		else if (strcmp(c,a[5])==0){scanf(" %f",&x);
			printf("=%lf",asin(x));}
		else if (strcmp(c,a[6])==0){scanf(" %f",&x);
			printf("=%lf",acos(x));}           
		else if (strcmp(c,a[7])==0){scanf(" %f",&x);
			printf("=%lf",atan(x));}  
		else if(strcmp(c,a[8])==0){scanf(" %f",&x);
			printf("=%lf",sin(x));}
		else if(strcmp(c,a[9])==0){scanf(" %f",&x);
			printf("=%lf",cos(x));}
		else if(strcmp(c,a[10])==0){scanf(" %f",&x);
			printf("=%lf",tan(x));}
		else if(strcmp(c,a[11])==0){scanf(" %f",&x);
			printf("=%lf",abs(x));}
		else if(strcmp(c,a[12])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%lf",hypot(x,y));}
		else if(strcmp(c,a[13])==0){scanf(" %f",&x);
			printf("=%lf",sqrt(x));}  
		else if(strcmp(c,a[14])==0){scanf(" %f",&x);
			printf("=%lf",cbrt(x));} 
		else if(strcmp(c,a[15])==0){scanf(" %f",&x);
			printf("=%lf",ceil(x));} 
		else if(strcmp(c,a[16])==0){scanf(" %f",&x);
			printf("=%lf",exp(x));}
		else if(strcmp(c,a[17])==0){scanf(" %f",&x);
			printf("=%lf",sinh(x));}                         
		else if(strcmp(c,a[18])==0){scanf(" %f",&x);
			printf("=%lf",cosh(x));}                        
		else if(strcmp(c,a[19])==0){scanf(" %f",&x);
			printf("=%lf",tanh(x));}                        
		else if(strcmp(c,a[20])==0){scanf(" %f",&x);
			printf("=%lf",asinh(x));}                         
		else if(strcmp(c,a[21])==0){scanf(" %f",&x);
			printf("=%lf",acosh(x));}                        
		else if(strcmp(c,a[22])==0){scanf(" %f",&x);
			printf("=%lf",atanh(x));}                         
		else if(strcmp(c,a[23])==0){scanf(" %f",&x);
			printf("=%lf",exp2(x));}                        
		else if(strcmp(c,a[24])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%f",fmax(x,y));}                        
		else if(strcmp(c,a[25])==0){scanf(" %f",&x);
			scanf(" %f",&y);
			printf("=%f",fmin(x,y));}                            
		else if(strcmp(c,a[26])==0){scanf(" %d",&l);
			scanf(" %d",&m);
			printf("=%lf",fmod(l,m));}                         
		else if(strcmp(c,a[27])==0){scanf(" %f",&x);
			printf("=%lf",log(x));}                            
		else if(strcmp(c,a[28])==0){scanf(" %f",&x);
			printf("=%lf",log10(x));}  
		else if(strcmp(c,a[29])==0){scanf(" %f",&x);
			printf("=%lf",floor(x));} 
		else if(strcmp(c,a[30])==0)quad();
		else if(strcmp(c,a[31])==0){printf("\nEnter the order:");
			scanf(" %d%d",&l,&m);
			lin(l);}
		else if(strcmp(c,a[32])==0){printf("\nEnter the order:");
			scanf(" %d%d",&l,&m);
			det(l);}
		else if(strcmp(c,a[33])==0){printf("\nEnter the order:");
			scanf(" %d%d",&l,&m);
			inver(l);}
		else if(strcmp(c,a[34])==0){printf("\nEnter the order:");
			scanf(" %d%d",&l,&m);
			trans(l,m);}
		else if(strcmp(c,a[35])==0){printf("\nEnter n:");
			scanf(" %d",&l);printf("=%lf",fact(l));}
		else if(strcmp(c,a[36])==0){printf("\nEnter n,r:");
			scanf( "%d%d",&l,&m);
			printf("=%lf",fact(l)/(fact(l-m)*fact(m)));}  
		else if(strcmp(c,a[37])==0){printf("\nEnter n,r:");
			scanf( "%d%d",&l,&m);
			printf("=%lf",fact(l)/(fact(l-m)));}
		else if(strcmp(c,a[38])==0)return 0;

	}
}  
void quad(void)
{
	float x,a,b,c,d,r,j;
	printf("\nenter a,b,c");
	scanf("%f%f%f",&a,&b,&c);
	if(a==0)
	{    x=-c/b;
		printf("common root %f",x);
	}
	d=b*b-4*a*c;
	if(d>=0&&a!=0)
	{
		r=-b/(2*a);
		j=sqrt(d)/(2*a);
		printf("real roots are %f,%f",r+j,r-j);
	}
	else if(d<0&&a!=0)
	{
		r=-b/(2*a);
		j=sqrt(-d)/(2*a);
		if(j>0)
			printf("imaginary roots are %f+%fi,%f-%fi",r,j,r,j);
		else if(j<0){printf("imaginary roots are %f%fi,",r,j);
			j=-1*j;printf("%f+%fi",r,j);}
	}
}

void det(int n)
{
	int i,j,k,m; double a[n][n],r;
	printf("\nEnter the elements:");
	for(i=0;i<n;i++)
		for(j=0;j<n;j++)
			scanf("%lf",&a[i][j]);
	for(m=0;m<n-1;m++)
	{ for(k=m;k<n-1;k++)
		{r=a[m][k+1]/a[m][m];
			for(i=m;i<n;i++)
				a[i][k+1]-=r*a[i][m];
		}
		a[0][0]*=a[m+1][m+1];
	}
	printf("\n%lf",a[0][0]);
}

void inver(int n)
{int i,j,k,x=-1;float a[n][n],b[n][n],r;
	printf("\nEnter the elements:");
	for(i=0;i<n;i++)
		for(j=0;j<n;j++)
		{scanf("%f",&a[i][j]);if(j==i)b[i][j]=1;else b[i][j]=0;}
	for(k=0;k<n;k++)
	{++x;
		for(i=0;i<n;i++)
			if(i!=x){r=a[i][x]/a[x][x];
				for(j=0;j<n;j++)
				{a[i][j]-=r*a[x][j];b[i][j]-=r*b[x][j];}
			}
	}
	for(i=0;i<n;i++)
	{for(j=0;j<n;j++)
		{b[i][j]/=a[i][i];
			printf("%f\t",b[i][j]);
		}
		printf("\n");
	}
}   

void lin(int n)
{
	int i,j,k,x=-1;float a[n][n+1],r;
	printf("\nEnter the coefficients(assuming equation is of the form ax+by=c):");
	for(i=0;i<n;i++)
		for(j=0;j<n+1;j++)
			scanf("%f",&a[i][j]);
	for(k=0;k<n;k++)
	{++x;
		for(i=0;i<n;i++)
		{if(i!=x){r=a[i][x]/a[x][x];
					 for(j=0;j<n+1;j++)
						 a[i][j]-=r*a[x][j];
				 }
		}
	}
	for(i=0;i<n;i++)
	{a[i][n]/=a[i][i];
		printf("\nx%d=%.38f",i+1,a[i][n]);}
}


void trans(int m,int n)
{
	int x[m][n],i,j,k;
	if(m>n)k=m;else if(m<n)k=n;else k=m;
	printf("\nEnter the matrix elements");
	for(i=0;i<k;i++)
		for(j=0;j<k;j++)
		{if(m>n){if(j>=n)x[i][j]=0;else scanf("%d",&x[i][j]);}
			else if(m<n) {if(i>=m)x[i][j]=0;else scanf("%d",&x[i][j]);}
			else scanf("%d",&x[i][j]);}
			printf("\nThe transpose of the given matrix is \n");
			for(i=0;i<k-1;i++)
				for(j=1;j<k;j++)
					if(i<j){x[i][j]=x[i][j]+x[j][i];
						x[j][i]=x[i][j]-x[j][i];
						x[i][j]=x[i][j]-x[j][i];}
						for(i=0;i<n;i++)
						{for(j=0;j<m;j++)
							printf("%d\t",x[i][j]);
							printf("\n");}
}
double fact(int n)
{  int i; double f=1;
	for(i=1;i<=n;i++)
		f=f*i;
	return f;
}
