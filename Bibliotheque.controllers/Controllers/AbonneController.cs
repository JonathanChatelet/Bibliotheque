using Microsoft.AspNetCore.Mvc;
using Bibliotheque.Models;
using Bibliotheque.Repositories;

namespace Bibliotheque.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AbonneController : ControllerBase
    {
        private readonly AbonneRepository _abonneRepository;

        public AbonneController(AbonneRepository abonneRepository)
        {
            _abonneRepository = abonneRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Abonne> Get(int id)
        {
            var abonne = _abonneRepository.GetAbonneById(id);
            if (abonne == null) return NotFound();
            return abonne;
        }

        [HttpPost]
        public IActionResult Create(Abonne abonne)
        {
            _abonneRepository.AjouterAbonne(abonne);
            return CreatedAtAction(nameof(Get), new { id = abonne.AbonneId }, abonne);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var statut = _abonneRepository.SupprimerAbonne(id);
            if (!statut) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Abonne abonne)
        {
            var statut = _abonneRepository.ModifierAbonne(abonne);
            if (!statut) return NotFound();
            return NoContent();
        }
    }
}
