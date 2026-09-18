package cards;

import java.util.Objects;

public abstract class Card implements CardInfo, Cloneable, Comparable<Card> {
    private final Suit suit;

    public Card(Suit suit) {
        if (suit == null) {
            throw new IllegalArgumentException("Suit cannot be null.");
        }
        this.suit = suit;
    }

    public Suit getSuit() {
        return suit;
    }

    public String getDisplayText() {
        return toString();
    }

    protected abstract int innerRank();

    protected abstract int categoryRank();

    protected abstract Card clone();

    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (!(obj instanceof Card other))
            return false;
        return suit == other.suit && this.toString().equals(other.toString());
    }

    @Override
    public String toString() {
        return suit.toString();
    }

    @Override
    public int compareTo(Card other) {
        int bySuit = Integer.compare(this.suit.ordinal(), other.suit.ordinal());
        if (bySuit != 0) {
            return bySuit;
        }

        int byCategory = Integer.compare(this.categoryRank(), other.categoryRank());
        if (byCategory != 0) {
            return byCategory;
        }

        return Integer.compare(this.innerRank(), other.innerRank());
    }

    @Override
    public int hashCode() {
        return Objects.hash(suit, toString());
    }
}
