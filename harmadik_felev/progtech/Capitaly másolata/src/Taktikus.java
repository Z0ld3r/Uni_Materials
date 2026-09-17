public class Taktikus extends Jatekos{

    private int counter;

    public Taktikus(String name, int toke){
        super(name, toke);
        this.counter = 0;
    }

    public int getCounter() {
        return counter;
    }

    public void setCounter(int counter) {
        this.counter = counter;
    }

    public void incCounter() {
        this.counter += 1;
    }
}