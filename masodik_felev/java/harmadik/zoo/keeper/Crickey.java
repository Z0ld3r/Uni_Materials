package zoo.keeper;

import zoo.animal.Panda;

public class Crickey {
    public static void main(String[] args) {
        Panda jani = new Panda("John", "Korea");
        Panda kalman = new Panda("Kálmán", "Australia", 35);
        jani.happyBirthday(52);
        kalman.happyBirthday(36);
    }
}
