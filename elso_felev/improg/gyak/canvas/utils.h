#ifndef UTILS_H
#define UTILS_H
#include "colors.h"

typedef struct {
    int width;
    int height;
    color_e *pixels;
} canvast;

typedef struct {
    int lx;
    int ly;
    int rx;
    int ry;
    color_e color;
} rectangle;


canvast *create_canvas(int height, int width, color_e background);
void delete_canvas(canvast *canvas);
void canvas_print(canvast *canvas);
color_e color_converter(char *col);
canvast *canvas_load_from_file(FILE *fptr);
#endif