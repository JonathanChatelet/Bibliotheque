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
            var optionsBuilder = new DbContextOptionsBuilder<BibliothequeContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestBibliotheque");

            var context = new BibliothequeContext(optionsBuilder.Options);

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


            livre.LivreId = 2;
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
            emprunt.Statut = "Normal";
            emprunt.Abonne = abonne;
            emprunt.Livre = livre;

        }

        [Fact]
        public void AddLivreTest()
        {
            var result = livreController.Create(livre);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdLivre = Assert.IsType<Livre>(actionResult.Value);
            Assert.Equal(livre.LivreId, createdLivre.LivreId);
        }

        [Fact]
        public void ModifLivrTest()
        {
            livre.Isbn = "22222222222";
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
    }

}

