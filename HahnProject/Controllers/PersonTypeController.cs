using HahnProject.API.RequestEntities;
using Microsoft.AspNetCore.Mvc;
using HahnProject.Domain.AggregatesModel.PersonAggregate;
using HahnProject.Service;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypeController : ControllerBase
    {
        public IPersonTypeService persontype;
        public PersonTypeController(IPersonTypeService persontype)
        {
            this.persontype = persontype;
        }
        [HttpGet]
        public ActionResult GetPersontypes()
        {
            return Ok(persontype.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetPersontype(long id)
        {
            return Ok(persontype.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertPersontype(PersonTypeR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            persontype.Insert(new Domain.AggregatesModel.PersonAggregate.PersonType()
            {
                type = p.type,
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyPersontype(PersonTypeR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            persontype.Update(new PersonType()
            {
                ID = p.ID,
                type = p.type,
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeletePersontype(long id)
        {
            persontype.Delete(id);
            return Ok();
        }
    }
}
