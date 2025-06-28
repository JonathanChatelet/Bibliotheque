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

        public void ModifierEmprunt(Emprunt emprunt)
        {
            _context.Emprunts.Update(emprunt);
            _context.SaveChanges();
        }

        public void SupprimerEmprunt(int id)
        {
            Emprunt emprunt = _context.Emprunts.Find(id);
            if (emprunt != null)
            {
                _context.Emprunts.Remove(emprunt);
                _context.SaveChanges();
            }
        }
    }
}
