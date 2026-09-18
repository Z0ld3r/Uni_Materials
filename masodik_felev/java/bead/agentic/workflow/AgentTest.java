package agentic.workflow;

import agentic.workflow.llm.SchemaType;
import agentic.workflow.llm.StructuredOutput;
import static org.junit.jupiter.api.Assertions.*;
import module org.junit.jupiter;
import java.io.File;
import java.io.PrintWriter;
import java.io.IOException;

public class AgentTest {

    @Test
    public void testStepCount() {
        Agent agent = new Agent("Test");
        StructuredOutput out = new StructuredOutput(SchemaType.INT);
        agent.addStep(new WorkflowStep("S1", "P", "SP", out));
        agent.addStep(new WorkflowStep("S2", "P", "SP", out));

        assertEquals(2, agent.getStepCount());
    }

    @Test
    public void testAddDuplicateStepRejected() {
        Agent agent = new Agent("Test");
        StructuredOutput out = new StructuredOutput(SchemaType.INT);
        agent.addStep(new WorkflowStep("Step1", "P", "SP", out));

        assertThrows(IllegalArgumentException.class, () -> {
            agent.addStep(new WorkflowStep("Step1", "P", "SP", out));
        });
    }

    @Test
    public void testFindStepByNameSuccess() {
        Agent agent = new Agent("Test");
        StructuredOutput out = new StructuredOutput(SchemaType.INT);
        WorkflowStep step = new WorkflowStep("SearchMe", "P", "SP", out);
        agent.addStep(step);

        assertEquals(step, agent.findStepByName("SearchMe"));
    }

    @Test
    public void findStepByNameMissing() {
        Agent agent = new Agent("Test");
        assertNull(agent.findStepByName("NonExistent"));
    }

    @Test
    public void findStepByName() {
        Agent agent = new Agent("Test");
        assertNull(agent.findStepByName("Anything"));
    }

    @Test
    public void testLoadAgentSuccess() throws IOException, WorkflowFormatException {
        File tempFile = File.createTempFile("valid_agent", ".txt");
        try (PrintWriter out = new PrintWriter(tempFile)) {
            out.println("AGENT: TestAgent");
            out.println("STEP");
            out.println("Step1");
            out.println("Prompt");
            out.println("System");
            out.println("STRING");
            out.println("ENDSTEP");
        }

        Agent agent = Agent.loadAgent(tempFile.getAbsolutePath());
        assertNotNull(agent);
        assertEquals("TestAgent", agent.getName());
        assertEquals(1, agent.getStepCount());
        tempFile.delete();
    }

    @Test
    public void testLoadAgentRejectsMissingHeader() throws IOException {
        File tempFile = File.createTempFile("no_header", ".txt");
        try (PrintWriter out = new PrintWriter(tempFile)) {
            out.println("STEP");
        }

        assertThrows(WorkflowFormatException.class, () -> {
            Agent.loadAgent(tempFile.getAbsolutePath());
        });
        tempFile.delete();
    }

    @Test
    public void testLoadAgentRejectsDuplicateStepNames() throws IOException {
        File tempFile = File.createTempFile("duplicate_steps", ".txt");
        try (PrintWriter out = new PrintWriter(tempFile)) {
            out.println("AGENT: BadAgent");
            out.println("STEP");
            out.println("SameName");
            out.println("P");
            out.println("S");
            out.println("INT");
            out.println("ENDSTEP");
            out.println("STEP");
            out.println("SameName");
            out.println("P");
            out.println("S");
            out.println("INT");
            out.println("ENDSTEP");
        }

        assertThrows(IllegalArgumentException.class, () -> {
            Agent.loadAgent(tempFile.getAbsolutePath());
        });
        tempFile.delete();
    }
}