package human;

public class Human {
    public String name;
    public int age;
    public double mass;
    public double height;

    public Human() {
        this.name = "Default";
        this.age = 0;
        this.mass = 2.5;
        this.height = 50;
    }

    public Human(String name, int age, double mass, double height) {
        this.name = name;
        this.age = age;
        this.mass = mass;
        this.height = height;
    }

    public double speed() {
        return (mass * height) / 3;
    }

    public void getOlder() {
        age += 1;
    }

    public double bmi() {
        return (mass / Math.pow(height / 100, 2));
    }
}
