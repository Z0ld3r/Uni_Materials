#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>

char getChar() {
    char c;
    do {
        c = getchar();
    } while (c == '\n');
    return c;
}



int main(){
    char c, b;
    int cap = 1;
    int count = 0;
    char *ptr = malloc(sizeof(char)*cap);
    char *temp = NULL;
    c = getChar();
    while (c != '0')
    {
        if (cap == count){
            cap *=2;
            temp = realloc(ptr, sizeof(char)*cap);
            if (temp == NULL){
                printf("Allocation failed.");
            }
            else {
                ptr = temp;
            }
        }
        ptr[count]=c;
        count++;




        c = getChar();

    }
    
    for (int i=0;i<count;i++){
        printf("%c",ptr[i]);
    }


    free(ptr);
    return 0;
}