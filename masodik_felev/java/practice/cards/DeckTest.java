package cards;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertNotSame;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.fail;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.EnumSource;

public class DeckTest {

    private Deck deck;

    @BeforeEach
    void setUp() {
        deck = Deck.makeFrenchDeck();
    }

    @Test
    void frenchDeckHasCorrectSize() {
        assertEquals(52, deck.size());
        assertFalse(deck.isEmpty());
    }

    @ParameterizedTest
    @EnumSource(Suit.class)
    void eachSuitAppearsThirteenTimes(Suit suit) {
        assertEquals(13, deck.getSuitCount(suit));
    }

    @Test
    void drawReturnsFirstCardAndShrinksDeck() {
        Card first = deck.draw();
        assertEquals("ACE of CLUBS", first.toString());
        assertEquals(51, deck.size());
        assertEquals(12, deck.getSuitCount(Suit.CLUBS));
    }

    @Test
    void snapshotReturnsClonedCards() {
        Card originalFirst = deck.snapshot().get(0);
        Card anotherFirst = deck.snapshot().get(0);

        assertEquals(originalFirst, anotherFirst);
        assertNotSame(originalFirst, anotherFirst);
    }

    @Test
    void drawingFromEmptyDeckFails() {
        Deck empty = new Deck();
        try {
            empty.draw();
            fail("IllegalStateException was expected.");
        } catch (IllegalStateException e) {
            assertEquals("Cannot draw from an empty deck.", e.getMessage());
        }
    }
}