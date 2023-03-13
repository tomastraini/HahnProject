using HahnProject.Domain.AggregatesModel.ClientAggregate;
using HahnProject.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public Person person = new Person();
        [HttpGet]
        public ActionResult GetClients()
        {
            return Ok(person.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetClient(long id)
        {
            return Ok(person.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertClient(Person p)
        {
            person.Insert(p)
            return Ok();
        }
    }
}
