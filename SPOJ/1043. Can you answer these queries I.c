/*
	Idea here is to perform the merges of the segments.
	for me a segment is composed of 5 parts.
	|pre npre max nsuf suf|
	pre   : prefix which is always +ve;
	npre  : negative prefix which is always -ve;  pre + npre is always negative thats why will not be part of max
	max   : max sum of the given segment
	nsuf  : negative suffix which is always -ve;  suf + nsuf is always negative thats why will not be part of max
	suf   : suffix which is always +ve;
	
	L : |pre npre max nsuf suf|
	R : |pre npre max nsuf suf|
	
	Max[L-R] = max of { L.max, 
					  R.max,
					  L.suf + R.pre,  L.suf + R.pre > 0
					  L.suf + R.pre + R.npre + R.max,
					  R.pre + L.suf + L.nsuf + L.max,
					  L.max + L.nsuf + L.suf + R.pre + R.npre + R.max
	}
	Accordingly update pre, npre, nsuf, suf for each case.

*/

#include <stdio.h>

#define INF 999999999
#define MAX 50010

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

#define min3(a, b, c) (min2(min2(a, b), c))
#define max3(a, b, c) (max2(max2(a, b), c))

struct segment
{
	int pre;
	int npre;
	int max;
	int nsuf;
	int suf;
	int li, ri;
} seg[1<<17];

void segment_merge(struct segment *lseg, struct segment *rseg, struct segment *res)
{
	res->max = -INF;
	
	if (res->max < lseg->max) {
		res->max = lseg->max;
		res->npre = lseg->npre;
		res->pre = lseg->pre;
		
		res->nsuf = min3(lseg->nsuf,
						lseg->nsuf + lseg->suf + rseg->pre + rseg->npre,
						lseg->nsuf + lseg->suf + rseg->pre + rseg->npre + rseg->max + rseg->nsuf);
		if (res->nsuf > 0) res->nsuf = 0;
		res->suf  = max3(rseg->suf, 
						rseg->suf + rseg->nsuf + rseg->max,
						rseg->suf + rseg->nsuf + rseg->max + rseg->npre + rseg->pre + lseg->suf);
		if (res->suf < 0) res->suf = 0;
	}
	if (res->max < rseg->max) {
		res->max = rseg->max;
		res->nsuf = rseg->nsuf;
		res->suf = rseg->suf;

		res->npre = min3(rseg->npre,
						rseg->npre + rseg->pre + lseg->suf + lseg->nsuf,
						rseg->npre + rseg->pre + lseg->suf + lseg->nsuf + lseg->max + lseg->npre);
		if (res->npre > 0) res->npre = 0;				
		res->pre  = max3(lseg->pre, 
						lseg->pre + lseg->npre + lseg->max,
						lseg->pre + lseg->npre + lseg->max + lseg->nsuf + lseg->suf + rseg->pre);
		if (res->pre < 0) res->pre = 0;
	}
	if (res->max < lseg->suf + rseg->pre && lseg->suf + rseg->pre > 0) {
		res->max = lseg->suf + rseg->pre;

		res->nsuf = min2(rseg->npre, rseg->npre + rseg->max + rseg->nsuf);
		if (res->nsuf > 0) res->nsuf = 0;
		res->suf  = max2(rseg->suf, rseg->suf + rseg->nsuf + rseg->max);
		if (res->suf < 0) res->suf = 0;
		
		res->npre = min2(lseg->nsuf, lseg->nsuf + lseg->max + lseg->npre);
		if (res->npre > 0) res->npre = 0;
		res->pre  = max2(lseg->pre, lseg->pre + lseg->npre + lseg->max);
		if (res->pre < 0) res->pre = 0;
	}
	if (res->max < lseg->suf + rseg->pre + rseg->npre + rseg->max) {
		res->max = lseg->suf + rseg->pre + rseg->npre + rseg->max;
		res->nsuf = rseg->nsuf;
		res->suf = rseg->suf;

		res->npre = min2(lseg->nsuf, lseg->nsuf + lseg->max + lseg->npre);
		if (res->npre > 0) res->npre = 0;
		res->pre  = max2(lseg->pre, lseg->pre + lseg->npre + lseg->max);
		if (res->pre < 0) res->pre = 0;
	}
	if (res->max < lseg->max + lseg->nsuf + lseg->suf + rseg->pre) {
		res->max = lseg->max + lseg->nsuf + lseg->suf + rseg->pre;
		res->pre = lseg->pre;
		res->npre = lseg->npre;
		
		res->nsuf = min2(rseg->npre, rseg->npre + rseg->max + rseg->nsuf);
		if (res->nsuf > 0) res->nsuf = 0;
		res->suf  = max2(rseg->suf, rseg->suf + rseg->nsuf + rseg->max);
		if (res->suf < 0) res->suf = 0;
	}
	if (res->max < lseg->max + lseg->nsuf + lseg->suf + rseg->pre + rseg->npre + rseg->max) {
		res->max = lseg->max + lseg->nsuf + lseg->suf + rseg->pre + rseg->npre + rseg->max;
		res->pre = lseg->pre;
		res->npre = lseg->npre;
		res->suf = rseg->suf;
		res->nsuf = rseg->nsuf;
	}
}

void segment_build(int li, int ri, int ni)
{
	if (li == ri) {
		scanf("%d", &seg[ni].max);
		seg[ni].li  = li;
		seg[ni].ri  = ri;
		seg[ni].pre = seg[ni].npre = seg[ni].suf = seg[ni].nsuf = 0;
		return;		
	} 
	int mid = (li + ri) / 2;
	segment_build(li, mid, 2*ni + 1);
	segment_build(mid + 1, ri, 2*ni + 2);
	segment_merge(&seg[2 * ni + 1], &seg[2 * ni + 2], &seg[ni]);
	seg[ni].li  = li;
	seg[ni].ri  = ri;
	return;
}

struct segment segment_query(int li, int ri, int ni)
{
	if (li == seg[ni].li && ri == seg[ni].ri)
		return seg[ni];

	int mid = (seg[ni].li + seg[ni].ri) / 2;
	struct segment left, right, res;
	if (ri <= mid) {
		left = segment_query(li, ri, 2*ni + 1);
		return left;
	} else if (li >= mid + 1) {
		right = segment_query(li, ri, 2*ni + 2);
		return right;
	} else {
		left = segment_query(li, mid, 2*ni + 1);
		right = segment_query(mid + 1, ri, 2*ni + 2);
		segment_merge(&left, &right, &res);
		return res;
	}
}

int main()
{
	int M, N, i;
	scanf("%d", &N);
	segment_build(0, N - 1, 0);
//	for (i = 0; i < 2 * N + 1; i++)
//		printf("|li,ri| = |%-2d,%-2d| pre = %5d npre = %5d |max = %5d| nsuf = %5d suf = %5d\n", seg[i].li, seg[i].ri, seg[i].pre, seg[i].npre,seg[i].max,seg[i].nsuf, seg[i].suf);

	scanf("%d", &M);
	for (i = 0; i < M; i++) {
		int x, y;
		scanf("%d%d", &x, &y); /* x and y are not zero indexed */
		printf("%d\n", segment_query(x - 1, y - 1, 0).max);
	}
	return 0;
}


