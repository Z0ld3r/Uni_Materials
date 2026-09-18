public class Beker {
    public static void main(String[] args) {
        int input = Integer.parseInt(System.console().readLine());
        int inputi = Integer.parseInt(System.console().readLine());
        for (int i=input; i<=inputi;i++){
            System.out.println((double)i/2);
        }
    }
}
