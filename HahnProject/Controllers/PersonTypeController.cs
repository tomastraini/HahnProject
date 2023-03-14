using HahnProject.API.RequestEntities;
using Microsoft.AspNetCore.Http;
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
        public ActionResult GetClients()
        {
            return Ok(persontype.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetClient(long id)
        {
            return Ok(persontype.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertClient(PersonTypeR p)
        {
            persontype.Insert(new Domain.AggregatesModel.PersonAggregate.PersonType()
            {
                type = p.type,
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyClient(PersonTypeR p)
        {
            persontype.Update(new PersonType()
            {
                ID = p.ID,
                type = p.type,
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult ModifyClient(long id)
        {
            persontype.Delete(id);
            return Ok();
        }
    }
}
