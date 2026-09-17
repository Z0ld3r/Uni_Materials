public class Black extends Drake{
    @Override
    public boolean takeDamage(int num){
        if (num>20){
            hp -= num;
            return true;
        }
        return false;
    }

    public Black(int hp, int attack, String name){
        this.hp = hp;
        this.attack = attack;
        this.name = name;
    }
}
