#include <stdio.h>
#include "utils.h"
#include <string.h>
#include <stdlib.h>


int main(){
    FILE *fptr = fopen("ascii_input.txt", "r");
    int i=0;
    int ch;
    int cap = 1;

    char *things = NULL;

    things = malloc(cap*sizeof(char));

    while ((ch = fgetc(fptr)) != EOF)
    {
        if (i+1 >= cap){
            cap *= 2;
            char *temp = realloc(things, cap * sizeof(char));
            
            if (temp == NULL) {
                fprintf(stderr, "Memory allocation error!\n");
                free(things);
                fclose(fptr);
                return 1;
            }
            things=temp;

        }
        things[i]=(char)ch;
        i++;
    }
    things[i]='\0';
    printf("%s",things);





    char buff[100];

    printf("Enter a word!");
    while (fgets(buff,sizeof(buff),stdin) != NULL){
		if (strlen(buff)==1){
			printf("The line has been left blank. Try again.\n");
			printf("Enter a word! ");
			continue;
		}
        buff[strlen(buff)-1] = '\0';
        draw_str(buff,things);
        printf("Enter a word! ");
    }
    free(things);
    fclose(fptr);
    return 0;
}