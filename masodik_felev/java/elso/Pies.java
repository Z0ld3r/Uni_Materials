public class Pies {
    public static void main(String[] args){
        double piOverTwo = 2;
        for (double k=3; k<=1000;k+=2){
            piOverTwo*=((k-1)/k)*((k+1)/k);
        }
        System.out.println(piOverTwo*2);
    }
}