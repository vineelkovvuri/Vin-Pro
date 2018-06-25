
#include <iostream>
#include <cstdio>
#include <ctime>
#include <cstdlib>

using namespace std;

long long modmul(long long a, long long b, long long c)
{
	long long x = 0, y = a;
	while (b != 0) {
		if (b % 2 == 1)
			x = (x + y) % c;
		y = (y + y) % c;
		b /= 2;
	}
	return x % c;
}

long long modpow(long long a, long long b, long long c)
{
	long long x = 1, y = a;
	while (b != 0) {
		if (b % 2 == 1)
			x = modmul(x, y, c);
		y = modmul(y, y, c);
		b /= 2;
	}
	return x % c;
}

bool Miller(long long p,int iteration)
{
	if(p<2){
		return false;
	}
	if(p!=2 && p%2==0){
		return false;
	}
	long long s=p-1;
	while(s%2==0){
		s/=2;
	}
	for(int i=0;i<iteration;i++){
		long long a=rand()%(p-1)+1,temp=s;
		long long mod=modpow(a,temp,p);
		while(temp!=p-1 && mod!=1 && mod!=p-1){
			mod=modmul(mod,mod,p);
			temp *= 2;
		}
		if(mod!=p-1 && temp%2==0){
			return false;
		}
	}
	return true;
}

int main()
{
	long long p;
	int t;
	scanf("%d", &t); 
	while (t--) {
		scanf("%lld", &p);
		printf(Miller(p, 18)?"YES\n":"NO\n");
	}
	return 0;
}


