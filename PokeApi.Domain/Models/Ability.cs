using System.ComponentModel.DataAnnotations;

namespace PokeApi.Domain.Models
{
    public class Ability
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
