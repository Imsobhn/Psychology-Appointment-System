using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PsychologyAppointmentSystem.Data;
using PsychologyAppointmentSystem.Models;

namespace PsychologyAppointmentSystem.Controllers;

public class AppointmentsController : Controller
{
    private readonly ApplicationDbContext _context;
    public IActionResult Weekly(int counselorId)
    {
        var counselor = _context.Counselors
            .FirstOrDefault(x => x.Id == counselorId);

        if (counselor == null)
            return Content("مشاور پیدا نشد ❌");

        var appointments = _context.Appointments
            .Include(x => x.Client)
            .Where(x => x.CounselorId == counselorId)
            .ToList();

        ViewBag.CounselorName = counselor.FirstName + " " + counselor.LastName;

        var vm = new WeeklyCalendarVM
        {
            CounselorId = counselorId,
            Appointments = appointments
        };

        return View(vm);
    }
    public AppointmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        ViewBag.Counselors = _context.Counselors
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName
            }).ToList();

        return View(new AppointmentVM
        {
            Date = DateTime.Today
        });
    }
    [HttpPost]
    public IActionResult Create(int CounselorId, DateTime Date)
    {
        ViewBag.Counselors = _context.Counselors
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName
            }).ToList();

        var allSlots = Enumerable.Range(8, 10)
            .Select(h => new TimeSpan(h, 0, 0))
            .ToList();

        var reserved = _context.Appointments
            .Where(x => x.CounselorId == CounselorId
                     && x.AppointmentDate.Date == Date.Date)
            .Select(x => x.StartTime)
            .ToList();

        var vm = new AppointmentVM
        {
            CounselorId = CounselorId,
            Date = Date,
            AvailableSlots = allSlots.Where(x => !reserved.Contains(x)).ToList()
        };

        return View(vm);
    }
    [HttpPost]
    public IActionResult Confirm(AppointmentVM model)
    {
        var exists = _context.Appointments.Any(x =>
            x.CounselorId == model.CounselorId &&
            x.AppointmentDate.Date == model.Date.Date &&
            x.StartTime == model.SelectedTime);

        if (exists)
            return Content("این ساعت قبلاً رزرو شده ❌");

        var client = new Client
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            NationalCode = model.NationalCode,
            Mobile = model.Mobile
        };

        _context.Clients.Add(client);
        _context.SaveChanges();

        _context.Appointments.Add(new Appointment
        {
            CounselorId = model.CounselorId,
            ClientId = client.Id,
            AppointmentDate = model.Date,
            StartTime = model.SelectedTime,
            EndTime = model.SelectedTime.Add(TimeSpan.FromHours(1))
        });

        _context.SaveChanges();

        return Content("رزرو شد ✔");
    }
}