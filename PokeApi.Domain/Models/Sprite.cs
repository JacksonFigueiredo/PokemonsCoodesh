using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PokeApi.Domain.Models
{
    public class Sprite
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
