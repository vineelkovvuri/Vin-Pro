#include <stdio.h>

struct node {
	int i;
	struct node *next;
};

void insert(struct node **head_ref, struct node *new_node)
{
	struct node **current = NULL;

	if (*head_ref == NULL) {
		*head_ref = new_node;
		return;
	}

	for (current = head_ref;
		*current && (*current)->i < new_node->i;
		current = &(*current)->next);

	new_node->next = (*current)->next;
	*current = new_node;
}

int insert_node()
{
	struct node n5 = {15, NULL};
	struct node n4 = {14, &n5};
	struct node n3 = {13, &n4};
	struct node n2 = {2, &n3};
	struct node n1 = {1, &n2};
	struct node n0 = {0, &n1};

	struct node ins = {4, NULL};

	struct node *head = &n0;

	for (struct node *q = head; q; q = q->next)
		printf("%d \n", q->i);

	insert(&head, &ins);

	for (struct node *q = head; q; q = q->next)
		printf("%d \n", q->i);
    return 0;
}
