package Circle.utils;

public class Circle {
    public double x;
    public double y;
    public double radius;

    public Circle() {
        x = 0;
        y = 0;
        radius = 1;
    }

    public Circle(double x, double y, double radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public void enlarge(int f) {
        radius *= f;
    }

    public double getArea() {
        return (Math.PI * Math.pow(radius, 2));
    }
}
