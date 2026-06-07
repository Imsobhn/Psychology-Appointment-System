using System.ComponentModel.DataAnnotations;

namespace PsychologyAppointmentSystem.Models;

public class Counselor
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string Specialty { get; set; }

    public string Description { get; set; }

    public string Phone { get; set; }

    public string PhotoPath { get; set; }
}