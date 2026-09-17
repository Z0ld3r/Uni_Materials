#include <stdio.h>
#include <stdlib.h>
#include "utils.h"

char* get_line_start(char *things, int target_line_index) {
    char *ptr = things;
    int current_line = 0;

    if (target_line_index == 0) return ptr;

    while (*ptr != '\0') {
        if (*ptr == '\n') {
            current_line++;
            if (current_line == target_line_index) {
                return ptr + 1;
            }
        }
        ptr++;
    }
    return NULL;
}

void draw_str(const char *buff, char *things) {
	int i, row;
    int height = atoi(things);
    for (row = 0; row < height; row++) {
        for (i = 0; buff[i] != '\0'; i++) {
            char current_char = buff[i];
            
            if (current_char >= 'a' && current_char <= 'z') {
                int abc_index = current_char - 'a';
                int target_absolute_line = 1 + (abc_index * height) + row;
                
                char *line_ptr = get_line_start(things, target_absolute_line);

                if (line_ptr != NULL) {
                    while (*line_ptr != '\n' && *line_ptr != '\0') {
                        printf("%c", *line_ptr);
                        line_ptr++;
                    }
                }
            } else {
                printf("     "); 
            }
        }
        printf("\n");
    }
}