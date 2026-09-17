package example1;

public class Dog extends Pet {
    @Override
    public void move() {
        System.out.println("Dog runs away");
    }

    @Override
    public void makeSound() {
        System.out.println("Bark");
    }
}
