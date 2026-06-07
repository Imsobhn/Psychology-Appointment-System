using System;
using System.Collections.Generic;

namespace PsychologyAppointmentSystem.Models
{
    public class AppointmentVM
    {
        public int CounselorId { get; set; }
        public DateTime Date { get; set; }

        public List<TimeSpan> AvailableSlots { get; set; } = new();

        public TimeSpan SelectedTime { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
    }
}