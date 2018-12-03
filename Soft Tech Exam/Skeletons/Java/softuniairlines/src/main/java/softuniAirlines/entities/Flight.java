package softuniAirlines.entities;


import javax.persistence.*;

@Entity
@Table(name = "flights")
public class Flight {
    private Integer id;
    private String departure;
    private String destination;
    private String status;

    public Flight() {
        // default constructor
    }

    public Flight(String departure, String destination, String status) {
        this.departure = departure;
        this.destination = destination;
        this.status = status;
    }


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false, columnDefinition = "text")
    public String getDeparture() {
        return departure;
    }

    public void setDeparture(String departure) {
        this.departure = departure;
    }

    @Column(nullable = false, columnDefinition = "text")
    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    @Column(nullable = false, columnDefinition = "text")
    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
