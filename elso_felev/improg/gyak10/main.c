#include <stdio.h>
#include "utils.h"
#include <string.h>
#include <stdlib.h>


int main(int argc, char** argv) {
    if (argc != 2)
    {
        fprintf(stderr, "Please provide a number!\n");
        return 1;
    }
    char* end;
    int chosen = strtol(argv[1], &end, 10);
    switch (chosen){
        case 1:

            break;
        default:
            fprintf(stderr, "There is no such option!\n");
            break;
    }

    return 0;
}