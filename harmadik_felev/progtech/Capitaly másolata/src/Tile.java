public class Tile {
    private final int num;
    private TState state;
    private Jatekos owner;
    public Tile(int num){
        this.num = num;
        this.state = TState.UNOWNED;
        this.owner = null;
    }

    public int getNum() {
        return num;
    }

    public TState getState() {
        return state;
    }

    public Jatekos getOwner() {
        return owner;
    }

    public void setOwner(Jatekos owner) {
        this.owner = owner;
    }

    public void setState(TState state) {
        this.state = state;
    }

    public boolean tryBuy(Jatekos player){
        if(this.getOwner() == null && player.getToke() >= 1000){
            boolean success = ((Property) this).buyProperty(player);
            return success;
        }
        else if(this.getOwner() == player && player.getToke() >= 4000){
            boolean success = ((Property) this).upgradeProperty(player);
            return success;
        }
        else{
            return false;
        }
    }
}

