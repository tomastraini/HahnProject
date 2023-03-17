using HahnProject.API.RequestEntities;
using Microsoft.AspNetCore.Mvc;
using HahnProject.Domain.AggregatesModel.PersonAggregate;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTypeController : ControllerBase
    {
        public PersonType persontype = new PersonType();
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
            persontype.Insert(new Domain.AggregatesModel.PersonAggregate.PersonType()
            {
                type = p.type,
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyPersontype(PersonTypeR p)
        {
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
