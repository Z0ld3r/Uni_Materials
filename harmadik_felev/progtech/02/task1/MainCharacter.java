package task1;

public class MainCharacter extends Character {
    protected double defense;

    public MainCharacter(String name, int healthPoints, int attackPower, double defense) {
        super(name, healthPoints, attackPower);
        this.defense = defense;
    }

    @Override
    public void handleIncomingAttack(int incomingDamage) {
        int dampenedDamage = this.dampenDamage(incomingDamage);
        super.handleIncomingAttack(dampenedDamage);
    }

    private int dampenDamage(int amount) {
        return (int) (amount / this.defense);
    }

    public double getDefense() {
        return defense;
    }
}
