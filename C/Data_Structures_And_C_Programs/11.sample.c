#include <stdio.h>
#include <stdlib.h>

struct sample {
    const int price;
    const int price2;
};

int main()
{
    const int x = 10;
    struct sample *s1 = calloc(1, sizeof(struct sample));
    s1->price = x;
    s1->price2 = x;
}