package cards;

import java.util.HashMap;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;

public class Deck {
    private final List<Card> cards;
    private final Map<Suit, Integer> suitCounts;

    public Deck() {
        this.cards = new ArrayList<>();
        this.suitCounts = new HashMap<>();
        initializeSuitCounts();
    }

    public Deck(List<Card> cards) {
        this();
        if (cards != null) {
            for (Card card : cards) {
                addCard(card);
            }
        }
    }

    private void initializeSuitCounts() {
        for (Suit suit : Suit.values()) {
            suitCounts.put(suit, 0);
        }
    }

    public boolean isEmpty() {
        return cards.isEmpty();
    }

    public int size() {
        return cards.size();
    }

    public void addCard(Card card) {
        if (card == null)
            throw new IllegalArgumentException("Card cannot be null.");

        Card copy = card.clone();
        cards.add(copy);
        suitCounts.put(copy.getSuit(), suitCounts.get(copy.getSuit()) + 1);
    }

    public Card draw() {
        if (isEmpty())
            throw new IllegalStateException("Can't draw from an empty deck.");
        Card copy = cards.remove(0);
        suitCounts.put(copy.getSuit(), suitCounts.get(copy.getSuit()) - 1);
        return copy;
    }

    public int getSuitCount(Suit suit) {
        if (suit == null) {
            throw new IllegalArgumentException("Suit cannot be null.");
        }
        return suitCounts.get(suit);
    }

    public List<Card> snapshot() {
        List<Card> copy = new ArrayList<>();
        for (Card card : cards) {
            copy.add(card.clone());
        }
        return copy;
    }

    public static Deck makeFrenchDeck() {
        Deck deck = new Deck();
        for (Suit suit : Suit.values()) {
            for (int value = 1; value <= 10; value++) {
                deck.addCard(new Pipcard(suit, value));
            }

            for (Face face : Face.values()) {
                if (face != Face.CAVALIER) {
                    deck.addCard(new FaceCard(suit, face));
                }
            }
        }
        return deck;
    }
}
