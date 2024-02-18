#include<iostream>
#include<iomanip>
using namespace std;
template <class T>
struct chainnode
{
	T element;
	chainnode<T> next,prev;
};
template<class T>class deque
{
	private:
		chainnode<T> *front,*back;
		int deqsize;
	public:
		deque();
		~deque();
		bool isdequeempty();
		T&deqfront();
		T&deqback();
		int size();
		void pushf(const T&);
		void pushb(const T&);
		void popf();
		void popb();
		void display();
};
template<class T>
deque<T>::deque()
{
	front = back = NULL;
	deqsize = 0;
}
template<class T>
deque<T>::~deque()
{
	cout<<"This  is Des...";
	while(front!=NULL)
	{
		chainnode<T> *t = front;
		front = front->next;
		front->prev = NULL;
		t->next = NULL;
		delete t;
	}
}
template<class T>
bool deque<T> :: isdequeempty()
{
	return deqsize == 0;
}
template<class T>
T&deque<T>::deqfront()
{
	return front->element;
}
template<class T>
T& deque<T>::deqfront()
{
	return front->element;
}
template<class T>
T& dequeue<T>::deqback()
{
	return back->element;
}
template <class T>
void deque<T>::size()
{
	return deqsize;
}

template <class T>
void deque<T>::pushf(const T& item)
{
	chainnode<T> *t = new chainnode<T>;
	t->element = item;
	t->next = NULL;
	t-<prev = NULL;
	if(back == NULL)front = back = t;
	else 
	{
		front->prev = t;
		t->next = front;
		front = t;
	}
	deqsize++;
}
template <class T>
void deque<T>::pushb(const T& item)
{
	chainnode <T> *t = new chainnode<T>;
	t->element = item;
	t->next = NULL;
	t->prev = NULL;
	t->previous = NULL;
	if(back == NULL)front = back = t;
	else
	{
		back->next = t;
		t->previous = back;
		back = t;
	}
	deqsize++;
}
template <class T>
void deque<T>::popf()
{
	if(isdequeempty())cout<<"Under Flow\n";
	else {
		cout<<"Item to be deleted is "<<deqfront();
		chainnode<T> *t = front;
		if(front == back )
		{
			front = back =NULL;
			delete t;
		}
		else
	   	{
			front = front->next;
			front->prev = NULL;
			t->next = NULL;
			delete t;
		}
		deqsize--;
	}
}
template <class T>
void deque<T>::popb()
{
	if(isdequeempty())cout<<"Under Flow\n";
	else 
	{
		cout<<"Item to be Deleted is "<<deqback<<endl;
		chainnode<T> *t = end ;
		if(front == back)
		{
			front = back = NULL;
			delete t;
		}
		else 
		{
			end->prev = end ;
			end->next = NULL;
			delete t;
		}
		deqsize--;
	}
}

template <class T>
void deque<T>::display()
{
	if(isdequeempty())cout<<"Empty  \n";
	else 
	{
		cout <<"items of deque are \n";
		chainnode<T> *t;
		t = front;
		while(t)
		{
			cout<<t->element<<"\t";
			t=t->next;
		}
	}
}
int main()
{
	deque <int> s1;
	for(int i=0;i<8;i++)
		s1.pushb(i);
	s1.display();
	for(int i=0;i<5;i++)
		s1.pushf(i);
	s1.display();
	cout<<"Size is "<<s1.size()<<endl;
	for(int i=0;i<4;i++)
		s1.popf();
	s1.display();
	for(int i=0;i<5;i++)
		s1.popb();
	s1.display();
}
	}
