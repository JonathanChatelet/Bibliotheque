using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheque.Models;

namespace Bibliotheque.Repositories
{
    public class AuteurRepository
    {
        private readonly BibliothequeContext _context;

        public AuteurRepository(BibliothequeContext context)
        {
            _context = context;
        }

        public void AjouterAuteur(Auteur auteur)
        {
            _context.Auteurs.Add(auteur);
            _context.SaveChanges();
        }

        public Auteur? GetAuteurById(int id)
        {
            return _context.Auteurs.Find(id);
        }

        public bool ModifierAuteur(Auteur auteur)
        {
            var auteurExistant = _context.Auteurs.Find(auteur.AuteurId);

            if (auteurExistant == null)
                return false;

            auteurExistant.Nom = auteur.Nom;
            auteurExistant.Prenom = auteur.Prenom;
            auteurExistant.DateNaissance = auteur.DateNaissance;
            auteurExistant.Nationalite = auteur.Nationalite;

            _context.SaveChanges();
            return true;
        }

        public bool SupprimerAuteur(int id)
        {
            Auteur auteur = _context.Auteurs.Find(id);
            if (auteur == null) return false;
            _context.Auteurs.Remove(auteur);
            _context.SaveChanges();
            return true;
        }
    }
}
