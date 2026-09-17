public abstract class Szereplo {
    protected String name;
    protected int hp;
    protected int attack;


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getHp() {
        return hp;
    }

    public void setHp(int hp) {
        this.hp = hp;
    }

    public int getAttack() {
        return attack;
    }

    public void setAttack(int attack) {
        this.attack = attack;
    }
    public abstract boolean takeDamage(int num);
    public boolean makeAttack(Szereplo enemy){
        if (enemy.getHp() > 0) {
            return enemy.takeDamage(this.getAttack());
        }
        return false;
    }
}
