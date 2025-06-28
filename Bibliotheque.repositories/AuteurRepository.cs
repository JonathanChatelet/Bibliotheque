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

        public void ModifierAuteur(Auteur auteur)
        {
            _context.Auteurs.Update(auteur);
            _context.SaveChanges();
        }

        public void SupprimerAuteur(int id)
        {
            Auteur auteur = _context.Auteurs.Find(id);
            if (auteur != null)
            {
                _context.Auteurs.Remove(auteur);
                _context.SaveChanges();
            }
        }
    }
}
