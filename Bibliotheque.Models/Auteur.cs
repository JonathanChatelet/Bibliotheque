using System;
using System.Collections.Generic;

namespace Bibliotheque.Models;

public partial class Auteur
{
    public int AuteurId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateOnly? DateNaissance { get; set; }

    public string? Nationalite { get; set; }

    public virtual ICollection<Livre> Livres { get; set; } = new List<Livre>();
}
