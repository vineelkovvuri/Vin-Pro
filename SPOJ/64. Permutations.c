/*
 The solution needs some explanations.
 Lets denote number of permutations with n items having exactly k inversions
 by I(n, k)

 Now I(n, 0) is always 1. For any n there exist one and one permutation which have 0
 inversions i.e., when the sequence is increasingly sorted

 Now I(0, k) is always 0 since we don't have the sequence itself

 Now to find the I(n, k) lets take an example of sequence containing 4 elements
 {1,2,3,4}

for n = 4 below are the permutations enumerated and grouped by number of inversions
|___k=0___|___k=1___|___k=2___|___k=3___|___k=4___|___k=5___|___k=6___|
| 1234    | 1243    | 1342    | 1432    | 2431    | 3421    | 4321    |
|         | 1324    | 1423    | 2341    | 3241    | 4231    |         |
|         | 2134    | 2143    | 2413    | 3412    | 4312    |         |
|         |         | 2314    | 3144    | 4132    |         |         |
|         |         | 3124    | 3214    | 4213    |         |         |
|         |         |         | 4123    |         |         |         |
|         |         |         |         |         |         |         |
|I(4,0)=1 |I(4,1)=3 |I(4,2)=5 |I(4,3)=6 |I(4,4)=5 |I(4,5)=3 |I(4,6)=1 |
|         |         |         |         |         |         |         |

Now to find the number of permutation with n = 5 and for every possible k
we can derive recurrence I(5, k) from I(4, k) by inserting the nth (largest)
element(5) somewhere in each permutation in the previous permutations,
so that the resulting number of inversions is k

for example I(5,4) is nothing but the number of permutations of the sequence {1,2,3,4,5}
which has exactly 4 inversions each.
Lets observe I(4, k) now above until column k = 4 the number of inversions are <= 4
Now lets place the element 5 as shown below

|___k=0___|___k=1___|___k=2___|___k=3___|___k=4___|___k=5___|___k=6___|
| |5|1234 | 1|5|243 | 13|5|42 | 143|5|2 | 2431|5| | 3421    | 4321    |
|         | 1|5|324 | 14|5|23 | 234|5|1 | 3241|5| | 4231    |         |
|         | 2|5|134 | 21|5|43 | 241|5|3 | 3412|5| | 4312    |         |
|         |         | 23|5|14 | 314|5|4 | 4132|5| |         |         |
|         |         | 31|5|24 | 321|5|4 | 4213|5| |         |         |
|         |         |         | 412|5|3 |         |         |         |
|         |         |         |         |         |         |         |
|    1    |    3    |    5    |    6    |    5    |         |         |
|         |         |         |         |         |         |         |

Each of the above permutation which contain 5 has exactly 4 inversions.
So the total permutation with 4 inversions I(5,4) = I(4,4) + I(4,3) + I(4,2) + I(4,1) + I(4,0)
                                                  = 1 + 3 + 5 + 6 + 5 = 20

Similarly for I(5,5) from I(4,k)

|___k=0___|___k=1___|___k=2___|___k=3___|___k=4___|___k=5___|___k=6___|
|   1234  | |5|1243 | 1|5|342 | 14|5|32 | 243|5|1 | 3421|5| | 4321    |
|         | |5|1324 | 1|5|423 | 23|5|41 | 324|5|1 | 4231|5| |         |
|         | |5|2134 | 2|5|143 | 24|5|13 | 341|5|2 | 4312|5| |         |
|         |         | 2|5|314 | 31|5|44 | 413|5|2 |         |         |
|         |         | 3|5|124 | 32|5|14 | 421|5|3 |         |         |
|         |         |         | 41|5|23 |         |         |         |
|         |         |         |         |         |         |         |
|         |    3    |    5    |    6    |    5    |    3    |         |
|         |         |         |         |         |         |         |

So the total permutation with 5 inversions I(5,5) = I(4,5) + I(4,4) + I(4,3) + I(4,2) + I(4,1)
                                                  = 3 + 5 + 6 + 5 + 3 = 22

So I(n, k) = sum of I(n-1, k-i) such that i < n && k-i >= 0

Also k can go up to n*(n-1)/2 this occurs when the sequence is sorted in decreasing order
https://secweb.cs.odu.edu/~zeil/cs361/web/website/Lectures/insertion/pages/ar01s04s01.html
http://www.algorithmist.com/index.php/SPOJ_PERMUT1
http://www.alex.mennen.org/mahoniantri.pdf
*/




#include <stdio.h>

int dp[100][100];

int inversions(int n, int k)
{
    if (dp[n][k] != -1) return dp[n][k];
    if (k == 0) return dp[n][k] = 1;
    if (n == 0) return dp[n][k] = 0;
    int j = 0, val = 0;
    for (j = 0; j < n && k-j >= 0; j++)
        val += inversions(n-1, k-j);
    return dp[n][k] = val;
}

int main()
{
    int t;
    scanf("%d", &t);
    while (t--) {
        int n, k, i, j;
        scanf("%d%d", &n, &k);
        for (i = 1; i <= n; i++)
            for (j = 0; j <= k; j++)
                dp[i][j] = -1;
        printf("%d\n", inversions(n, k));
    }
    return 0;
}
