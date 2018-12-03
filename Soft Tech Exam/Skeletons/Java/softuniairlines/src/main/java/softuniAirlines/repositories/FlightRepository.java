package softuniAirlines.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import softuniAirlines.entities.Flight;

@Repository
public interface FlightRepository extends JpaRepository<Flight, Integer> {
}
