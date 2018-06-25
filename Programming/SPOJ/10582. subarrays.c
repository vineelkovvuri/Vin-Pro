/*
	Idea here is to use segment trees.
*/

#include <stdio.h>

#define MAX 1000100

#define min2(a, b) ((a) < (b) ? (a) : (b))
#define max2(a, b) ((a) > (b) ? (a) : (b))

struct segment
{
	int max;
	int li, ri;
} seg[3*MAX];

void segment_merge(struct segment *lseg, struct segment *rseg, struct segment *res)
{
	res->max = max2(lseg->max, rseg->max);
}

void segment_build(int li, int ri, int ni)
{
	if (li == ri) {
		scanf("%d", &seg[ni].max);
		seg[ni].li  = li;
		seg[ni].ri  = ri;
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
	for (i = 0; i + M - 1 < N; i++)
		printf("%d ", segment_query(i, i + M - 1, 0).max);

	return 0;
}

