
#include <stdio.h>

#define INF 999999999
#define MAX 50010

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

#define min3(a, b, c) (min2(min2(a, b), c))
#define max3(a, b, c) (max2(max2(a, b), c))

struct segment
{
	int leftBestSum;
	int rightBestSum;
	int max;
	int totalSum;
	int li, ri;
} seg[1<<17];

void segment_merge(struct segment *lseg, struct segment *rseg, struct segment *res)
{
	res->totalSum = lseg->totalSum + rseg->totalSum;
	res->leftBestSum = max2(lseg->leftBestSum, lseg->totalSum + rseg->leftBestSum);
	res->rightBestSum = max2(rseg->rightBestSum, rseg->totalSum + lseg->rightBestSum);
	res->max = max2(max2(lseg->max, rseg->max), lseg->rightBestSum + rseg->leftBestSum);
	res->li = lseg->li;
	res->ri = rseg->ri;
}

void segment_build(int li, int ri, int ni)
{
	if (li == ri) {
		scanf("%d", &seg[ni].max);
		seg[ni].li  = li;
		seg[ni].ri  = ri;
		seg[ni].leftBestSum = seg[ni].rightBestSum = seg[ni].totalSum = seg[ni].max;
		return;		
	} 
	int mid = (li + ri) / 2;
	segment_build(li, mid, 2*ni + 1);
	segment_build(mid + 1, ri, 2*ni + 2);
	segment_merge(&seg[2 * ni + 1], &seg[2 * ni + 2], &seg[ni]);
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
void segment_update(int ni, int idx, int val)
{
	if (idx == seg[ni].li && idx == seg[ni].ri) {
		seg[ni].max = val;
		seg[ni].leftBestSum = seg[ni].rightBestSum = seg[ni].totalSum = seg[ni].max;
		return;
	}

	int mid = (seg[ni].li + seg[ni].ri) / 2;
	if (idx <= mid) {
		segment_update(2*ni + 1, idx, val);
	} else if (idx >= mid + 1) {
		segment_update(2*ni + 2, idx, val);
	}
	segment_merge(&seg[2 * ni + 1], &seg[2 * ni + 2], &seg[ni]);
	return;
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
		int z, x, y;
		scanf("%d%d%d", &z, &x, &y); /* x and y are not zero indexed */
		if (z == 0)
			segment_update(0, x - 1, y);
		else 
			printf("%d\n", segment_query(x - 1, y - 1, 0).max);
	}
	return 0;
}


