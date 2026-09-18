package Circle.main;

import Circle.utils.Circle;

public class Circlemain {
    public static void main(String[] Args) {
        Circle h1 = new Circle();
        Circle h2 = new Circle(5, 3, 4);
        System.out.println(h1.radius);
        System.out.println(h2.radius);
        h2.enlarge(2);
        System.out.println(h2.radius);
        System.out.println(h2.getArea());
    }
}
