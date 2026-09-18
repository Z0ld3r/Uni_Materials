package otodik;

public class MathUtils {

    public static int square(int n) {
        return n * n;
    }

    public static boolean isEven(int n) {
        return n % 2 == 0;
    }

    public static int max(int a, int b) {
        if (a > b) {
            return a;
        }
        return b;
    }
}