

public abstract class Jatekos {
    private String name;
    private int toke;
    private boolean aktiv;
    private int position;

    public Jatekos(String name, int toke){
        this.name = name;
        this.toke = toke;
        this.position = 0;
        this.setAktiv(true);
    }

    public Jatekos(){}

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getToke() {
        return toke;
    }

    public boolean isAktiv() {
        return aktiv;
    }

    public void setAktiv(boolean aktiv) {
        this.aktiv = aktiv;
    }

    public void setToke(int toke) {
        this.toke = toke;
    }

    public int getPosition() {
        return position;
    }

    public void setPosition(int position) {
        this.position = position;
    }

    public boolean isInDebt(){
        if (this.getToke()<0) {return true;}
        else {return false;}
    }

    public void payTo(Jatekos player, int num){
        this.setToke(this.getToke()-num);
        player.setToke(player.getToke()+num);
    }
}

