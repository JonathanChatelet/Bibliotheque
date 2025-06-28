using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheque.Models;

namespace Bibliotheque.Repositories
{
    public class AbonneRepository
    {
        private readonly BibliothequeContext _context;

        public AbonneRepository(BibliothequeContext context) 
        {
            _context = context;
        }

        public void AjouterAbonne (Abonne abonne)
        {
            _context.Abonnes.Add(abonne);
            _context.SaveChanges();
        }

        public Abonne? GetAbonneById(int id)
        {
            return _context.Abonnes.Find(id);
        }

        public void ModifierAbonne(Abonne abonne)
        {
            _context.Abonnes.Update(abonne);
            _context.SaveChanges();
        }

        public void SupprimerAbonne(int id)
        {
            Abonne abonne = _context.Abonnes.Find(id);
            if(abonne != null)
            {
                _context.Abonnes.Remove(abonne);
                _context.SaveChanges();
            }
        }
    }
}
