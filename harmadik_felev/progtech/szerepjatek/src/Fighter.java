public class Fighter extends Orc{
    @Override
    public boolean takeDamage(int num){
        hp -= num;
        return true;
    }

    public Fighter(int hp, int attack, String name){
        this.hp = hp;
        this.attack = attack;
        this.name = name;
    }
}
