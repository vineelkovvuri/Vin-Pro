#include <stdio.h>
#include <ctype.h>
using namespace std;

int remove_duplicate_elements(char *a)
{
    int j = 0;
    int count = 1;
    int single_chars = 0;
    for (int i = 1; a[i]; i++, count++) {
        if (a[i] != a[j]) {
            if (count != 1)
                a[++j] = count;
            else
                single_chars++;
            count = 0;
            a[++j] = a[i];
        }
    }
    
    if (count != 1)
        a[++j] = count;
    else
        single_chars++;
    
    for (int i = j, k = j + single_chars; i >= 0;) {
        if (isalpha(a[i])) {
            a[k--] = 1;
            a[k--] = a[i--];
        }
        else {
            a[k--] = a[i--];
            a[k--] = a[i--];
        }
    }
    
    return j + single_chars + 1;
    
}

int runlength_encode()
{
    char a[100] = "aaaaaaaaaaaab";
    
    int len = remove_duplicate_elements(a);
    for (int  i = 0; i < len; i+=2) 
        printf("%c%d ", a[i], a[i+1]);

    return 0;
}
    
