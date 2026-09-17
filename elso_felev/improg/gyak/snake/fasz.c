#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <time.h>
// Windows alatt a conio.h hasznos a villogásmentes törléshez (system("cls")), 
// de most maradunk a te megoldásodnál a hordozhatóság miatt.

#define WIDTH 10
#define LENGTH 10

typedef enum DIRECTION {up, down, left, right} direction;

char table[WIDTH][LENGTH];

char getChar() {
    char c;
    // Kis segítség: a scanf néha jobb enter kezelésre, de ez is működhet
    do {
        c = getchar();
    } while (c == '\n');
    return c;
}

bool issnake(int num) {
    // Biztonsági ellenőrzés: ne indexeljünk túl
    if (num < 0 || num >= WIDTH * LENGTH) return false;
    if (table[num / 10][num % 10] == 'x') {
        return true;
    } else {
        return false;
    }
}

int newapple() {
    int ap = rand() % 100;
    if (issnake(ap)) {
        ap = newapple();
    }
    return ap;
}

void setup(int *snake) {
    for (int i = 0; i < WIDTH; i++) {
        for (int j = 0; j < LENGTH; j++) {
            table[i][j] = '.';
        }
    }
    // Ellenőrzés, hogy a kígyó részei a pályán vannak-e
    for(int i=0; i<3; i++) {
        if(snake[i] >= 0 && snake[i] < 100)
            table[snake[i] / 10][snake[i] % 10] = 'x';
    }

    int apple;
    apple = newapple();
    table[apple / 10][apple % 10] = 'o';
}

void drawtable() {
    // Képernyő törlése (opcionális, de szebb)
    // system("cls"); // Windows
    // system("clear"); // Linux/Mac
    
    printf("\n");
    for (int i = 0; i < WIDTH; i++) {
        for (int j = 0; j < LENGTH; j++) {
            printf("%c ", table[i][j]); // Tettem egy szóközt, hogy négyzetesebb legyen
        }
        printf("\n");
    }
}

bool isapple(int num) {
    if (num < 0 || num >= 100) return false;
    if (table[num / 10][num % 10] == 'o') {
        return true;
    } else {
        return false;
    }
}

void extendcheck(int *lastnum, int *cap, int **snakep) {
    int *temp;
    // Ha a kígyó hossza eléri a kapacitást
    if (*cap <= *lastnum + 1) { // +1 biztonsági tartalék
        *cap *= 2;
        temp = realloc(*snakep, sizeof(int) * (*cap));
        if (temp == NULL) {
            printf("Allocation failed.");
            exit(1);
        } else {
            *snakep = temp; // Itt frissítjük a mutatót
        }
    }
}

// Segédfüggvény a következő pozíció kiszámolására
int get_next_pos(int current_pos, direction dir) {
    switch (dir) {
        case up:    return current_pos - 10;
        case down:  return current_pos + 10;
        case left:  return current_pos - 1;
        case right: return current_pos + 1;
        default:    return current_pos;
    }
}

void minimoveap(int **snakep, direction *next, int *lastnum, int *cap) {
    (*lastnum)++; // Növeljük a hosszt
    extendcheck(lastnum, cap, snakep);
    
    int *s = *snakep;
    // A test mozgatása hátulról előre, hogy legyen hely a fejnek
    // JAVÍTÁS: i > 0, hogy az 1. elemet is átírjuk a 0.-ra
    for (int i = *lastnum - 1; i > 0; i--) {
        s[i] = s[i - 1];
    }

    // Új fej pozíció
    s[0] = get_next_pos(s[1], *next); // s[1] a régi fej
}

