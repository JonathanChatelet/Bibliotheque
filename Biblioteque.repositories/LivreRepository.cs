using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheque.Models;

namespace Bibliotheque.Repositories
{
    public class LivreRepository
    {
        private readonly BibliothequeContext _context;

        public LivreRepository(BibliothequeContext context)
        {
            _context = context;
        }

        public void AjouterLivre(Livre livre)
        {
            _context.Livres.Add(livre);
            _context.SaveChanges();
        }

        public Livre? GetLivreById(int id)
        {
            return _context.Livres.Find(id);
        }

        public void ModifierLivre(Livre livre)
        {
            _context.Livres.Update(livre);
            _context.SaveChanges();
        }

        public void SupprimerLivre(int id)
        {
            Livre livre = _context.Livres.Find(id);
            if (livre != null)
            {
                _context.Livres.Remove(livre);
                _context.SaveChanges();
            }
        }
    }
}
