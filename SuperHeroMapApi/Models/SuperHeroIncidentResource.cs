﻿namespace SuperHeroMapApi.Models
{
    public class SuperHeroIncidentResource
    {
        public int Id { get; set; } // ID unique de la relation SuperHeroIncidentResource dans la base de données
        public int SuperHeroId { get; set; } // ID du Super Héros associé à cette relation
        public int ResourceId { get; set; } // ID de la ressource d'incident associée à cette relation
        public virtual SuperHero SuperHero { get; set; } // Référence au Super Héros associé à cette relation
        public virtual IncidentResource IncidentResource { get; set; } // Référence à la ressource d'incident associée à cette relation
    }
}
