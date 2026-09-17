import java.util.List;

public class Main{
    public static void main(String[] args){
        Zoo zoo = new Zoo(new Restaurant(), List.of(new Cat(), new Dog(), new Hamster(), new Lion(), new Elephant()));
        zoo.step();
    }
}