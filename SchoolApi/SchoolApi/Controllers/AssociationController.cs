using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Services;
using System.Collections.Generic;

//Add doc: https://docs.microsoft.com/fr-fr/aspnet/core/web-api/?view=aspnetcore-3.0#attributes

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociationController : ControllerBase
    {
        private readonly AssociationService _assoService;

        public AssociationController(AssociationService assoService)
        {
            _assoService = assoService;
        }

        //GET /api/associations
        [HttpGet]
        public ActionResult<List<Association>> Get() =>
            _assoService.Get();

        //GET /api/associations/{id}
        [HttpGet("{id:length(24)}", Name = "GetAssociation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Association> Get(string id)
        {
            var asso = _assoService.Get(id);

            if (asso == null)
            {
                return NotFound();
            }

            return asso;
        }

        //POST /api/associations
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Association> Create(Association asso)
        {
            _assoService.Create(asso);

            return CreatedAtRoute("GetAssociation", new { id = asso.Id.ToString() }, asso);
        }

        //PUT /api/associations/{id}
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(string id, Association assoIn)
        {
            var asso = _assoService.Get(id);

            if (asso == null)
            {
                return NotFound();
            }

            _assoService.Update(id, assoIn);

            return NoContent();
        }

        //DELETE /api/associations/{id}
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(string id)
        {
            var asso = _assoService.Get(id);

            if (asso == null)
            {
                return NotFound();
            }

            _assoService.Remove(asso.Id);

            return NoContent();
        }
    }
}