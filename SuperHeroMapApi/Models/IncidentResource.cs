using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperHeroMapApi.Models
{
    public class IncidentResource
    {
        [Key]
        public int Id { get; set; } // ID unique de la ressource d'incident dans la base de données
        public string Type { get; set; } // Type de la ressource d'incident
        [JsonIgnore]
        public ICollection<SuperHeroIncidentResource>? SuperHeroIncidentResources { get; set; } // Collection de références aux SuperHeroIncidentResources associés à cette ressource d'incident
        [JsonIgnore]
        public ICollection<Incident>? Incidents { get; set; } // Collection de références aux Incidents associés à cette ressource d'incident
    }
}
