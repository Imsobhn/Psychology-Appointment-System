namespace PsychologyAppointmentSystem.Models;
using DNTPersianUtils.Core;

public class CounselorAppointmentVM
{
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public string ClientName { get; set; }
    public string Mobile { get; set; }

    public string PersianDate
    {
        get
        {
            return AppointmentDate.ToPersianDateTextify();
        }
    }
}
