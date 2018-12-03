package softuniAirlines.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import softuniAirlines.bindingModels.FlightBindingModel;
import softuniAirlines.entities.Flight;
import softuniAirlines.repositories.FlightRepository;

import java.util.List;

@Controller
public class FlightController {
    private final FlightRepository flightRepository;

    @Autowired
    public FlightController(FlightRepository flightRepository) {
        this.flightRepository = flightRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        List<Flight> flightList = this.flightRepository.findAll();

        model.addAttribute("view", "flight/index");
        model.addAttribute("flights", flightList);

        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        model.addAttribute("view", "flight/create");
        return "base-layout";
    }

    @PostMapping("/create")
    public String create(FlightBindingModel bindingModel) {
        Flight flight = new Flight(
                bindingModel.getDeparture(),
                bindingModel.getDestination(),
                bindingModel.getStatus()
        );

        this.flightRepository.saveAndFlush(flight);
        return "redirect:/";
    }

    @GetMapping("/edit/{id}")
    public String edit(Model model,
                       @PathVariable(value = "id") Integer id) {
        Flight flight = this.flightRepository.findOne(id);
        model.addAttribute("view", "flight/edit");
        model.addAttribute("flight", flight);
        return "base-layout";
    }

    @PostMapping("/edit/{id}")
    public String edit(FlightBindingModel bindingModel,
                       @PathVariable(value = "id") Integer id) {
        Flight flight = this.flightRepository.findOne(id);

        flight.setDeparture(bindingModel.getDeparture());
        flight.setDestination(bindingModel.getDestination());
        flight.setStatus(bindingModel.getStatus());

        this.flightRepository.saveAndFlush(flight);

        return "redirect:/";
    }

    @GetMapping("/delete/{id}")
    public String delete(Model model,
                         @PathVariable(value = "id") Integer id) {
        Flight flight = this.flightRepository.findOne(id);
        model.addAttribute("view", "flight/delete");
        model.addAttribute("flight", flight);
        return "base-layout";
    }

    @PostMapping("/delete/{id}")
    public String delete(@PathVariable(value = "id") Integer id) {
        this.flightRepository.delete(id);
        return "redirect:/";
    }
}
