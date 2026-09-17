#include <stdio.h>
#include "utils.h"


int main()
{
    printf("Hello User!\nThis program is going to help you organize between the walls of MindentRendez Kft.\nHappy sorting!\n");
    char c;
    printf("Choose an option from the following:\n1. Add\n2. Draw\n3. List\n4. Delete\n 5. Exit\n");
    c = getChar();
    
    while (c != '5')
    {
        if (c=='1') {
            insert_pkg();
        }
        else if (c=='2')
        {
            print_tree();
        }
        else if( c=='3'){
            get_manifest();
        }
        else if (c=='4'){
            delete_pkg();
        }
        else if (c=='5'){
            printf("Exiting...");
        }
        else{
            printf("Invalid option, choose again!\n");
        }
        c = getChar();
    }    
    return 0;
}
