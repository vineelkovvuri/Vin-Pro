#include <stdio.h>
#include <algorithm>
#include <utility>
#include <cmath>

using namespace std;

template <typename T> int sign(T val) {
    return (T(0) < val) - (val < T(0));
}

struct node {
	int ele;
	struct node *next;
};

node *reverse_list(node *head)
{
	node *curr = head;
	node *prev = NULL;
	node *next = NULL;

	while (curr) {
		next = curr->next;
		curr->next = prev;
		prev = curr;
		curr = next;
	}
	
	return prev;
}

node *create_new_node()
{
	node *n;
	n = new node;
	n->ele = 0;
	n->next = NULL;
	return n;
}

void append_empty_node_if_end(node *r)
{
	if (r->next == NULL)
		r->next = create_new_node();
}

node *multiplication_arbitrary_linkedlist(node *a, node *b)
{
	int carry = 0;
	int all_zeros = true;
	node *p, *q, *r, *rr, *c;
	a = reverse_list(a);
	b = reverse_list(b);
	
	c = create_new_node();
	
	for (p = a, r = c; p; p = p->next, r = r->next) {
		carry = 0;
		for (q = b, rr = r; q; q = q->next, rr = rr->next) {
			rr->ele += abs(p->ele) * abs(q->ele) + carry;
			carry = rr->ele / 10;
			rr->ele %= 10;
			append_empty_node_if_end(rr);
		}
		if (carry != 0) {
			rr->ele = carry;
			append_empty_node_if_end(rr);
		}
	}
	
	a = reverse_list(a);
	b = reverse_list(b);
	
	#if 1
	for (r = c; r; r = r->next) {
		if (r->ele != 0) {
			all_zeros = false;
			break;
		}
	}
	if (all_zeros) {
		r = c->next->next;
		while (r) {
			node *temp = r;
			r = r->next;
			free(temp);
		}
		c->next->next = NULL;
	}
	#endif
	
	c = reverse_list(c);
	node * temp = c;
	c = c->next;
	free(temp);
	
	// update the sign 
	c->ele *= sign(a->ele) * sign(b->ele); 
	
	return c;
}

int multiplication_arbitrary_linkedlist()
{
//	// 11234
//	node a5 = {4, NULL};
//	node a4 = {3, &a5};
//	node a3 = {2, &a4};
//	node a2 = {1, &a3};
//	node a1 = {1, &a2};
//
//	// 21234
//	node b5 = {4, NULL};
//	node b4 = {3, &b5};
//	node b3 = {2, &b4};
//	node b2 = {1, &b3};
//	node b1 = {2, &b2};
	
	// 11234
	node a5 = {0, NULL};
	node a4 = {0, &a5};
	node a3 = {0, &a4};
	node a2 = {0, &a3};
	node a1 = {0, &a2};
	
	// 21234
	node b5 = {0, NULL};
	node b4 = {0, &b5};
	node b3 = {0, &b4};
	node b2 = {0, &b3};
	node b1 = {0, &b2};
	
	node *res = multiplication_arbitrary_linkedlist(&a1, &b1);
	
	for (node *p = res;p; p = p->next)
		printf("%d ", p->ele);

	return 0;
}
