package hu.suli.text;

public class TextStats {
    private String text;

    public TextStats(String text) {
        this.text = text;
    }

    public String getText() {
        return text;
    }

    public int getCharacterCount() {
        return text.length();
    }

    public int getLineCount() {
        if (text.isEmpty()) {
            return 0;
        }
        return text.split("\\R").length;
    }

    public boolean containsWord(String word) {
        String[] words = text.split("[\\s\\p{Punct}]+");
        for (String current : words) {
            if (current.equalsIgnoreCase(word)) {
                return true;
            }
        }
        return false;
    }

    public String toUpperCaseText() {
        return text.toUpperCase();
    }
}
