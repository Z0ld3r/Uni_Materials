package task1;

public class Berserker extends Orc {
    public Berserker(String name, int healthPoints, int attackPower) {
        super(name, healthPoints, attackPower);
    }

    @Override
    public void handleIncomingAttack(int incomingDamage) {
        super.handleIncomingAttack(incomingDamage * 2);
    }
}
