using System.Collections.Generic;

namespace PsychologyAppointmentSystem.Models;

public class WeeklyCalendarVM
{
    public int CounselorId { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
}