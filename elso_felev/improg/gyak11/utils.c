#include <stdio.h>
#include "utils.h"
#include <stdlib.h>

int genRandom(int min, int max) {
    return rand() % (max-min+1)+min;
}


Student initStudent(){
    Student st;
    st.id = genRandom(1000,9999);
    st.avg = genRandom(100,500) / 100.0;
    st.age = genRandom(18,23);
    return st;
}


void printStudent(Student st){
    printf("----------\n");
    printf("-- Student id: %d --\n",st.id);
    printf("-- Student avg: %.2f --\n",st.avg);
    printf("-- Student age: %d --\n",st.age);
}