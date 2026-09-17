package example1;

import java.util.Arrays;

public class CareTaker {
    public void takeCareOf(Animal... animals) {
        Arrays.stream(animals)
                .toList()
                .forEach(animal -> {
                    System.out.println("Caretaker takes care of " + animal.toString());
                });
    }
}
