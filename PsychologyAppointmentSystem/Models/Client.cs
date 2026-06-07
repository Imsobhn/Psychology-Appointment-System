using System.ComponentModel.DataAnnotations;

namespace PsychologyAppointmentSystem.Models;

public class Client
{
    public int Id { get; set; }

    [Required(ErrorMessage = "نام الزامی است")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "نام خانوادگی الزامی است")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "کد ملی الزامی است")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی فقط باید عدد باشد")]
    public string NationalCode { get; set; }

    [Required(ErrorMessage = "شماره موبایل الزامی است")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل معتبر نیست")]
    public string Mobile { get; set; }
}