#include <stdio.h>
#include "utils.h"
#include "colors.h"
#include <stdlib.h>
#include <string.h>

void canvas_print(canvast *canvas){
    for (int i = 0; i<canvas->height;i++){
        for (int j=0; j<canvas->width;j++){
            color_e col = canvas->pixels[canvas->width*i+j];
            print_in_color(col);
        }
        printf("\n");
    }
    fflush(stdout);

}


canvast *create_canvas(int height, int width, color_e background) {
    color_e *colors = malloc(height*width*sizeof(color_e));
    canvast *canvas = malloc(sizeof(canvast));
    if (colors == NULL) {
        fprintf(stderr, "Memory allocation error.");
    }
    if (canvas == NULL) {
        fprintf(stderr, "Memory allocation error.");
        free(colors);
    }
    for (int i=0;i<width*height;i++){
        colors[i] = background;
    }
    canvas->height = height;
    canvas->width = width;
    canvas->pixels = colors;
    return canvas;
}


void delete_canvas(canvast *canvas) {
    free(canvas->pixels);
    free(canvas);
}


color_e color_converter(char *col){
    if (strcmp(col, "white") == 0) return COLOR_WHITE;
    if (strcmp(col, "black") == 0) return COLOR_BLACK;
    if (strcmp(col, "blue") == 0) return COLOR_BLUE;
    if (strcmp(col, "red") == 0) return COLOR_RED;
    if (strcmp(col, "magenta") == 0) return COLOR_MAGENTA;
    if (strcmp(col, "green") == 0) return COLOR_GREEN;
    if (strcmp(col, "cyan") == 0) return COLOR_CYAN;
    if (strcmp(col, "yellow") == 0) return COLOR_YELLOW;
    
    return COLOR_WHITE;

}


void canvas_fill(canvast *canvas, rectangle *rectangle){
    for (int i=0; i<canvas->height; i++){
        for (int j=0; j<canvas->width; j++){
            if (i>=rectangle->ly && i<=rectangle->ry && j>=rectangle->lx && j<=rectangle->rx){
                canvas->pixels[i*canvas->width+j] = rectangle->color;
            }
        }
    }




}


canvast *canvas_load_from_file(FILE *fptr){
    int canw;
    int canh;
    char canc[5];
    fscanf(fptr, "%d %d %s", canw, canh ,canc);
    color_e bg = color_converter(canc);
    canvast *canvas = create_canvas(canh,canw,bg);
    int x1, y1, x2, y2;
    while (fscanf(fptr, "%d %d %d %d %s", &x1, &y1, &x2, &y2, canc) == 5)
    {
        rectangle r;
        r.lx = x1;
        r.ly = y1;
        r.rx = x2;
        r.ry = y2;
        r.color = color_converter(canc);
        canvas_fill(canvas, &r);
    }
    fclose(fptr);
    return canvas;

}