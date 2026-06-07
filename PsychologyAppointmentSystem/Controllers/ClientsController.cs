using Microsoft.AspNetCore.Mvc;
using PsychologyAppointmentSystem.Data;

public class ClientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var clients = _context.Clients.ToList();
        return View(clients);
    }
}