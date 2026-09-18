package java.cardealership.vehicle;

import java.cardealership.model.Climate;

public interface Vehicle {
    public int getNumberOfPersons();

    public boolean getIsTowbar();

    public Climate getClimate();
}
