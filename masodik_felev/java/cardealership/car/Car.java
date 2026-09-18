package java.cardealership.car;

import java.cardealership.model.Condition;
import java.util.concurrent.locks.Condition;

public abstract class Car implements Cloneable, Comparable<Car> {
    public int licensePlateNumber;
    public int year;
    public int originalPrice;
    public Condition condition;

    public Car(int license, int year, int price, int condition) {
        this.licensePlateNumber = license;
        this.condition = condition;
        this.year = year;
        this.price = price;
    }

    public int GetExtraPrice() {
        if (this.condition == Condition.NEW && this.GetAge() <= 2) {
            return originalPrice * 0.02;
        }
        return 0;
    }

    public int GetAge() {
        return 2026 - this.year;
    }

    public int PurchasePrice();

    public Car Clone() {
        Car auto = new Car();
        auto.condition = this.condition;
        auto.licensePlateNumber = this.licensePlateNumber;
        auto.originalPrice = this.originalPrice;
        auto.year = this.year;
        return auto;
    }

    public boolean Equals(Car masik) {
        if (this.licensePlateNumber == masik.licensePlateNumber) {
            return true;
        }
        return false;
    }

    public Car CompareTo(Car masik) {
        if (this.originalPrice > masik.originalPrice) {
            return this;
        } else if (this.originalPrice < masik.originalPrice) {
            return masik;
        }
        if (this.licensePlateNumber >= masik.licensePlateNumber) {
            return this;
        }
        return masik;
    }
}
