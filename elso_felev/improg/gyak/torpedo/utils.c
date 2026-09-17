#include <stdio.h>
#include "utils.h"
#include <stdbool.h>

void menu(){
    printf("\nHi!\nWhat would you like to do?\n1. Initialize table\n2. Bomb stuff\n3. Print table\n4. Reset table\n5. Check if you've won\n0. Exit\n");
}

char getChar() {
    char c;
    do {
        c = getchar();
    } while (c == '\n');
    return c;
}

void resetTable(){
    int i,j;
    for (i = 0; i < HEIGHT; i++){
        for (j=0;j<WIDTH;j++){
            table[j][i] = '.';
        }
    }
}


void printTable(){
    int i,j;
    for (i = 0; i < WIDTH; i++){
        for (j=0;j<HEIGHT;j++){
            printf("%c", table[j][i]);
        }
        printf("\n");
    }
}



void init (char coords[101]) {
    int i;
    int curx;
    int cury;

    for (i=0;coords[i] != '\0' && coords[i+1] != '\0' ;i+=2){
            curx = coords[i] - 'A';
            cury = coords[i+1] - '0';
            if (curx >= 0 && curx <= HEIGHT-1 && cury >= 0 && cury <= WIDTH-1) {
                table[curx][cury] = 'x';
            }
            else {
                printf("The following coordinates are wrong: %c %d.\n",curx+'A',cury);
            }
    }
}


void bombsAway (char coords[101]) {
    int i;
    int curx;
    int cury;

    for (i=0;coords[i] != '\0' && coords[i+1] != '\0' ;i+=2){
            curx = coords[i] - 'A';
            cury = coords[i+1] - '0';
            if (curx >= 0 && curx <= HEIGHT-1 && cury >= 0 && cury <= WIDTH-1) {
                table[curx][cury] = '*';
            }
            else {
                printf("The following coordinates are wrong: %c %d.\n",curx+'A',cury);
            }
    }
}


void winCheck(){
    int i, j;
    bool win = true;
    bool bombs = false;
    for (i=0; i<HEIGHT;i++){
        for (j=0; j<WIDTH;j++){
            if (table[i][j] == 'x'){
                win = false;
            }
            else if (table[i][j] == '*'){
                bombs = true;
            }
        }
    }
    if (win && bombs){
        printf("You have won!\n");
    }
    else {
        printf("You have not yet won!\n");
    }
}