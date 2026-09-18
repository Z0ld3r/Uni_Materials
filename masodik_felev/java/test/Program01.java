package test;

public class Program01 {
    public static String caesarCode(String text, int shift) {
        StringBuilder result = new StringBuilder();
        for (char c : text.toCharArray()) {
            char shiftedChar = (char) ('a' + (c - 'a' + shift) % 26);
            result.append(shiftedChar);
        }
        return result.toString();
    }
}
