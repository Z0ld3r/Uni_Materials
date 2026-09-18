package multiplayer.game;

import multiplayer.game.utils.VehicleException;
import multiplayer.game.vehicles.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

public class Player {

    private final String name;
    private final String ipAddress;
    private int money;
    private final ArrayList<Car> cars;

    public Player(String name, String ipAddress, int money) {
        if (name == null) {
            throw new IllegalArgumentException("Name cannot be null.");
        }
        if (ipAddress == null || ipAddress.isBlank()) {
            throw new IllegalArgumentException("Ip address cannot be null or empty.");
        }
        for (int i = 0; i < ipAddress.length(); i++) {
            if (Character.isWhitespace(ipAddress.charAt(i))) {
                throw new IllegalArgumentException("Ip address cannot contain whitespace.");
            }
        }
        if (money < 0) {
            throw new IllegalArgumentException("Money cannot be null.");
        }
        this.name = name;
        this.ipAddress = ipAddress;
        this.money = money;
        this.cars = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public String getIpAddress() {
        return ipAddress;
    }

    public int getMoney() {
        return money;
    }

    public void buyCar(Car car) throws VehicleException {
        if (car == null) {
            throw new VehicleException("Car cannot be null.");
        }
        if (car.isOwned()) {
            throw new VehicleException("This car has already been purchased.");
        }
        if (money < car.getPrice()) {
            throw new VehicleException("Not enough money to buy the car.");
        }

        cars.add(car);
        money -= car.getPrice();
        car.setOwned(true);
    }

    public List<Car> getSortedCars() {
        ArrayList<Car> copy = new ArrayList<>();
        for (Car car : cars) {
            copy.add(car.clone());
        }
        Collections.sort(copy);
        return copy;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (!(obj instanceof Player other))
            return false;
        return Objects.equals(name, other.name)
                && money == other.money
                && Objects.equals(cars, other.cars);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, money, cars);
    }

    @Override
    public String toString() {
        return "Player{name='" + name + "', ipAddress='" + ipAddress + "', money=" + money + ", cars=" + cars + "}";
    }
}
