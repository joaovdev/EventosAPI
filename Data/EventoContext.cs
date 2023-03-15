using EventoAPI.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace EventoAPI.Data;

public class EventoContext : DbContext
{
    public EventoContext(DbContextOptions<EventoContext> opts) : base(opts)
    {

    }

    public DbSet<Evento> Eventos { get; set; }
}
