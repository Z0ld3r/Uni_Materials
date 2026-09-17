package task1;

public abstract class Dragon extends Character {
    protected final int MINIMUM_INCOMING_DAMAGE;

    protected Dragon(String name, int healthPoints, int attackPower, int MINIMUM_INCOMING_DAMAGE) {
        super(name, healthPoints, attackPower);
        this.MINIMUM_INCOMING_DAMAGE = MINIMUM_INCOMING_DAMAGE;
    }

    @Override
    public void handleIncomingAttack(int incomingDamage) {
        if (incomingDamage < this.MINIMUM_INCOMING_DAMAGE) return;
        else this.takeDamage(incomingDamage);
    }
}
