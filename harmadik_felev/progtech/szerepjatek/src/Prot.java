public class Prot extends Szereplo{

    private int defense;
    public Prot(String name, int hp, int attack, int defense){
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
    }


    @Override
    public boolean takeDamage(int num){
        hp -= num/getDefense();
        return true;
    }

    public int getDefense() {
        return defense;
    }

    public void setDefense(int defense) {
        this.defense = defense;
    }
}
