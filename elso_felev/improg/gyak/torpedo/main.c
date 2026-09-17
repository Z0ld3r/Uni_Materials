#include <stdio.h>
#include "utils.h"

int table [WIDTH] [HEIGHT];


int main(){

    int c;
    resetTable();
    while(c != '0'){
        menu();
        c = getChar();
        printf("\n");
        if (c=='1'){
            char coords [101];
            printf("Enter the coordinates on which you'd like to place your ship!\n");
            scanf(" %s", coords);
            init(coords);
            while (getchar() != '\n');
        }
        else if (c=='2'){
            char coords [101];
            printf("Enter the coordinates on which you'd like to drop bombs!\n");
            scanf(" %s", coords);
            bombsAway(coords);
            while (getchar() != '\n');
        }
        else if (c=='3'){
            printTable();
        }
        else if (c=='4'){
            resetTable();
            printf("The table has been reset.\n");
        }
        else if (c=='0'){
            printf("Exiting...");
        }
        else if (c=='5'){
            winCheck();
        }
        else {
            printf("Unknown option, try again!\n");
        }
    }

}