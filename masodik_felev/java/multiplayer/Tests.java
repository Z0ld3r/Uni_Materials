package multiplayer.tests;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertNotSame;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.fail;

import java.util.List;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import game.Player;
import game.utils.GameRegistry;
import game.utils.VehicleException;
import game.vehicles.Car;

public class Tests {

    private Player richPlayer;
    private Car cheapCar;
    private Car mediumCar;
    private Car fastCar;

    @BeforeEach
    void setUp() {
        richPlayer = new Player("Daniel", "127.0.0.1", 2000);
        cheapCar = new Car(180, 200);
        mediumCar = new Car(220, 500);
        fastCar = new Car(220, 600);
    }

    @Test
    void playerConstructorRejectsNullName() {
        assertThrows(IllegalArgumentException.class,
                () -> new Player(null, "127.0.0.1", 100));
    }

    @Test
    void playerConstructorRejectsNegativeMoney() {
        assertThrows(IllegalArgumentException.class,
                () -> new Player("A", "127.0.0.1", -1));
    }

    @Test
    void playerConstructorRejectsWhitespaceInIp() {
        assertThrows(IllegalArgumentException.class,
                () -> new Player("A", "127.0. 0.1", 100));
    }

    @Test
    void playerConstructorSetsMoneyCorrectly() {
        Player p = new Player("Peter", "192.168.1.5", 450);
        assertEquals(450, p.getMoney());
    }

    @Test
    void carAccelerateWorksWithPositiveAndNegativeAmount() throws VehicleException {
        cheapCar.accelerate(50);
        assertEquals(50.0, cheapCar.getCurrentSpeed());

        cheapCar.accelerate(-20);
        assertEquals(30.0, cheapCar.getCurrentSpeed());
    }

    @Test
    void carDoesNothingWhenMaxSpeedWouldBeExceeded() throws VehicleException {
        mediumCar.accelerate(200);
        assertEquals(200.0, mediumCar.getCurrentSpeed());

        mediumCar.accelerate(30);
        assertEquals(200.0, mediumCar.getCurrentSpeed());
    }

    @Test
    void carThrowsWhenSpeedWouldGoBelowZero() {
        try {
            cheapCar.accelerate(-10);
            fail("VehicleException was expected.");
        } catch (VehicleException e) {
            assertEquals("Vehicle speed cannot go below zero.", e.getMessage());
        }
    }

    @Test
    void playersWithDifferentIpButSameNameMoneyAndCarsAreEqual() throws VehicleException {
        Player p1 = new Player("A", "1.1.1.1", 1000);
        Player p2 = new Player("A", "2.2.2.2", 1000);

        Car c1 = new Car(150, 100);
        Car c2 = new Car(150, 100);

        p1.buyCar(c1);
        p2.buyCar(c2);

        assertEquals(p1, p2);
        assertEquals(p1.hashCode(), p2.hashCode());
    }

    @Test
    void compareToIsTransitive() {
        Car c1 = new Car(100, 100);
        Car c2 = new Car(150, 100);
        Car c3 = new Car(150, 200);

        assertFalse(c1.compareTo(c2) > 0);
        assertFalse(c2.compareTo(c3) > 0);
        assertFalse(c1.compareTo(c3) > 0);
    }

    @Test
    void buyCarThrowsWhenNotEnoughMoney() {
        Player poor = new Player("Poor", "10.0.0.1", 10);
        assertThrows(VehicleException.class, () -> poor.buyCar(mediumCar));
    }

    @Test
    void buyCarThrowsWhenCarAlreadyOwned() throws VehicleException {
        Player p2 = new Player("Other", "10.0.0.2", 2000);
        richPlayer.buyCar(cheapCar);
        assertThrows(VehicleException.class, () -> p2.buyCar(cheapCar));
    }

    @Test
    void getSortedCarsReturnsSortedDefensiveCopy() throws VehicleException {
        richPlayer.buyCar(fastCar);
        richPlayer.buyCar(cheapCar);
        richPlayer.buyCar(mediumCar);

        List<Car> sorted = richPlayer.getSortedCars();

        assertEquals(180, sorted.get(0).getMaxSpeed());
        assertEquals(220, sorted.get(1).getMaxSpeed());
        assertEquals(220, sorted.get(2).getMaxSpeed());
        assertEquals(500, sorted.get(1).getPrice());
        assertEquals(600, sorted.get(2).getPrice());

        List<Car> sorted2 = richPlayer.getSortedCars();
        assertNotSame(sorted, sorted2);
        assertNotSame(sorted.get(0), sorted2.get(0));
    }

    @ParameterizedTest
    @ValueSource(strings = { "Daniel", "Peter", "Richard" })
    void validPlayerNamesCanConstructPlayers(String name) {
        Player p = new Player(name, "127.0.0.1", 100);
        assertEquals(name, p.getName());
    }

    @Test
    void gameRegistryStoresAndReturnsValues() {
        GameRegistry<String, Player> registry = new GameRegistry<>();
        registry.put("Daniel", richPlayer);

        assertEquals(1, registry.size());
        assertEquals(richPlayer, registry.get("Daniel"));
    }
}