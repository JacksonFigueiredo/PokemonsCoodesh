namespace PokeApi.Domain.Models
{
    public class CapturedPokemon
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }
    }
}
