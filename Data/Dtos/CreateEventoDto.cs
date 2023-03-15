using EventoAPI.Models;
using Newtonsoft.Json;

namespace EventoAPI.Data.Dtos;

public class CreateEventoDto
{
    [JsonProperty(PropertyName = "allDay")]
    public bool AllDay { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    [JsonProperty(PropertyName = "start")]
    public DateTime Start { get; set; }

    [JsonProperty(PropertyName = "end")]
    public DateTime End { get; set; }

    //[JsonProperty(PropertyName = "id")]
    //public string Id { get; set; }
}

public class CreateEventoPayloadDto
{
    [JsonProperty(PropertyName = "event")]
    public CreateEventoDto EventoDto { get; set; }

    [JsonProperty(PropertyName = "relatedEvents")]
    public List<Evento>? EventosRsselacionados { get; set; }
}

