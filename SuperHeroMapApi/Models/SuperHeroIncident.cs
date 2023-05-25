using System.ComponentModel.DataAnnotations;

namespace SuperHeroMapApi.Models
{
    public class SuperHeroIncident
    {
        [Key]
        public int Id { get; set; } // ID unique de la relation SuperHeroIncident dans la base de données
        public int SuperHeroId { get; set; } // ID du Super Héros associé à cette relation
        public int IncidentId { get; set; } // ID de l'incident associé à cette relation
        public SuperHero? SuperHero { get; set; } // Référence au Super Héros associé à cette relation
        public Incident? Incident { get; set; } // Référence à l'incident associé à cette relation
    }
}
