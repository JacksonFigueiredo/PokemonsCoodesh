using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PokeApi.Domain.Models
{
    public class GameIndices
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("game_index")]
        public int GameIndexValue { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }

        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
