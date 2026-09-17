public class LuckyTile extends Tile {
    private final int inc;

    public LuckyTile(int num, int inc){
        super(num);
        this.inc = inc;
    }

    public int getInc() {
        return inc;
    }

    public void activate(Jatekos j){
        j.setToke(j.getToke()+inc);
    }
}
