using AutoMapper;
using domain.Materials;
using Microsoft.AspNetCore.Mvc;
using persistence.Materials;
using System.Diagnostics;
using System.Net;

namespace api.Controllers.Materials
{
    public class ConcreteController : BaseMaterialController
    {
        private readonly IConcreteRepository _repository;
        private readonly IMapper _mapper;

        public ConcreteController(
            IConcreteRepository categoryRepository,
            IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Concrete>))]
        public IActionResult GetAll()
        {
            var entries = _repository.GetAll();
            var mappedEntries = _mapper.Map<List<ConcreteDTO>>(entries);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(mappedEntries);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Concrete))]
        [ProducesResponseType(400)]
        public IActionResult Get(string name)
        {
            string decodedName = WebUtility.UrlDecode(name); // needed because the name has "/" in it. e.g. "C20/25"

            if (!_repository.Exists(decodedName)) return NotFound();

            var entry = _repository.Get(decodedName);
            var mappedEntry = _mapper.Map<ConcreteDTO>(entry);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(mappedEntry);
        }

        [HttpPut("{name}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Update(
            string className,
            [FromBody] ConcreteDTO mappedEntry)
        {
            if (mappedEntry == null) return BadRequest(ModelState);

            if (className != mappedEntry.Class) return BadRequest(ModelState);

            if (!_repository.Exists(className)) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            var entry = _mapper.Map<Concrete>(mappedEntry);

            if (!_repository.Update(entry))
            {
                ModelState.AddModelError("", $"Something went wrong updating {className}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}