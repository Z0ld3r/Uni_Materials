#include <stdio.h>
#include "utils.h"
#include "bus_stops.h"

void printmenu() {
    printf("-- Bus stops --\n");
    printf("0. Exit\n");
    printf("1. Map\n");
    printf("2. List\n");
    printf("3. Add new stop\n");
    printf("4. Delete stop\n");
    printf("5. Save stops\n");
    printf("6. Load stops\n");
    printf("7. Fastest route\n");
}

void menu() {
    char c;
    do{
        printmenu();
        c = getChar();
        switch (c)
        {
            case '1':
                printf("Not implemented yet");
                break;
            case '2':
                printf("Not implemented yet");
                break;
            case '3':
                printf("Not implemented yet");
                break;
            case '4':
                printf("Not implemented yet");
                break;
            case '5':
                printf("Not implemented yet");
                break;
            case '6':
                printf("Not implemented yet");
                break;
            case '7':
                printf("Not implemented yet");
                break;
            case '0':
                printf("Not implemented yet");
                break;
            default:
                printf("There is no such option");
                break;
        }
    } while(c != 0 && c!=EOF);
}

int main() {
    printf("Greetings Traveller!\nThis app helps you to maintain the bus stops in a city.\nYou can list bus stops, add new ones, delete, or look at the map, even plan routes between the stops.\n");
    menu();

    return 0;
}
