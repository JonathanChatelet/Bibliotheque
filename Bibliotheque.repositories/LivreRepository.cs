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

        public bool ModifierLivre(Livre livre)
        {
            var livreExistant = _context.Livres.Find(livre.LivreId);

            if (livreExistant == null)
                return false;

            livreExistant.Isbn = livre.Isbn;
            livreExistant.Titre = livre.Titre;
            livreExistant.Editeur = livre.Editeur;
            livreExistant.AnneePublication = livre.AnneePublication;
            livreExistant.NbPage = livre.NbPage;
            livreExistant.Genre = livre.Genre;
            livreExistant.Emprunts = livre.Emprunts;
            livreExistant.Auteurs = livre.Auteurs;
            _context.Livres.Update(livreExistant);
            _context.SaveChanges();
            return true;
        }

        public bool SupprimerLivre(int id)
        {
            Livre livre = _context.Livres.Find(id);
            if (livre == null) return false;
            _context.Livres.Remove(livre);
            _context.SaveChanges();
            return true;
        }
    }
}
