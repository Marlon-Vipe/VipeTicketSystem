using System.Data.Entity;
using System.Net.Sockets;
using VipeSystem.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base("TicketsAppConnection") { }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Ticket_Log> TicketLogs { get; set; }
}
