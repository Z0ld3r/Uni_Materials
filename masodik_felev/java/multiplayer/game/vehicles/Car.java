package multiplayer.game.vehicles;

import java.util.Objects;

import multiplayer.game.interfaces.Purchasable;
import multiplayer.game.utils.VehicleException;

public class Car extends Vehicle implements Purchasable, Cloneable, Comparable<Car> {

    private final int maxSpeed;
    private final int price;
    private boolean owned;

    public Car(int maxSpeed, int price) {
        if (maxSpeed <= 0) {
            throw new IllegalArgumentException("Max speed cannot be 0 or less.");
        }
        if (price < 0) {
            throw new IllegalArgumentException("Price cannot be negative");
        }

        this.maxSpeed = maxSpeed;
        this.price = price;
        this.owned = false;

    }

    public int getMaxSpeed() {
        return maxSpeed;
    }

    @Override
    public int getPrice() {
        return price;
    }

    @Override
    public boolean isOwned() {
        return owned;
    }

    public void setOwned(boolean owned) {
        this.owned = owned;
    }

    @Override
    public void accelerate(double amount) throws VehicleException {
        if (getCurrentSpeed() + amount > maxSpeed) {
            return;
        }
        accelerateCurrentSpeed(amount);
    }

    @Override
    public Car clone() {
        Car copy = new Car(maxSpeed, price);
        copy.owned = this.owned;
        return copy;
    }

    @Override
    public int compareTo(Car other) {
        int byMaxSpeed = Integer.compare(this.maxSpeed, other.maxSpeed);
        if (byMaxSpeed != 0) {
            return byMaxSpeed;
        }
        return Integer.compare(this.price, other.price);
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (!(obj instanceof Car other))
            return false;
        return this.maxSpeed == other.maxSpeed && this.price == other.price;
    }

    @Override
    public int hashCode() {
        return Objects.hash(maxSpeed, price);
    }

    @Override
    public String toString() {
        return "Car{id=" + id + ", maxSpeed=" + maxSpeed + ", price=" + price + ", owned=" + owned + "}";
    }
}
