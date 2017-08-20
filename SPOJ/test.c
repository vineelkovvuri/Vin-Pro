#include <stdio.h>
#include <stdlib.h>
 
struct node
{
    int data;
    struct node *next;
};

void push(struct node** head, int data)
{
    struct node* node = (struct node*) malloc(sizeof(struct node));
     node->data = data;
     node->next = *head;
     *head = node;
}
 
void printList(struct node *node)
{
    while (node != NULL) {
        printf("%d ", node->data);
        node = node->next;
    }
}
  
struct node* makeEvenOdd(struct node *head)
{
    struct node *current = head;
    struct node *even = NULL, *evenHead = NULL;
    struct node *odd = NULL, *oddHead = NULL;
    
    while (current) {
        if (current->data % 2 == 0) { 	   //if current is at even nodecurrent is at even node
            if (even != NULL) {            //not the head of even listot the head of even list
                even->next = current;      //add current to even list
                even = even->next;         //progress forward
                current = current->next;   //move forward
                even->next = NULL;         //make end of even list point to nothing  
            } else {                       //Head of even list
                evenHead = even = current; //Hold the head of even list
                current = current->next;   // move the current to next
            }
        } else {
            if (odd != NULL) {
                odd->next = current;
                odd = odd->next;
                current = current->next;
                odd->next = NULL;
            } else {
                oddHead = odd = current;
                current = current->next;
            }
        }
    }

    //oddlist followed by evenlist
    if (odd) {
        odd->next = evenHead;
        return oddHead;
    } else {
        even->next = oddHead;
        return evenHead;
    }
}
 
int main()
{
    struct node* head = NULL;

    push(&head, 1);
    push(&head, 2);
    push(&head, 3);
    push(&head, 4);
    push(&head, 4);
    push(&head, 6);
    push(&head, 7);
 
    head = makeEvenOdd(head);
 
    printList(head);
 
    return 0;
}