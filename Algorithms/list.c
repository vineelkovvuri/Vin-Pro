#include<stdio.h>
#include<stdlib.h>

struct node{
	int val;
	struct node * next;
}head={0,NULL};

int even(struct node * link)
{
	return link->val%2 == 0;
};

int main()
{
	int arr[] = {1};//,2,4,5,6,1,9,0};
	int i=0;
	struct node *max  ;
	struct node *x = &head;
	for(i=0;i<sizeof(arr)/sizeof(int);i++){
		x = (x->next = malloc(sizeof *x));
		x->val = arr[i];
		x->next = NULL;
	}
	
	for(max = head.next; max != NULL; max = max->next){
		printf("%d\t",max->val);
	}

	for(max = x = &head; x->next != NULL; ){
		if(even(x->next)){
			struct node *temp = x->next;
			x->next = x->next->next;
			free(temp);
		}else{
			x = x->next;
		}
	}
	
	printf("\n");	
	for(max = head.next; max != NULL; max = max->next){
		printf("%d\t",max->val);
	}
	

}
