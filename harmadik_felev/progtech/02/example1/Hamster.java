package example1;

public class Hamster extends Pet {
    @Override
    public void move() {
        System.out.println("Hamster moves away");
    }

    @Override
    public void makeSound() {
        System.out.println("Hamter is callin");
    }
}
