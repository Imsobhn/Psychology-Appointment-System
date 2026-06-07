using System.ComponentModel.DataAnnotations;

namespace PsychologyAppointmentSystem.Models;

public class Appointment
{
    public int Id { get; set; }

    public int CounselorId { get; set; }

    public Counselor Counselor { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }
}