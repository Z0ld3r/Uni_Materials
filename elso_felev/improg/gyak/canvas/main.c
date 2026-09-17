#include <stdio.h>
#include "colors.h"
#include "utils.h"

int main (int argc, char *argv[]) {
    if (argc == 4){
        int h = atoi(argv[2]);
        int w = atoi(argv[1]);
        char *bgc = argv[3];
        color_e bg = color_converter(bgc);
        canvast *canvas = create_canvas(h,w,bg);
        canvas_print(canvas);
        delete_canvas(canvas);
    }
    else if (argc == 2){
        FILE *fptr = fopen(argv[1],"r");
        canvast *canvas = canvas_load_from_file(fptr);
        canvas_print(canvas);
    }
    else {
        printf("Wrong number of arguments.");
    }





    return 0;
}