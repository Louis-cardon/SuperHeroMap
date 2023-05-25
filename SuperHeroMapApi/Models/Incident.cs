using System.ComponentModel.DataAnnotations;

namespace SuperHeroMapApi.Models
{
    public class Incident
    {
        [Key]
        public int Id { get; set; } // ID unique de l'incident dans la base de données
        public int IncidentResourceId { get; set; } // ID de la ressource d'incident associée à cet incident
        public string CityName { get; set; } // Nom de la ville associée à cet incident
        public double Latitude { get; set; } // Latitude de la position géographique de cet incident
        public double Longitude { get; set; } // Longitude de la position géographique de cet incident
        public bool IsResolved { get; set; } // Booléen qui indique si l'incident a été résolu
        public IncidentResource? IncidentResource { get; set; } // Référence à la ressource d'incident associée à cet incident
        public ICollection<SuperHeroIncident>? SuperHeroIncidents { get; set; } // Collection de références aux SuperHeroIncidents associés à cet incident
    }
}
