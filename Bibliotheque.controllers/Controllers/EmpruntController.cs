using Bibliotheque.Models;
using Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotheque.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpruntController : ControllerBase
    {
        private readonly EmpruntRepository _empruntRepository;

        public EmpruntController(EmpruntRepository empruntRepository)
        {
            _empruntRepository = empruntRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Emprunt> Get(int id)
        {
            var emprunt = _empruntRepository.GetEmpruntById(id);
            if (emprunt == null) return NotFound();
            return emprunt;
        }

        [HttpPost]
        public IActionResult Create(Emprunt emprunt)
        {
            _empruntRepository.AjouterEmprunt(emprunt);
            return CreatedAtAction(nameof(Get), new { id = emprunt.EmpruntId }, emprunt);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var statut = _empruntRepository.SupprimerEmprunt(id);
            if (!statut) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Emprunt emprunt)
        {
            var statut = _empruntRepository.ModifierEmprunt(emprunt);
            if (!statut) return NotFound();
            return NoContent();
        }
    }
}
