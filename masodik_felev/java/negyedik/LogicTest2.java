import static org.junit.jupiter.api.Assertons.assertEquals;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

public class LogicTest2 {

    @ParameterizedTest
    @CsvSource({
            "true, true",
            "true, false",
            "false, true",
            "false, false"
    })

    void implTest(boolean a, boolean b, boolean expected) {
        assertEquals(expected, Logic.impl(a, b));
    }
}
