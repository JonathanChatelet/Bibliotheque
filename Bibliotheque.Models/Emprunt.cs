using System;
using System.Collections.Generic;

namespace Bibliotheque.Models;

public partial class Emprunt
{
    public int EmpruntId { get; set; }

    public int AbonneId { get; set; }

    public int LivreId { get; set; }

    public DateOnly DateEmprunt { get; set; }

    public DateOnly DateRetour { get; set; }

    public DateOnly? DateRetourEffective { get; set; }

    public string? Statut { get; set; }

    public virtual Abonne Abonne { get; set; } = null!;

    public virtual Livre Livre { get; set; } = null!;
}
