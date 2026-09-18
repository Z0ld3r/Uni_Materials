
import java.util.*;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;

enum Weapon {
    FEJSZE,
    KETELUFEJSZE,
    KALAPACS,
    POROLY,
    TAGLO
}

enum Color {
    RESET("\033[0m"),
    BLACK("\033[0;30m"), // BLACK
    RED("\033[0;31m"), // RED
    GREEN("\033[0;32m"), // GREEN
    YELLOW("\033[0;33m"), // YELLOW
    BLUE("\033[0;34m"), // BLUE
    MAGENTA("\033[0;35m"), // MAGENTA
    CYAN("\033[0;36m"), // CYAN
    WHITE("\033[0;37m");

    private final String code;

    Color(String code) {
        this.code = code;
    }

    @Override
    public String toString() {
        return code;
    }
}

class Unknown {
    private static int ID = 1;
    public int id;
    public int vitality;

    public Unknown() {
        this.id = Unknown.ID++;
        this.vitality = 100;
    }

}

class Orc extends Unknown {

    public String name;
    public int vitality;
    public int damage;
    public int shield;
    public Weapon weapon;

    public Orc(String name, int vitality, Weapon weapon, int shield, int damage) {
        super();
        this.name = name;
        this.vitality = vitality;
        this.damage = damage;
        this.shield = shield;
        this.weapon = weapon;
    }

    public boolean Died() {
        return vitality == 0;
    }

    public void Damaged(int sebez) {
        if (this.vitality - damage + this.shield > 0)
            this.vitality -= (damage + this.shield);
        else
            this.vitality = 0;
    }

    public void Attack(Orc enemy) throws Exception {
        {
            if (enemy.Died())
                throw new Exception("Everything has a limit ...");
            else
                enemy.Damaged(this.damage);
        }
    }

    public String ToString() {
        return String.format(
                "ID: " + this.id +
                        "\nname: " + this.name +
                        "\nvitality: " + this.vitality +
                        "\nweapon: " + this.weapon +
                        "\ndamage: " + this.damage +
                        "\nshield: " + this.shield +
                        "\ndied: " + this.Died())
                + "\n";

    }
}

class Horde {
    String name;

    public Horde(String name) {
        this.orcs = new ArrayList<Orc>();
        this.name = name;
    }

    public ArrayList<Orc> orcs;

    public void AddOrk(String name, int vitality, Weapon weapon, int shield, int damage) {
        this.orcs.add(new Orc(name, vitality, weapon, shield, damage));
    }

    public ArrayList<Orc> DiedOrcs() throws Exception {

        if (orcs.isEmpty())
            throw new Exception("The horde is empty...");

        ArrayList<Orc> temp = new ArrayList<Orc>();
        for (Orc orc : orcs) {
            if (orc.Died())
                temp.add(orc);
        }

        return temp;
    }

    public Orc StrongestOrc() {
        Orc max = orcs.get(0);
        for (Orc orc : orcs) {
            if (orc.damage > max.damage) {
                max = orc;
            }
        }
        return max;
    }

    public ArrayList<Orc> WeakOrcs(int num) throws Exception {

        if (orcs.isEmpty())
            throw new Exception("The horde is empty...");
        ArrayList<Orc> temp = new ArrayList<Orc>();
        for (Orc orc : orcs) {
            if (!orc.Died() && orc.vitality < num)
                temp.add(orc);
        }
        return temp;
    }

    public ArrayList<Orc> OrcsWithGivenWeapon(Weapon weapon) throws Exception {

        if (orcs.isEmpty())
            throw new Exception("The horde is empty...");
        ArrayList<Orc> temp = new ArrayList<Orc>();
        for (Orc orc : orcs) {
            if (!orc.Died() && orc.weapon == weapon)
                temp.add(orc);
        }
        return temp;
    }

    public class App {

        static void ReadFile(String Fajlname, Horde Horde) {
            try {
                BufferedReader br = new BufferedReader(new FileReader(Fajlname));
                br.readLine();
                String line;
                while ((line = br.readLine()) != null) {
                    String[] adatok = line.split(";");
                    Horde.AddOrk(adatok[0], Integer.parseInt(adatok[1]), Enum.valueOf(Weapon.class, adatok[2]),
                            Integer.parseInt(adatok[3]), Integer.parseInt(adatok[4]));
                }

                br.close();
            } catch (IOException e) {
                System.out.println("IO error");
            }
        }

        public static void main(String[] args) throws Exception {
            Horde horde = new Horde("Slaughter");
            ReadFile("OrcFile.csv", horde);

            System.out.println(horde.name);

            for (Orc orc : horde.orcs)
                System.out.println(orc.ToString());

            System.out.println(Color.RED);
            System.out.println("The names of the dead orcs\n");

            for (Orc orc : horde.DiedOrcs())
                System.out.println(orc.name);

            System.out.println(Color.RESET);
        }
    }
}