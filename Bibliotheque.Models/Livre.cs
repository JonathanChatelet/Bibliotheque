using System;
using System.Collections.Generic;

namespace Bibliotheque.Models;

public partial class Livre
{
    public int LivreId { get; set; }

    public string Isbn { get; set; } = null!;

    public string Titre { get; set; } = null!;

    public string? Editeur { get; set; }

    public int? AnneePublication { get; set; }

    public int? NbPage { get; set; }

    public string? Genre { get; set; }

    public virtual ICollection<Emprunt> Emprunts { get; set; } = new List<Emprunt>();

    public virtual ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
}
