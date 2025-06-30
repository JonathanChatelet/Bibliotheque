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

        public bool ModifierAbonne(Abonne abonne)
        {
            var abonneExistant = _context.Abonnes.Find(abonne.AbonneId);

            if (abonneExistant == null)
                return false;

            abonneExistant.Nom = abonne.Nom;
            abonneExistant.Prenom = abonne.Prenom;
            abonneExistant.Adresse = abonne.Adresse;
            abonneExistant.DateAbonnement = abonne.DateAbonnement;
            abonneExistant.Email = abonne.Email;
            abonneExistant.Telephone = abonne.Telephone;
            abonneExistant.Emprunts = abonne.Emprunts;

            _context.SaveChanges();
            return true;
        }

        public bool SupprimerAbonne(int id)
        {
            Abonne abonne = _context.Abonnes.Find(id);
            if(abonne == null) return false;
            _context.Abonnes.Remove(abonne);
            _context.SaveChanges();
            return true;
        }
    }
}
