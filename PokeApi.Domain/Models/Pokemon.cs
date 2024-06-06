using Newtonsoft.Json;

namespace PokeApi.Domain.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }
        public Sprite? Sprites { get; set; }
        public List<AbilityInfo>? Abilities { get; set; }
        [JsonProperty("game_indices")]
        public List<GameIndices>? GameIndices { get; set; }
        public string? SpriteBase64 { get; set; }
    }
}
