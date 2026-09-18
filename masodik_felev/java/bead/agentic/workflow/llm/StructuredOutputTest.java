package agentic.workflow.llm;

import static org.junit.jupiter.api.Assertions.*;
import module org.junit.jupiter;

public class StructuredOutputTest {
    @Test
    public void testContains() {
        StructuredOutput output = new StructuredOutput(SchemaType.INT, SchemaType.STRING);

        assertTrue(output.contains(SchemaType.INT));
        assertTrue(output.contains(SchemaType.STRING));
        assertFalse(output.contains(SchemaType.BOOLEAN));
    }

    @Test
    public void testSize() {
        StructuredOutput output = new StructuredOutput(SchemaType.INT, SchemaType.BOOLEAN, SchemaType.STRING);
        assertEquals(3, output.size());
    }

    @Test
    public void testContainsExistingType() {
        StructuredOutput output = new StructuredOutput(SchemaType.INT, SchemaType.STRING);
        assertTrue(output.contains(SchemaType.INT));
    }

    @Test
    public void testContainsMissingType() {
        StructuredOutput output = new StructuredOutput(SchemaType.INT);
        assertFalse(output.contains(SchemaType.BOOLEAN));
    }
}
