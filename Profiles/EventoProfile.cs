using AutoMapper;
using EventoAPI.Data.Dtos;
using EventoAPI.Models;

namespace EventoAPI.Profiles;

public class EventoProfile : Profile
{
    public EventoProfile()
    {
        CreateMap<CreateEventoDto, Evento>();
        CreateMap<Evento, ReadEventoDto>();
    }
}
