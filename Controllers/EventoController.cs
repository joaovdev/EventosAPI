using AutoMapper;
using EventoAPI.Data;
using EventoAPI.Data.Dtos;
using EventoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController : ControllerBase
{
    private EventoContext _context;
    private IMapper _mapper;

    public EventoController(IMapper mapper, EventoContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEvento(
    [FromBody] CreateEventoPayloadDto eventoPayloadDto)
    {
        Evento evento = _mapper.Map<Evento>(eventoPayloadDto.EventoDto);
        _context.Eventos.Add(evento);
        _context.SaveChanges();
        Console.WriteLine($"Adicionar evento \n" + JsonConvert.SerializeObject(evento));
        return CreatedAtAction(nameof(RecuperaEventoPorId), new { id = evento.Id }, evento);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEvento(int id)
    {
        var evento = _context.Eventos.FirstOrDefault(e => e.Id == id);
        if (evento == null) return NotFound();
        _context.Remove(evento);
        _context.SaveChanges(true);
        Console.WriteLine($"Deletar evento id {id}");
        return NoContent();
    }


    [HttpGet]
    public IEnumerable<Evento> RecuperaEventos([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        Console.WriteLine("Pegou os evento");
        return _context.Eventos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEventoPorId(int id)
    {
        var evento = _context.Eventos
            .FirstOrDefault(evento => evento.Id == id);
        if (evento == null) return NotFound();
        return Ok(evento);
    }

}
