public class Logic {

    boolean a;
    boolean b;

    public static boolean impl(boolean a, boolean b) {
        if (a && !b) {
            return false;
        } else {
            return true;
        }
    }
}
