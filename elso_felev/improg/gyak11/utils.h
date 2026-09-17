#ifndef UTILS_H
#define UTILS_H

struct _Student {
    unsigned int id;
    double avg;
    short age;
};

typedef struct _Student Student;

Student initStudent();
void printStudent();

#endif