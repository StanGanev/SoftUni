namespace SoftUniAirlines.Models
{
    using System.ComponentModel.DataAnnotations;


    public class Flight
    {
        public int Id { get; set; }

        [Required]
        public string Departure  { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
