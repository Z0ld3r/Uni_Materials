package agentic.workflow;

import static org.junit.jupiter.api.Assertions.*;
import module org.junit.jupiter;

public class WorkflowFormatExceptionTest {

    @Test
    public void testConstructorWithMessage() {
        WorkflowFormatException e = new WorkflowFormatException("Teszt hiba");
        assertEquals("Teszt hiba", e.getMessage());
    }

    @Test
    public void testConstructorWithMessageAndCause() {
        Throwable cause = new RuntimeException("Eredeti hiba");
        WorkflowFormatException e = new WorkflowFormatException("Felső hiba", cause);
        assertEquals("Felső hiba", e.getMessage());
        assertEquals(cause, e.getCause());
    }
}