package hu.suli.test;

import hu.suli.text.TextStats;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.*;
public class TextStatsTest {

    private TextStats stats;
    private String sample;

    @BeforeEach
    void setUp() {
        sample = """
                Java is fun.
                Unit testing is useful.
                Java and JUnit work well together.
                """;

        stats = new TextStats(sample);
    }

    @Test
    void testCharacterCount() {
        assertEquals(sample.length(), stats.getCharacterCount());
    }

    @Test
    void testLineCount() {
        assertEquals(3, stats.getLineCount());
    }

    @Test
    void testContainsWord() {
        assertTrue(stats.containsWord("Java"));
        assertTrue(stats.containsWord("JUnit"));
        assertFalse(stats.containsWord("Python"));
    }

    @ParameterizedTest
    @CsvSource({
            "Java, true",
            "JUnit, true",
            "useful, true",
            "python, false",
            "school, false"
    })
    void testContainsWordParameterized(String word, boolean expected) {
        assertEquals(expected, stats.containsWord(word));
    }

    @Test
    void testToUpperCaseAndOtherValues() {
        assertAll(
                () -> assertEquals(3, stats.getLineCount()),
                () -> assertTrue(stats.containsWord("Java")),
                () -> assertEquals(sample.toUpperCase(), stats.toUpperCaseText())
        );
    }
}
