#include <stdio.h>
#include "utils.h"
#include <string.h>
#include <stdlib.h>

void readAndStore(){
    char str[20];
    fgets(str, 20, stdin);
    int length = strlen(str);
    char* cpy_str = malloc(length * sizeof(char));
    strcpy(cpy_str, str);
    printf("Copy: %s\n", cpy_str);
    free(cpy_str);
}

void readFivePrintReverse(){
    char str[128];
    char* five_str[5];
    for (int i=0; i<5; i++){
        printf("A string: ");
        fgets(str, 128, stdin);
        five_str[i] = malloc(strlen(str) * sizeof(char));
        strcpy(five_str[i], str);
    }
    for (int i=4; i>=0; --i){
        printf("%d. word: %s\n", i, five_str[i]);
    }
    for (int i=0; i<5; i++){
        free(five_str[i]);
    }
}