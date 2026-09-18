public class Pyin_it {
    public static void main(String[] args){
        double piOverFour = 0;
        for (double k=0; k<=500; k++) {
            piOverFour +=Math.pow(-1,k)*(1/(2*k+1));
        }
        System.out.println(piOverFour*4);
    }
}
