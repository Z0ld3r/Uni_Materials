package task1;

public abstract class Character implements Attackable {
    protected String name;
    protected int healthPoints;
    protected int attackPower;

    protected Character(String name, int healthPoints, int attackPower) {
        this.name = name;
        this.healthPoints = healthPoints;
        this.attackPower = attackPower;
    }

    public void attack(Character target) {
        this.handleIncomingAttack(this.attackPower);
    }

    @Override
    public void handleIncomingAttack(int incomingDamage) {
        this.takeDamage(incomingDamage);
    }

    protected void takeDamage(int amount) {
        int remainingHealth = Math.max(0, this.healthPoints - amount);
        this.healthPoints = remainingHealth;
    }

    public boolean isAlive() {
        return healthPoints > 0;
    }

    public String getName() {
        return name;
    }
}