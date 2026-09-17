public class Berserk extends Orc{
    @Override
    public boolean takeDamage(int num){
        hp -= num*2;
        return true;
    }
    public Berserk(int hp, int attack, String name){
        this.hp = hp;
        this.attack = attack;
        this.name = name;
    }
}
