#include <stdio.h>
#include "utils.h"
#include <stdlib.h>
#include <time.h>

#define STUD_CNT 128

int main(){
    srand(time(0));
    int size = 10;
    Student students[STUD_CNT];
    for (int i=0; i<size; ++i){
        students[i] = initStudent();
    }
    for (int i=0; i<size; ++i){
        printStudent(students[i]);
    }



    return 0;
}