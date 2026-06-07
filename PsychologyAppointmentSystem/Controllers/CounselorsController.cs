using Microsoft.AspNetCore.Mvc;
using PsychologyAppointmentSystem.Data;
using PsychologyAppointmentSystem.Models;

namespace PsychologyAppointmentSystem.Controllers;

public class CounselorsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public CounselorsController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    // LIST
    public IActionResult Index()
    {
        var list = _context.Counselors.ToList();
        return View(list);
    }

    // CREATE (GET)
    public IActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    public async Task<IActionResult> Create(Counselor model, IFormFile Photo)
    {
        if (Photo != null)
        {
            string folder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fileName = Guid.NewGuid() + Path.GetExtension(Photo.FileName);

            string path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Photo.CopyToAsync(stream);
            }

            model.PhotoPath = "/uploads/" + fileName;
        }

        _context.Counselors.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var item = _context.Counselors.Find(id);
        if (item != null)
        {
            _context.Counselors.Remove(item);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    public IActionResult Dashboard(int id)
    {
        var counselor = _context.Counselors.FirstOrDefault(x => x.Id == id);

        var appointments = _context.Appointments
            .Where(x => x.CounselorId == id)
            .Select(x => new CounselorAppointmentVM
            {
                AppointmentDate = x.AppointmentDate,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                ClientName = x.Client.FirstName + " " + x.Client.LastName,
                Mobile = x.Client.Mobile
            })
            .ToList();

        ViewBag.Counselor = counselor;
        return View(appointments);
    }
}