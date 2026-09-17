public class Cat extends Pet{
    @Override
    public void move(){
        System.out.println("Cat walks away.");
    }

    @Override
    public void makeSound(){
        System.out.println("Meow");
    }
}
