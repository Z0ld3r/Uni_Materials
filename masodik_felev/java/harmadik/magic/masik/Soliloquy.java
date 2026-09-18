package masodik_felev.prognyelvek(java).harmadik.magic.masik;

import magic.library.Incantation;

public class Soliloquy {
    public static void Main(String[] args) {

    }

    public void reciteIncantations(Incantation inc1, Incantation inc2, int idx, boolean startWithAppend) {
        boolean vissza;
        System.out.println(inc1.enchant(inc2, !(startWithAppend)), getIndex(inc1), getText(inc1), getIndex(inc2),
                getText(inc2));
        System.out.println(inc1.enchant(inc2, startWithAppend), getIndex(inc1), getText(inc1), getIndex(inc2),
                getText(inc2));
        System.out.println(inc1.enchant(inc2, true), getIndex(inc1), getText(inc1), getIndex(inc2), getText(inc2));
    }
}
