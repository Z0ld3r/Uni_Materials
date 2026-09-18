package agentic.workflow.llm;

public class StructuredOutput {
    private final SchemaType[] schemaTypes;

    public StructuredOutput(SchemaType... types) {
        if (types == null) {
            throw new NullPointerException("A tömb nem lehet null!");
        }

        if (types.length == 0) {
            throw new IllegalArgumentException("Legalább egy sématípust meg kell adni!");
        }

        for (SchemaType type : types) {
            if (type == null) {
                throw new NullPointerException("A megadott sématípusok között nem lehet null!");
            }
        }

        this.schemaTypes = types.clone();
    }

    public SchemaType[] getSchemaTypes() {
        return schemaTypes.clone();
    }

    public boolean contains(SchemaType schemaType) {
        for (SchemaType type : schemaTypes) {
            if (type == schemaType) {
                return true;
            }
        }
        return false;
    }

    public int size() {
        return schemaTypes.length;
    }
}