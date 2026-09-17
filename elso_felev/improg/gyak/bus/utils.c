#include <stdio.h>
#include "utils.h"
#include <stdlib.h>
#include <string.h>

void menu(){
    printf("What would you like to do?\n1. Map\n2. List\n3. New stop\n4. Delete stop\n5. Save stops\n6. Load stops\n7. Quickest route\n8. Exit\n");
}

char getChar(){
    char c;
    do{
        c=getchar();
    } while(c=='\n');
    return c;
}

void createmap(char *map){
    for (int i=0;i<HEIGHT;i++){
        for (int j=0; j<WIDTH; j++){
            map[WIDTH*i+j] = ' ';
        }
    }
}

void printmap(char *map){
    printf(" ");
    for (int i=0;i<WIDTH; i++){
        printf("%d",i);
    }
    printf("\n");
    for (int i=0;i<HEIGHT; i++){
        printf("%d",i);
        for (int j=0;j<WIDTH;j++){
            printf("%c",map[WIDTH*i+j]);
        }
        printf("\n");
    }




}

void liststops(stop *stops, int *countp) {
    for(int i=0;i<*countp;i++){
        printf("%d. %s (%d, %d)\n", stops[i].num, stops[i].name, stops[i].x, stops[i].y);
    }
}


stop *createstop(int *capp, int *countp, stop *stops, int x, int y, char *name){
    (*countp)++;
    
    if (*countp>=*capp){
        *capp *= 2;
        stop *temp = realloc(stops,sizeof(stop)**capp);
        stops = temp;
    }
    int idx = *countp - 1;
    stops[idx].x = x;
    stops[idx].y = y;
    strcpy(stops[idx].name, name);
    stops[idx].num = *countp;
    return stops;
}