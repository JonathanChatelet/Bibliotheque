using Bibliotheque.Models;
using Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheque.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuteurController : ControllerBase
    {
        private readonly AuteurRepository _auteurRepository;

        public AuteurController(AuteurRepository auteurRepository)
        {
            _auteurRepository = auteurRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Auteur> Get(int id)
        {
            var auteur = _auteurRepository.GetAuteurById(id);
            if (auteur == null) return NotFound();
            return auteur;
        }

        [HttpPost]
        public IActionResult Create(Auteur auteur)
        {
            _auteurRepository.AjouterAuteur(auteur);
            return CreatedAtAction(nameof(Get), new { id = auteur.AuteurId }, auteur);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var statut = _auteurRepository.SupprimerAuteur(id);
            if (!statut) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Auteur auteur)
        {
            var statut = _auteurRepository.ModifierAuteur(auteur);
            if (!statut) return NotFound();
            return NoContent();
        }
    }
}
