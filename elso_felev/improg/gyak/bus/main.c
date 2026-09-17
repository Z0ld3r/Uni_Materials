#include <stdio.h>
#include "utils.h"
#include <stdlib.h>


int main(){
    char c;
    char* map = malloc(sizeof(char)*HEIGHT*WIDTH);
    createmap(map);
    c = ' ';

    int cap = 2;
    int count = 0;
    stop *stops = malloc(sizeof(stop)*2);
    int *capp = &cap;
    int *countp = &count;


    while (c != '8'){
    menu();
    c=getChar();


    switch (c){
        case '1':
            printmap(map);
            break;
        case '2':
            liststops(stops, countp);
            break;
        case '3': {
            char name[20];
            int x;
            int y;
            printf("Give the stops name!\n");
            scanf("%s",&name);
            printf("Give the coordinates with a space between them!\n");
            scanf("%d %d", &x, &y);
            stops = createstop(capp,countp,stops, x, y, name);
            fflush(stdin);
            break;
        }
        case '8':
            printf("Exiting...");
            break;
        default:
            printf("Invalid option, try again!\n\n");
            break;
    }
    free(map);
    free(stops);

    }







    return 0;
}