package agentic.workflow;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Agent {
    private String name;
    private final List<WorkflowStep> steps;

    public Agent(String name) {
        if (name == null || name.isBlank()) {
            throw new IllegalArgumentException("Az ágens neve nem lehet üres!");
        }
        this.name = name;
        this.steps = new ArrayList<>();
    }

    public static Agent loadAgent(String filename) throws IOException, WorkflowFormatException {
        try (BufferedReader reader = new BufferedReader(new java.io.FileReader(filename))) {
            String line;
            Agent agent = null;

            while ((line = reader.readLine()) != null) {
                line = line.trim();
                if (line.isEmpty())
                    continue;

                if (line.startsWith("AGENT:")) {
                    String agentName = line.substring(6).trim();
                    agent = new Agent(agentName);
                } else if (line.equals("STEP")) {
                    if (agent == null)
                        throw new WorkflowFormatException("Hiányzó AGENT fejléc!");
                    agent.addStep(parseStep(reader));
                }
            }

            if (agent == null)
                throw new WorkflowFormatException("A fájl nem tartalmaz érvényes ágenst!");
            return agent;
        }
    }

    private static WorkflowStep parseStep(BufferedReader reader) throws IOException, WorkflowFormatException {
        try {
            String name = reader.readLine().trim();
            String prompt = reader.readLine().trim();
            String sysPrompt = reader.readLine().trim();
            String typeStr = reader.readLine().trim();
            agentic.workflow.llm.SchemaType type = agentic.workflow.llm.SchemaType.valueOf(typeStr);
            agentic.workflow.llm.StructuredOutput output = new agentic.workflow.llm.StructuredOutput(type);

            String end = reader.readLine().trim();
            if (!end.equals("ENDSTEP"))
                throw new WorkflowFormatException("Hiányzó ENDSTEP!");

            return new WorkflowStep(name, prompt, sysPrompt, output);
        } catch (Exception e) {
            throw new WorkflowFormatException("Hiba a lépés feldolgozása közben!", e);
        }
    }

    public void run() {
        System.out.println("--- Ágens futtatása: " + name + " ---");
        for (WorkflowStep step : steps) {
            System.out.println("[" + step.getName() + "] szimulált válasza: " + step.simulateResponse());
        }
    }

    public void addStep(WorkflowStep step) {
        if (step == null)
            throw new IllegalArgumentException("A lépés nem lehet null!");
        for (WorkflowStep s : steps) {
            if (s.getName().equals(step.getName())) {
                throw new IllegalArgumentException("Már létezik ilyen nevű lépés: " + step.getName());
            }
        }
        steps.add(step);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<WorkflowStep> getSteps() {
        return Collections.unmodifiableList(steps);
    }

    public int getStepCount() {
        return steps.size();
    }

    public WorkflowStep findStepByName(String name) {
        for (WorkflowStep step : steps) {
            if (step.getName().equals(name)) {
                return step;
            }
        }
        return null;
    }
}