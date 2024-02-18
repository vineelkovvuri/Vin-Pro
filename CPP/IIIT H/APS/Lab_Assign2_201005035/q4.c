

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
void create_node(char []);
//void print_strings();
void max();
void print_pattern();
int maxcount, maxstring;
struct node
{
	char string[100];
	int count;
	struct node *link;
};
typedef struct node *NODE;

NODE getnode()
{
	NODE p;
	p=(NODE)malloc(sizeof(struct node));
	return(p);
}
NODE prev=NULL, cur=NULL, head=NULL;
int main()
{
	FILE *fp;
	char filename[100],ch, buffer[100];
	int flag=0,i=0;
	scanf("%s",filename);
	fp = fopen(filename, "r");
	if(fp == NULL)
	{
		printf("\nInvalid entry or file not found\n");
		exit(1);
	}
	ch = fgetc(fp);
	while(ch != EOF)
	{
		if((ch == ' ' || ch == '\n' || ch == '\t') && flag == 1)
		{
			buffer[i]='\0';
			create_node(buffer);
			char buffer[100]={'\0'};
			i=0;
			flag=0;
		}
		else if(ch >= 'a' && ch <='z')
		{
			ch=ch-32;
			buffer[i++]=ch;
			flag=1;
		}
		else if(ch >= 'A' && ch <= 'Z')
		{
			buffer[i++]=ch;
			flag=1;
		}
		else
		{
			buffer[i++]=ch;
			flag=1;
		}
		ch = fgetc(fp);
	}
	//print_strings();
	max();
	print_pattern();
	return 0;
}

void create_node(char buffer[])
{
	NODE temp;
	cur=getnode();
	strcpy(cur->string,buffer);
	cur->count=1;
	if(head == NULL || (strcmp(cur->string, head->string) < 0))
	{
		cur->link=head;
		head=cur;
	}
	else if(strcmp(cur->string, head->string) == 0)
	{
		head->count=head->count+1;
		return;
	}
	else 
	{
		prev=head;
		for(temp=head; temp!=NULL; temp=temp->link)
		{
			if(strcmp(cur->string,temp->string) < 0)
			{
				prev->link=cur;
				cur->link=temp;
				return;
			}
			else if(strcmp(cur->string,temp->string) == 0)
			{
				temp->count=temp->count+1;
				return;
			}
			prev=temp;
		}
		prev->link=cur;
		cur->link=NULL;
	}
	return;
}

/*void print_strings()
{
	NODE temp;
	for(temp=head; temp!=NULL; temp = temp->link)
	{
		printf("%s:%d\n",temp->string,temp->count);
	}
}*/

void max()
{
	NODE temp;
	for(temp=head; temp!=NULL; temp=temp->link)
	{
		if(temp->count > maxcount)
		maxcount=temp->count;
		if(strlen(temp->string) > maxstring)
		maxstring=strlen(temp->string);
	}
	return;
}

void print_pattern()
{
	NODE temp;
	int i;
	for(i=maxcount; i>0; i--)
	{
		for(temp=head; temp!=NULL; temp=temp->link)
		{
			if(i <= temp->count)
			{
				printf("* ");
			}
			else printf("  ");
		}
		printf("\n");
	}
	for(temp=head; temp!=NULL; temp=temp->link)
	printf("- ");
	printf("\n");
	for(i=0; i<=maxstring; i++)
	{
		for(temp=head; temp!=NULL; temp=temp->link)
		{
			if(i < strlen(temp->string))
			printf("%c ",temp->string[i]);
			else printf("  ");
		}
		printf("\n");
	}
	return;
}
