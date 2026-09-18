package agentic.workflow;

import agentic.workflow.llm.SchemaType;
import agentic.workflow.llm.StructuredOutput;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class WorkflowStepTest {

    @Test
    public void testExpectsStructuredOutput() {
        StructuredOutput kimenet = new StructuredOutput(SchemaType.STRING);
        WorkflowStep lepes = new WorkflowStep("TesztLépes", "Teszt prompt", "Teszt rendszer prompt", kimenet);
        assertTrue(lepes.expectsStructuredOutput());
    }
}