package cards;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.Test;

public class PipCardTest {

    @Test
    void aceToStringIsCorrect() {
        Pipcard ace = new Pipcard(Suit.SPADES, 1);
        assertEquals("ACE of SPADES", ace.toString());
    }

    @Test
    void numberedPipCardToStringIsCorrect() {
        Pipcard seven = new Pipcard(Suit.CLUBS, 7);
        assertEquals("CLUBS(7)", seven.toString());
    }

    @Test
    void invalidValueThrows() {
        assertThrows(IllegalArgumentException.class, () -> new Pipcard(Suit.HEARTS, 11));
    }
}