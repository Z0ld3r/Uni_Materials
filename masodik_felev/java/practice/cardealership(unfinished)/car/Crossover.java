package java.cardealership.car;

import java.cardealership.model.Condition;
import java.cardealership.vehicle.Vehicle;
import java.cardealership.model.Climate;
import java.cardealership.vehicle;

public class Crossover extends Car implements Vehicle {
    public boolean towbar;
    public Climate climate;
    public int seats;

    public Crossover(int license, int year, int price, int condition, boolean towbar, Climate climate, int seats) {
        this.licensePlateNumber = license;
        this.condition = condition;
        this.year = year;
        this.price = price;
        this.towbar = towbar;
        this.climate = climate;
        this.seats = seats;
    }

    @Override
    public Crossover Clone() {
        Crossover auto = new Crossover();
        auto.condition = this.condition;
        auto.licensePlateNumber = this.licensePlateNumber;
        auto.originalPrice = this.originalPrice;
        auto.year = this.year;
        return auto;
    }
}
