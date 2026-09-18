package multiplayer.game.vehicles;

import multiplayer.game.utils.VehicleException;

public class Train extends Vehicle {

    @Override
    public void accelerate(double amount) throws VehicleException {
        if (amount < 0) {
            accelerateCurrentSpeed(amount / 10);
        } else {
            accelerate(amount);
        }
    }
}
