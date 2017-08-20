#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>

int main()
{
	char *arr;
	int n;
	int len;
	int i, l, r, mid;
	arr = malloc(sizeof(unsigned int) * (1200010));
	scanf("%d", &n);
	for (i = 0; i < n; i++) { 
		scanf("%s", arr);
		len = strlen(arr);

		if (len == 1) {
			arr[0] = arr[1] = '1';
			arr[2] = 0;
			printf("11\n");
			continue;
		}

		l = len / 2 - 1;  //skip mid - 1 incase of odd arrays and len / 2 - 1 happens to be the required mid for even length arrays
		r = len % 2 == 1 ? len / 2 + 1 : len / 2; //skip mid + 1 incase of odd length arrays no change for even arrays
		while(l >= 0 && r < len && arr[l] == arr[r]) {
			l--;
			r++;
		}
		
		if ((l < 0 && r >= len) || (arr[l] < arr[r])) {
			mid = len % 2 == 1 ? len / 2 : len / 2 - 1;// mid will be exact mid for odd length array for even length arrays there is no exact so we take len/2-1 as mid
			while(mid >= 0) {
				if (arr[mid] == '9') 
					arr[mid--] = '0';
				else {
					arr[mid] += 1;
					break;
				}
			}
			if (mid < 0) {
				//1 len-1 zeros 1
				arr[0] = '1';
				for (l = 1; l < len; l++)
					arr[l] = '0';
				arr[len] = '1';	
				arr[len + 1] = 0;
			} else {
				//copy left partition to right
				l = len / 2 - 1;  //skip mid - 1 incase of odd arrays and len / 2 - 1 happens to be the required mid for even length arrays
				r = len % 2 == 1 ? len / 2 + 1 : len / 2; //skip mid + 1 incase of odd length arrays no change for even arrays
				for (; l >= 0 && r < len; l--, r++)
					arr[r] = arr[l];
			}
		} else {
			// l and r at now at the correct positions to be copied
			//copy remaining left partition to right
			for (; l >= 0 && r < len; l--, r++)
				arr[r] = arr[l];
		}
		printf("%s\n", arr);
	}
	free(arr);
	return 0;
}
