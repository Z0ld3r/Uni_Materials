package example1;

import java.util.List;

public class Main {
    public static void main(String[] args) {
        Zoo zoo = new Zoo(new Restaurant(), List.of(new Lion(),
                new Dog(), new Hamster(),
                new Cat(), new Elephant()));

        zoo.step();
    }
}