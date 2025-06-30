using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheque.Models;

namespace Bibliotheque.Repositories
{
    public class EmpruntRepository
    {
        private readonly BibliothequeContext _context;

        public EmpruntRepository(BibliothequeContext context)
        {
            _context = context;
        }

        public void AjouterEmprunt(Emprunt emprunt)
        {
            _context.Emprunts.Add(emprunt);
            _context.SaveChanges();
        }

        public Emprunt? GetEmpruntById(int id)
        {
            return _context.Emprunts.Find(id);
        }

        public bool ModifierEmprunt(Emprunt emprunt)
        {
            var empruntExistant = _context.Emprunts.Find(emprunt.EmpruntId);

            if (empruntExistant == null)
                return false;

            empruntExistant.AbonneId = emprunt.AbonneId;
            empruntExistant.LivreId = emprunt.LivreId;
            empruntExistant.DateEmprunt = emprunt.DateEmprunt;
            empruntExistant.DateRetour = emprunt.DateRetour;
            empruntExistant.DateRetourEffective = emprunt.DateRetourEffective;
            empruntExistant.Statut = emprunt.Statut;
            empruntExistant.Abonne = emprunt.Abonne;
            empruntExistant.Livre = emprunt.Livre;

            _context.SaveChanges();
            return true;
        }

        public bool SupprimerEmprunt(int id)
        {
            Emprunt emprunt = _context.Emprunts.Find(id);
            if (emprunt == null) return false;
            _context.Emprunts.Remove(emprunt);
            _context.SaveChanges();
            return true;
        }
    }
}
