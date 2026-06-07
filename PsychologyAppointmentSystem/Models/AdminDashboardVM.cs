using PsychologyAppointmentSystem.Models;

namespace PsychologyAppointmentSystem.Models;

public class AdminDashboardVM
{
    public int CounselorsCount { get; set; }
    public int ClientsCount { get; set; }
    public int AppointmentsCount { get; set; }

    public List<Appointment> LastAppointments { get; set; }
}