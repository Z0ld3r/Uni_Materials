package multiplayer.game.interfaces;

import multiplayer.game.utils.VehicleException;

public interface Acceleratable {
    void accelerate(double amount) throws VehicleException;
}
