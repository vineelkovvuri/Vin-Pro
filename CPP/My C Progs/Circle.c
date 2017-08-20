#include <math.h>
#include <string.h>
#include <stdio.h>

int matherr (struct exception *a)
{
  if (a->type == DOMAIN)
    if (!strcmp(a->name,"sqrt")) {
      a->retval = sqrt (-(a->arg1));
    return 1;
    }
  return 0;
}

int main(void)
{
  double x = -2.0, y;
  y = sqrt(x);
  printf("Matherr corrected value: %lf\n",y);
  return 0;
}


