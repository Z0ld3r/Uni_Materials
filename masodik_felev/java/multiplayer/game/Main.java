package multiplayer.game;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

import multiplayer.game.Player;
import multiplayer.game.utils.GameRegistry;
import multiplayer.game.utils.VehicleException;
import multiplayer.game.vehicles.Car;

public class Main {
    public static Player loadPlayerFromFile(String playerName) {
        File input = new File("Users/" + playerName + ".txt");
        try (BufferedReader bf = new BufferedReader(new FileReader(input))) {
            String line = bf.readLine();
            String[] data = line.split(" ");

            String ip = data[0];
            int money;
            try {
                money = Integer.parseInt(data[1]);
            } catch (NumberFormatException e) {
                money = 0;
            }

            return new Player(playerName, ip, money);
        } catch (IOException e) {
            System.out.println("IO error occurred: " + e.getMessage());
            return null;
        }
    }

    public static void main(String[] args) {
        GameRegistry<String, Player> playerRegistry = new GameRegistry<>();
        Player daniel = loadPlayerFromFile("Daniel");
        Player peter = loadPlayerFromFile("Peter");
        playerRegistry.put("Daniel", daniel);
        playerRegistry.put("Peter", peter);

        Car car1 = new Car(180, 300);
        Car car3 = new Car(220, 450);
        Car car4 = new Car(160, 250);

        try {
            daniel.buyCar(car1);
            daniel.buyCar(car3);
            daniel.buyCar(car4);
        } catch (VehicleException e) {
            System.out.println(e.getMessage());
        }

        System.out.println("Daniel sorted cars:");
        for (Car car : daniel.getSortedCars()) {
            System.out.println(car);
        }
    }

}
