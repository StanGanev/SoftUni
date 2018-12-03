package softuniAirlines.bindingModels;

import javax.validation.constraints.NotNull;

public class FlightBindingModel {
    @NotNull
    private String departure;
    @NotNull
    private String destination;
    @NotNull
    private String status;

    public String getDeparture() {
        return departure;
    }

    public void setDeparture(String departure) {
        this.departure = departure;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
