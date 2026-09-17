#include <stdio.h>
#include "utils.h"
#include "bus_stops.h"

void clearBuffer(){
    int c;
    while (c!='\n' && c!=EOF) { }
}

char getChar(){
    char c;
    do {
        c=getchar();
    } while(c=='\n');
    clearBuffer();
    return c;
}
