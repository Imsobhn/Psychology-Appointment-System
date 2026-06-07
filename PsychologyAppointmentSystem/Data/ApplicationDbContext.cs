using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PsychologyAppointmentSystem.Models;

namespace PsychologyAppointmentSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Counselor> Counselors { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Appointment> Appointments { get; set; }
}