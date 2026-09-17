#include <stdio.h>
#include "utils.h"


char getChar() {
    char c;
    do {
        c = getchar();
    } while (c == '\n');
    return c;
}



Node* create_node(int value) {
    Node* n = malloc(sizeof(Node));
    n->left = NULL
    n->right = NULL 
    n->value = value;
    return n;
}