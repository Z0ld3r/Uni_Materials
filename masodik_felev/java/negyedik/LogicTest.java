import static org.junit.jupiter.api.Assertions.assertTrue;
import org.junit.jupiter.api.Test;

public class LogicTest {

    @Test
    void orTest() {
        assertTrue(Logic.or(true, false));
    }
}
