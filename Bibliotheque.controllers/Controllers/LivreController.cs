using Bibliotheque.Models;
using Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheque.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivreController : ControllerBase
    {
        private readonly LivreRepository _livreRepository;

        public LivreController(LivreRepository livreRepository)
        {
            _livreRepository = livreRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Livre> Get(int id)
        {
            var livre = _livreRepository.GetLivreById(id);
            if (livre == null) return NotFound();
            return livre;
        }

        [HttpPost]
        public IActionResult Create(Livre livre)
        {
            _livreRepository.AjouterLivre(livre);
            return CreatedAtAction(nameof(Get), new { id = livre.LivreId }, livre);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var statut = _livreRepository.SupprimerLivre(id);
            if (!statut) return NotFound();
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Livre livre)
        {
            var statut = _livreRepository.ModifierLivre(livre.LivreId, livre);
            if (!statut) return NotFound();
            return NoContent();
        }
    }
}
