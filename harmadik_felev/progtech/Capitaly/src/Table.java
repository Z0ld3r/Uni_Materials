import java.util.ArrayList;

public class Table {
    public ArrayList<Jatekos> jatekosok;
    public ArrayList<Tile> tiles;

    public ArrayList<Jatekos> kiesettek = new ArrayList<>();
    int roundcounter;

    public Table(ArrayList<Jatekos> jlist, ArrayList<Tile> tlist){
        this.jatekosok = jlist;
        this.tiles = tlist;
        int roundcounter = 0;
    }

    public ArrayList<Jatekos> getJatekosok() {
        return jatekosok;
    }

    public void setJatekosok(ArrayList<Jatekos> jatekosok) {
        this.jatekosok = jatekosok;
    }

    public ArrayList<Tile> getTiles() {
        return tiles;
    }

    public void setTiles(ArrayList<Tile> tiles) {
        this.tiles = tiles;
    }

    public ArrayList<Jatekos> getKiesettek() {
        return kiesettek;
    }

    public void setKiesettek(ArrayList<Jatekos> kiesettek) {
        this.kiesettek = kiesettek;
    }

    public int getRoundcounter() {
        return roundcounter;
    }

    public void setRoundcounter(int roundcounter) {
        this.roundcounter = roundcounter;
    }

    public void destroy(Jatekos player){
        player.setAktiv(false);
        player.setToke(0);
        kiesettek.add(player);

        for (int i=0;i<tiles.size();i++){
            if (tiles.get(i).getOwner() == player){
                tiles.get(i).setOwner(null);
            }
        }
    }

    public void move(Jatekos player, int number){
        if (!player.isAktiv()){ return;}
        this.modPosition(player, number);
        Tile landedOn = tiles.get(player.getPosition());
        if(landedOn instanceof LuckyTile ){
            ((LuckyTile) landedOn).activate(player);
        }
        else if(landedOn instanceof UnluckyTile ){
            ((UnluckyTile) landedOn).activate(player);
        }
        else{
            if (landedOn.getOwner() == null || landedOn.getOwner() == player){
                if(player instanceof Moho){
                    landedOn.tryBuy(player);
                }
                else if(player instanceof Ovatos && ((landedOn.getState() == TState.UNOWNED && player.getToke() >= 2000) || (landedOn.getState() == TState.OWNED && player.getToke() >= 8000))){
                    landedOn.tryBuy(player);
                }
                else{
                    if(((Taktikus) player).getCounter() == 0){
                        boolean bought = landedOn.tryBuy(player);
                        ((Taktikus) player).setCounter(-1);
                    }
                    else {
                        ((Taktikus) player).incCounter();
                    }

                }
            }
            else{
                if(landedOn.getState() == TState.OWNED){
                    player.payTo(landedOn.getOwner(),500);
                }
                else if(landedOn.getState() == TState.HOUSED){
                    player.payTo(landedOn.getOwner(),2000);
                }

            }



        }
    }

    public void modPosition(Jatekos player,int movenum) {
        player.setPosition((player.getPosition()+ movenum)%tiles.size());
    }
}
