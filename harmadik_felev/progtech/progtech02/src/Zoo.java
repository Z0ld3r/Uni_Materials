import java.util.*;
public class Zoo {
    private Restaurant restaurant;
    private List<Animal> animals;


    public Zoo(Restaurant restaurant, List<Animal> animals){
        this.restaurant = restaurant;
        this.animals = animals;
    }

    public void step(){
        animals.forEach(animal -> {
            animal.move();
            animal.makeSound();
        });
    }
}
