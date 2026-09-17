package example1;

public class Lion extends WildAnimal {
    @Override
    public void move() {
        System.out.println("Lion walks away");
    }

    @Override
    public void makeSound() {
        System.out.println("Roarr");
    }
}