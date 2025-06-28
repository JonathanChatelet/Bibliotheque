using System;
using System.Collections.Generic;

namespace Bibliotheque.Models;

public partial class Abonne
{
    public int AbonneId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public DateOnly DateAbonnement { get; set; }

    public string Email { get; set; } = null!;

    public string? Telephone { get; set; }

    public virtual ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
}
