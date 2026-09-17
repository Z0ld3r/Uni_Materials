import java.util.Arrays;

public class Caretaker {
    public void takeCareOf(Animal... animals){
        Arrays.stream(animals).toList().forEach(animal -> System.out.println("Caretaker takes care of this " + animal.toString()));
    }
}
