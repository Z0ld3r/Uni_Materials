package agentic.workflow;

import agentic.workflow.llm.SchemaType;
import agentic.workflow.llm.StructuredOutput;

public class WorkflowStep {
    // vars
    private String name;
    private String prompt;
    private String systemPrompt;
    private StructuredOutput structuredOutput;

    // init
    public WorkflowStep(String name, String prompt, String systemPrompt, StructuredOutput output) {
        if (name == null || name.isBlank()) {
            throw new IllegalArgumentException("A lépés neve nem lehet üres!");
        }
        if (prompt == null || prompt.isBlank()) {
            throw new IllegalArgumentException("A prompt nem lehet üres!");
        }
        if (systemPrompt == null || systemPrompt.isBlank()) {
            throw new IllegalArgumentException("A systemPrompt nem lehet üres!");
        }
        if (output == null) {
            throw new IllegalArgumentException("Az output nem lehet null!");
        }

        this.name = name;
        this.prompt = prompt;
        this.systemPrompt = systemPrompt;
        this.structuredOutput = output;
    }

    // response
    public String simulateResponse() {
        SchemaType type = structuredOutput.getSchemaTypes()[0];

        switch (type) {
            case INT:
                return "0";
            case STRING:
                return "sample";
            case BOOLEAN:
                return "true";
            case LIST_INT:
                return "[1,2,3]";
            case MAP_STRING_STRING:
                return "{k:v}";
            case LIST_STRING:
                return "[a,b]";
            default:
                return "ismeretlen típus";
        }
    }

    // getters
    public String getName() {
        return name;
    }

    public String getPrompt() {
        return prompt;
    }

    public String getSystemPrompt() {
        return systemPrompt;
    }

    public StructuredOutput getOutput() {
        return structuredOutput;
    }

    public StructuredOutput getStructuredOutput() {
        return structuredOutput;
    }

    public boolean expectsStructuredOutput() {
        return true;
    }

    // setters
    public void setName(String name) {
        this.name = name;
    }

    public void setPrompt(String prompt) {
        this.prompt = prompt;
    }

    public void setSystemPrompt(String systemPrompt) {
        this.systemPrompt = systemPrompt;
    }

    public void setStructuredOutput(StructuredOutput structuredOutput) {
        this.structuredOutput = structuredOutput;
    }
}