void minimovedef(int *snake, direction *next, int *lastnum) {
    // 1. lépés: Mentsük el, hova lépne a fej
    int new_head = get_next_pos(snake[0], *next);

    // 2. lépés: Töröljük a farok végét a tábláról (a logikában), 
    // bár az updateTable megteszi, itt a tömböt toljuk.
    
    // JAVÍTÁS: A ciklust kihoztuk a switchből és javítottuk a feltételt i > 0-ra
    for (int i = *lastnum - 1; i > 0; i--) {
        snake[i] = snake[i - 1];
    }
    
    // 3. lépés: Az új fej beállítása
    snake[0] = new_head;
}

// JAVÍTÁS: int **snake lett az argumentum, hogy a realloc működjön
bool move(direction *prev, direction *next, int **snake, int *lastnum, int *cap) {
    bool suc = true;
    int *s = *snake; // Segédváltozó a könnyebb íráshoz

    // JAVÍTÁS: &*next helyett *next
    if ((*prev == down && *next == up) || (*prev == up && *next == down) || 
        (*prev == left && *next == right) || (*prev == right && *next == left)) {
        // Ha tiltott irány, az irány marad a régi
        *next = *prev;
    }

    int next_pos = get_next_pos(s[0], *next);

    // Falnak ütközés ellenőrzése (egyszerűsített: ha kilép a 0-99 tartományból)
    // Itt lehetne finomítani (pl. jobb szélről ne ugorjon át a bal szélre), de alapnak jó.
    if (next_pos < 0 || next_pos >= 100) {
        return false; 
    }
    // Önmagába harapás
    // Fontos: a farkát (lastnum-1) nem számítjuk, mert az el fog mozdulni
    for(int i=0; i<*lastnum-1; i++) { 
         if(s[i] == next_pos) return false;
    }

    if (isapple(next_pos)) {
        minimoveap(snake, next, lastnum, cap);
        int ap = newapple();
        table[ap / 10][ap % 10] = 'o';
    } else {
        minimovedef(*snake, next, lastnum);
    }
    
    *prev = *next;
    return suc;
}

void updateTable(int *snake, int lastnum) {
    // Először törlünk mindent, ami nem alma
    for (int i = 0; i < WIDTH; i++) {
        for (int j = 0; j < LENGTH; j++) {
            if (table[i][j] != 'o') {
                table[i][j] = '.';
            }
        }
    }
    // Kirajzoljuk a kígyót
    for (int i = 0; i < lastnum; i++) {
        // Biztonsági ellenőrzés
        if (snake[i] >= 0 && snake[i] < 100)
            table[snake[i] / 10][snake[i] % 10] = 'x';
    }
}

int main() {
    int head = 44;
    int tail = 54; // Alatta
    int end = 64;  // Még lejjebb
    
    char input = ' ';
    direction prev = up;
    direction next = up; // Kezdő irány legyen up
    direction *nextp = &next;
    direction *prevp = &prev;
    
    bool suc = true;
    int lastnum = 3;
    int cap = 4;
    
    srand(time(NULL));
    
    int *snake = malloc(sizeof(int) * cap); // Cap méretűt foglaljunk
    if (snake == NULL) {
        printf("Memory allocation failed.");
        return 1;
    }

    snake[0] = head;
    snake[1] = tail;
    snake[2] = end;
    
    setup(snake);

    printf("Iranyitas: w, a, s, d + Enter. Kilepes: 0\n");

    while (input != '0' && suc) {
        drawtable();
        input = getChar(); // Itt vár a program az Enterre
        
        switch (input) {
            case 'w': next = up; break;
            case 's': next = down; break;
            case 'd': next = right; break; // WASD javítva
            case 'a': next = left; break;
            case '0': exit(0); break;
            default: break; // Ha mást nyomsz, megy tovább az előző irányba
        }
        
        // JAVÍTÁS: &snake-t adunk át (a mutató címét)
        suc = move(prevp, nextp, &snake, &lastnum, &cap);
        updateTable(snake, lastnum);
        
        if (!suc) {
            printf("\nGAME OVER! A kigyod falnak ment vagy magaba harapott.\n");
        }
    }

    free(snake);
    return 0;
}