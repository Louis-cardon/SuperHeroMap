using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperHeroMapApi.Models
{
    public class SuperHeroIncidentResource
    {
        [Key]
        public int Id { get; set; } // ID unique de la relation SuperHeroIncidentResource dans la base de données
        public int SuperHeroId { get; set; } // ID du Super Héros associé à cette relation
        public int IncidentResourceId { get; set; } // ID de la ressource d'incident associée à cette relation
        [JsonIgnore]
        public SuperHero? SuperHero { get; set; } // Référence au Super Héros associé à cette relation
        public IncidentResource? IncidentResource { get; set; } // Référence à la ressource d'incident associée à cette relation
    }
}
