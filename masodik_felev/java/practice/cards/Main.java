package cards;

public class Main {
    public static void main(String[] args) {
        Deck deck = Deck.makeFrenchDeck();
        while (!deck.isEmpty()) {
            System.out.println(deck.draw());
        }
    }
}
