#ifndef UTILS_H
#define UTILS_H

#define HEIGHT 10
#define WIDTH 10

extern int table [WIDTH] [HEIGHT];
char getChar();
void menu();
void resetTable();
void printTable();
void init (char coords[101]);
void bombsAway (char coords[101]);
void winCheck();

#endif