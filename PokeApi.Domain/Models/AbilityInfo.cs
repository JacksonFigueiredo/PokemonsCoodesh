using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeApi.Domain.Models
{
    public class AbilityInfo
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("ability")]
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
        public int AbilityId { get; set; }
    }
}
