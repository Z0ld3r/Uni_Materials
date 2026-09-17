public class Property extends Tile{
    private Jatekos owner;
    private TState state;

    public Property(int num){
        super(num);
        this.owner = null;
        this.state = TState.UNOWNED;
    }


    public Jatekos getOwner() {
        return owner;
    }

    public void setOwner(Jatekos owner) {
        this.owner = owner;
    }

    public TState getState() {
        return state;
    }

    public void setState(TState state) {
        this.state = state;
    }

    public boolean buyProperty(Jatekos j){
        if (getState() == TState.UNOWNED) {
            this.owner = j;
            setState(TState.OWNED);
            j.setToke(j.getToke()-1000);
            return true;
        }
        return false;
    }

    public boolean upgradeProperty(Jatekos j){
        if (getState() == TState.OWNED && getOwner() == j) {
            setState(TState.HOUSED);
            j.setToke(j.getToke()-4000);
            return true;
        }
        return false;
    }

}
