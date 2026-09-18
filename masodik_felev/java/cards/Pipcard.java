package cards;

public final class Pipcard extends Card {
    private final int value;

    public Pipcard(Suit suit, int value) {
        super(suit);
        if (value < 1 || value > 10) {
            throw new IllegalArgumentException("The number has to be between 1 and 10.");
        }
        this.value = value;
    }

    public int getValue() {
        return value;
    }

    @Override
    protected int categoryRank() {
        return 0;
    }

    @Override
    protected int innerRank() {
        return value;
    }

    @Override
    public String toString() {
        if (value == 1) {
            return "ACE of " + getSuit();
        }
        return getSuit() + "(" + value + ")";
    }

    @Override
    public Pipcard clone() {
        return new Pipcard(getSuit(), value);
    }
}
