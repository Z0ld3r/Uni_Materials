#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <time.h>

#define WIDTH 10
#define LENGTH 10

typedef enum DIRECTION {up,down,left,right} direction;

char table[WIDTH] [LENGTH];

char getChar(){
    char c;
    do {
        c = getchar();
    } while (c == '\n');
    return c;
}

bool issnake(int num){
    if (table [num/10] [num%10] == 'x'){
        return true;
    }
    else {
        return false;
    }
}

int newapple(){
    
    int ap = rand() % 100;
    if (issnake(ap)){
        ap = newapple();
    }
    return ap;
}


void setup(int *snake){
    for (int i=0;i<WIDTH; i++){
        for (int j=0;j<LENGTH; j++){
            table[i][j] = '.';
        }
    }
    table [snake[0]/10] [snake[0]%10] = 'x';
    table [snake[1]/10] [snake[1]%10] = 'x';
    table [snake[2]/10] [snake[2]%10] = 'x';

    int apple;
    apple = newapple();
    table[apple/10][apple%10] = 'o';
}

void drawtable(){
    for (int i=0;i<WIDTH; i++){
        for (int j=0;j<LENGTH; j++){
            printf("%c",table[i][j]);
        }
        printf("\n");
    }
}

bool isapple(int num){
    if (table [num/10] [num%10] == 'o'){
        return true;
    }
    else {
        return false;
    }
}

void extendcheck(int *lastnum, int *cap, int **snakep){
        int *temp;
        if (*cap <= *lastnum){
            *cap *=2;
            temp = realloc(*snakep, sizeof(int)*(*cap));
            if (temp == NULL){
                printf("Allocation failed.");
            }
            else {
                *snakep = temp;
            }
        }
}


int get_next_pos(int current_pos, direction dir) {
    switch (dir) {
        case up:    return current_pos - 10;
        case down:  return current_pos + 10;
        case left:  return current_pos - 1;
        case right: return current_pos + 1;
        default:    return current_pos;
    }
}

void minimoveap(int **snakep, direction *next, int *lastnum, int *cap){
    (*lastnum)++;
    extendcheck(lastnum, cap, snakep);
    int *s = *snakep;
    for (int i=*lastnum;i>1;i--){
        s[i] = s[i-1];
    }

    
    switch (*next)
    {
    case up:
        s[0] += 1;
        break;
    case down:
        s[0] -= 1;
        break;
    case left:
        s[0] -= 10;
        break;
    case right:
        s[0] += 10;
        break;
    
    default:
        break;
    }
}



void minimovedef(int *snake, direction *next, int *lastnum){
    int temp = 0;
    switch (*next)
    {
    case up:
        temp = snake[0]+1;
        break;
    case down:
        temp = snake[0]-1;
        break;
    case left:
        temp = snake[0]-10;
        break;
    case right:
        temp = snake[0]+10;
        break;
    
    default:
        break;
    snake[*lastnum] = 0;
    for (int i=*lastnum;i>1;i--){
        snake[i] = snake[i-1];
    }
    snake[0] = temp;
    }
}




bool move(direction *prev, direction *next, int *snake, int *lastnum, int *cap) {
    bool suc = true;
    if ((*prev == down && &*next == up) || (*prev == up && *next == down) || (*prev == left && *next == right) || (*prev == right && *next == left)){
        suc = false;
    }
    else{
        if ((isapple(snake[0]+1) && (*next == up)) || (isapple(snake[0]-1) && (*next == down)) || (isapple(snake[0]+10) && (*next == right)) || (isapple(snake[0]-10) && (*next == left)))
        {
            minimoveap(&snake, next, lastnum, cap);
            int ap = newapple();
            table[ap/10] [ap%10] = 'o';
        }
        else {
            minimovedef(snake, next, lastnum);
        }
        *prev = *next;




    }







    return suc;
}


void updateTable(int *snake, int *lastnum) {
    for (int i=0;i<WIDTH; i++){
        for (int j=0;j<LENGTH;j++){
            if (table[i][j] != 'o'){
                table[i] [j] = '.';
            }
        }
    }
    for (int i= 0; i<*lastnum; i++){
        table[snake[i]/10] [snake[i]%10] = 'x';
    }
}



int main() {
    int head = 44;
    int tail = 54;
    int end = 64;
    char input = ' ';
    direction prev = up;
    direction next;
    direction *nextp = &next;
    direction *prevp = &prev;
    bool suc;
    int lastnum = 3;
    int cap = 4;
    srand(time(NULL));
    int *snake = malloc(sizeof(int)*3);
    if (snake == NULL){
        printf("Memory allocation failed.");
        exit;
    }

    snake[0] = head;
    snake[1] = tail;
    snake[2] = end;
    setup(snake);



    while (input != '0'){
        drawtable();
        input = getChar();
        switch (input)
        {
        case ('w'):
            next = up;
            break;
        case ('s'):
            next = down;
            break;
        case ('d'):
            next = left;
            break;
        case ('a'):
            next = right;
            break;
        default:
            break;
        }
        suc = move(prevp, nextp, snake, &lastnum, &cap);
        updateTable(snake, &lastnum);
        if (!suc){
            printf("Dumb move kid.\n");
        }
    }








    free(snake);
    return 0;
}