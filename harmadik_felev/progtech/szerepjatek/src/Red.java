public class Red extends Drake{
    @Override
    public boolean takeDamage(int num){
        if (num>60){
            hp -= num;
            return true;
        }
        return false;
    }

    public Red(int hp, int attack, String name){
        this.hp = hp;
        this.attack = attack;
        this.name = name;
    }
}
