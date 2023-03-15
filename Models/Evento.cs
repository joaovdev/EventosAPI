using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EventoAPI.Models;

public class Evento
{
    public int Id { get; set; }

    public bool AllDay { get; set; }

    public string Title { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }
}