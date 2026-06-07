using Microsoft.AspNetCore.Mvc;
using PsychologyAppointmentSystem.Data;
using Microsoft.EntityFrameworkCore;
using PsychologyAppointmentSystem.Models;

namespace PsychologyAppointmentSystem.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new AdminDashboardVM
        {
            CounselorsCount = _context.Counselors.Count(),
            ClientsCount = _context.Clients.Count(),
            AppointmentsCount = _context.Appointments.Count(),
            LastAppointments = _context.Appointments
                .Include(x => x.Client)
                .OrderByDescending(x => x.AppointmentDate)
                .Take(5)
                .ToList()
        };

        return View(model);
    }
}