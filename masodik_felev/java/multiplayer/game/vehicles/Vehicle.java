package multiplayer.game.vehicles;

import multiplayer.game.interfaces.Acceleratable;
import multiplayer.game.utils.VehicleException;

public abstract class Vehicle implements Acceleratable {
    private static int nextId = 0;
    protected final int id;
    private double currentSpeed;

    protected Vehicle() {
        this.id = nextId++;
        this.currentSpeed = 0;
    }

    public double getCurrentSpeed() {
        return currentSpeed;
    }

    public int getId() {
        return id;
    }

    protected final void accelerateCurrentSpeed(double amount) throws VehicleException {
        if (currentSpeed + amount < 0) {
            throw new VehicleException("Speed cannot go below zero.");
        } else {
            currentSpeed += amount;
        }
    }

    @Override
    public abstract void accelerate(double amount) throws VehicleException;

}
