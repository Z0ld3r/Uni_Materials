import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.io.File;

public class Main {
    public static void main(String[] args) {
        File file = new File("input.txt");
        boolean predetermined = false;
        ArrayList<Jatekos> jatekosok = new ArrayList<>();
        ArrayList<Tile> tiles = new ArrayList<>();
        ArrayList<Jatekos> kiesettek = new ArrayList<>();
        int roundcounter = 0;
        try (Scanner myReader = new Scanner(file)) {
            String data = myReader.nextLine();
            if (data.equals("predetermined")){predetermined = true;}
            else{predetermined=false;}

            if (predetermined){
                data = myReader.nextLine();
                String[] numbers = data.split(" ");

                for (int i=0; i<Integer.parseInt(numbers[0]); i++){
                    data = myReader.nextLine();
                    String[] player = data.split(" ");
                    if (player[2].equals("moho")) {
                        Moho playertemp = new Moho(player[0],Integer.parseInt(player[1]) );
                        jatekosok.add(playertemp);
                    }
                    if (player[2].equals("ovatos")) {
                        Ovatos playertemp = new Ovatos(player[0],Integer.parseInt(player[1]) );
                        jatekosok.add(playertemp);
                    }
                    if (player[2].equals("taktikus")) {
                        Taktikus playertemp = new Taktikus(player[0],Integer.parseInt(player[1]) );
                        jatekosok.add(playertemp);
                    }

                }
                int tcounter = 0;
                for (int i=0; i<Integer.parseInt(numbers[1]); i++){
                    data = myReader.nextLine();
                    String[] tile = data.split(" ");

                    if (tile[0].equals("property")){
                        Property ptemp = new Property(tcounter);
                        tcounter++;
                        tiles.add(ptemp);
                    }
                    else if (tile[0].equals("luckytile")){
                        LuckyTile ltemp = new LuckyTile(tcounter,Integer.parseInt(tile[1]));
                        tcounter++;
                        tiles.add(ltemp);
                    }
                    else if (tile[0].equals("unluckytile")){
                        UnluckyTile utemp = new UnluckyTile(tcounter,Integer.parseInt(tile[1]));
                        tcounter++;
                        tiles.add(utemp);
                    }
                }

                Table table = new Table(jatekosok,tiles);

                for (int i = 0; i<Integer.parseInt(numbers[2]); i++){
                    data = myReader.nextLine();
                    String[] mover = data.split(" ");
                    for (int j = 0; j< jatekosok.toArray().length; j++){
                        int move = Integer.parseInt(mover[j]);
                        table.move(table.jatekosok.get(j),move);

                        if(table.jatekosok.get(j).isInDebt()){
                            table.destroy(jatekosok.get(j));
                        }
                    }

                    if(table.kiesettek.size() >= 2){
                        System.out.println("Player that's gone out second: " + table.kiesettek.get(1).getName()+", in "+roundcounter+" rounds.");
                        System.exit(0);
                    }
                    roundcounter++;
                }





            }
        } catch (FileNotFoundException e) {
            System.out.println("File error.");
            e.printStackTrace();
        }
        System.out.println("No player going out second could be found.");
    }
}
