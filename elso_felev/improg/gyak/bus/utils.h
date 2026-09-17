#ifndef UTILS_H
#define UTILS_H

#define HEIGHT 10
#define WIDTH 10

typedef struct{
    int x;
    int y;
    char *name;
    int num;
} stop;


char getChar();
void menu();
void printmap(char *map);
void createmap(char *map);
void liststops(stop *stops, int *countp);
stop *createstop(int *capp, int *countp, stop *stops, int x, int y, char *name);

#endif