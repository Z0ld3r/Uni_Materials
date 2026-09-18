package human;

public class HumanMain {
    public static void main(String[] args) {
        Human h1 = new Human();
        h1.getOlder();
        System.out.println("H1 age: " + h1.age);
        Human h2 = new Human("Kelemen", 21, 70, 175);
        System.out.println(h2.bmi());
    }
}
