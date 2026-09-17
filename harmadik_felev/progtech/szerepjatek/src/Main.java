import java.util.List;
import java.util.*;

public class Main{
    public static void main(String[] args){
        Orc o1 = new Fighter(20, 10, "Laci");
        Orc o2 = new Fighter(20, 10, "Sanyi");
        Orc o3 = new Shield(40,5,"Kata");
        Orc o4 = new Berserk(30, 20, "Paula");
        ArrayList<Szereplo> szereplok = new ArrayList<>();

        szereplok.add(o1);
        szereplok.add(o2);
        szereplok.add(o3);
        szereplok.add(o4);

        Prot prot = new Prot("Gusztáv",100, 100, 2);
        szereplok.add(prot);
        Drake d1 = new Red(100,50,"Vörös");
        Drake d2 = new Red(100,50,"Fekete");
        szereplok.add(d1);
        szereplok.add(d2);
    }
}