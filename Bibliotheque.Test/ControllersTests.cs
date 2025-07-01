using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotheque.Controllers.Controllers;
using Bibliotheque.Models;
using Bibliotheque.Tools;
using Bibliotheque.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheque.Test
{
    public class ControllersTests
    {
        public AbonneController abonneController;
        public AuteurController auteurController;
        public EmpruntController empruntController;
        public LivreController livreController;

        public Abonne abonne;
        public Emprunt emprunt;
        public Auteur auteur;
        public Livre livre;

        public ControllersTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliothequeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new BibliothequeContext(optionsBuilder);

            abonneController = new AbonneController(new AbonneRepository(context));
            auteurController = new AuteurController(new AuteurRepository(context));
            empruntController = new EmpruntController(new EmpruntRepository(context));
            livreController = new LivreController(new LivreRepository(context));

            abonne = new Abonne();
            auteur = new Auteur();
            emprunt = new Emprunt();
            livre = new Livre();

            List<Livre> livres = new List<Livre>();
            List<Emprunt> emprunts = new List<Emprunt>();
            List<Auteur> auteurs = new List<Auteur>();

            auteurs.Add(auteur);
            livres.Add(livre);
            emprunts.Add(emprunt);

            auteur.AuteurId = 1;
            auteur.Nom = "Durand";
            auteur.Prenom = "Jean";
            auteur.DateNaissance = new DateOnly(1969, 02, 12);
            auteur.Nationalite = "Française";
            auteur.Livres = livres;


            livre.LivreId = 1;
            livre.Isbn = "051236845555";
            livre.Titre = "Le mal";
            livre.Editeur = "Pocket";
            livre.AnneePublication = 2012;
            livre.NbPage = 125;
            livre.Genre = "Policier";
            livre.Auteurs = auteurs;
            livre.Emprunts = emprunts;


            abonne.AbonneId = 1;
            abonne.Nom = "Dupont";
            abonne.Prenom = "Paul";
            abonne.Adresse = "10 Avenue Foch - 75001 PARIS";
            abonne.Email = "Dupont.Paul@gmail";
            abonne.Telephone = "0123456789";
            abonne.DateAbonnement = new DateOnly(2025, 06, 10);
            abonne.Emprunts = emprunts;

            emprunt.EmpruntId = 1;
            emprunt.AbonneId = 1;
            emprunt.LivreId = 1;
            emprunt.DateEmprunt = new DateOnly(2025, 06, 10);
            emprunt.DateRetour = new DateOnly(2025, 07, 10);
            emprunt.DateRetourEffective = null;
            emprunt.Statut = "En prêt";
            emprunt.Abonne = abonne;
            emprunt.Livre = livre;

            context.Auteurs.Add(auteur);
            context.Livres.Add(livre);
            context.Abonnes.Add(abonne);
            context.Emprunts.Add(emprunt);
            context.SaveChanges();

        }

        // Test de LivreController
        [Fact]
        public void AddLivreTest()
        {
            var newLivre = new Livre();
            newLivre.LivreId = 2;
            newLivre.Isbn = "22222222222";
            newLivre.Titre = "Le bien";
            newLivre.Editeur = "Larousse";
            newLivre.AnneePublication = 2020;
            newLivre.NbPage = 245;
            newLivre.Genre = "Romantique";

            var result = livreController.Create(newLivre);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsType<Livre>(actionResult.Value);
        }

        [Fact]
        public void ModifLivreTest()
        {
            livre.Isbn = "99999999999999";
            var result = livreController.Update(livre);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetLivreTest()
        {
            var result = livreController.Get(livre.LivreId);
            if (result.Result is OkObjectResult ok && ok.Value is Livre livreRecu)
            {
                Assert.Equal(livre.Titre, livreRecu.Titre);
            }
        }

        [Fact]
        public void SuprLivreTest()
        {
            var result = livreController.Delete(livre.LivreId);
            Assert.IsType<NoContentResult>(result);
        }

        // Test de AbonneController
        [Fact]
        public void AddAbonneTest()
        {
            var newAbonne = new Abonne();
            newAbonne.AbonneId = 2;
            newAbonne.Nom = "Watson";
            newAbonne.Prenom = "John";
            newAbonne.Adresse = "3 Rue Proust - 75009 PARIS";
            newAbonne.Email = "Watson.John@gmail";
            newAbonne.Telephone = "064585231";
            newAbonne.DateAbonnement = new DateOnly(2025, 06, 30);

            var result = abonneController.Create(newAbonne);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsType<Abonne>(actionResult.Value);
        }

        [Fact]
        public void ModifAbonneTest()
        {
            abonne.Telephone = "0987654321";
            var result = abonneController.Update(abonne);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetAbonneTest()
        {
            var result = abonneController.Get(abonne.AbonneId);
            if (result.Result is OkObjectResult ok && ok.Value is Abonne abonneRecu)
            {
                Assert.Equal(abonne.Telephone, abonneRecu.Telephone);
            }
        }

        [Fact]
        public void SuprAbonneTest()
        {
            var result = abonneController.Delete(abonne.AbonneId);
            Assert.IsType<NoContentResult>(result);
        }

        // Test de AuteurController
        [Fact]
        public void AddAuteurTest()
        {
            var newAuteur = new Auteur();
            newAuteur.AuteurId = 2;
            newAuteur.Nom = "Legrand";
            newAuteur.Prenom = "Jacques";
            newAuteur.DateNaissance = new DateOnly(1945, 05, 28);
            newAuteur.Nationalite = "Française";

            var result = auteurController.Create(newAuteur);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsType<Auteur>(actionResult.Value);
        }

        [Fact]
        public void ModifAuteurTest()
        {
            auteur.Nationalite = "Belge";
            var result = auteurController.Update(auteur);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetAuteurTest()
        {
            var result = auteurController.Get(auteur.AuteurId);
            if (result.Result is OkObjectResult ok && ok.Value is Auteur auteurRecu)
            {
                Assert.Equal(auteur.Nationalite, auteurRecu.Nationalite);
            }
        }

        [Fact]
        public void SuprAuteurTest()
        {
            var result = auteurController.Delete(auteur.AuteurId);
            Assert.IsType<NoContentResult>(result);
        }

        // Test de EmpruntController
        [Fact]
        public void AddEmpruntTest()
        {
            var newEmprunt = new Emprunt();
            newEmprunt.EmpruntId = 2;
            newEmprunt.AbonneId = 2;
            newEmprunt.LivreId = 2;
            newEmprunt.DateEmprunt = new DateOnly(2025, 06, 25);
            newEmprunt.DateRetour = new DateOnly(2025, 07, 25);
            newEmprunt.DateRetourEffective = null;
            newEmprunt.Statut = "En prêt";
            newEmprunt.Abonne = abonne;
            newEmprunt.Livre = livre;

            var result = empruntController.Create(newEmprunt);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsType<Emprunt>(actionResult.Value);
        }

        [Fact]
        public void ModifEmpruntTest()
        {
            emprunt.Statut = "En retard";
            var result = empruntController.Update(emprunt);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetEmpruntTest()
        {
            var result = empruntController.Get(emprunt.EmpruntId);
            if (result.Result is OkObjectResult ok && ok.Value is Emprunt empruntRecu)
            {
                Assert.Equal(emprunt.Statut, empruntRecu.Statut);
            }
        }

        [Fact]
        public void SuprEmpruntTest()
        {
            var result = empruntController.Delete(emprunt.EmpruntId);
            Assert.IsType<NoContentResult>(result);
        }
    }

}

