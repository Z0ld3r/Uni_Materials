public class Dog extends Pet{

    @Override
    public void move(){
        System.out.println("Dog walks away.");
    }

    @Override
    public void makeSound(){
        System.out.println("Woof");
    }
}
