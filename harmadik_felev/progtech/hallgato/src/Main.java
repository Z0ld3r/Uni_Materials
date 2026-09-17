import java.util.ArrayList;

public class Main {
    public static void main(String[] args){
        ArrayList<Hallgato> lista = new ArrayList<>();
        Hallgato hallgato1 = new Hallgato("Sanyi", "Magyar", 4.0);
        Hallgato hallgato2 = new Hallgato("Laci", "Magyar", 3.5);
        Hallgato hallgato3 = new Hallgato("Kálmán", "Magyar", 3.0);
        Hallgato hallgato4 = new Hallgato("Péter", "Magyar", 5.0);
        lista.add(hallgato1);
        lista.add(hallgato2);
        lista.add(hallgato3);
        lista.add(hallgato4);

        double max = 0;
        double min = 5;
        Hallgato maxh = null;
        Hallgato minh = null;
        for (int i = 0; i<lista.toArray().length; i++){
            if (lista.get(i).getAverage() > max){
                maxh = lista.get(i);
                max = lista.get(i).getAverage();
            }
            if (lista.get(i).getAverage() < min){
                minh = lista.get(i);
                min = lista.get(i).getAverage();
            }
        }
        System.out.println(maxh.getName());
        System.out.println(minh.getName());

        ArrayList<String> osztondij = new ArrayList<>();
        for (int i = 0; i<lista.toArray().length; i++) {
            if (lista.get(i).getAverage() >= 4.0) {
                osztondij.add(lista.get(i).getName());
            }
        }
        System.out.println(osztondij);
    }
}
