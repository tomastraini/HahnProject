using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.PersonAggregate;
using HahnProject.Infrastructure;
using HahnProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IPersonService srv;
        public PersonController(IPersonService srv)
        {
            this.srv = srv;
        }
        [HttpGet]
        public ActionResult GetPerson()
        {
            return Ok(srv.FindAll());
        }

        [HttpGet("ByType")]
        public ActionResult GetPersonByType(long id)
        {
            return Ok(srv.FindAllByType(id));
        }


        [HttpGet("{id}")]
        public ActionResult GetPeople(long id)
        {
            return Ok(srv.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertPerson(PersonR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            srv.Insert(new Person()
            { 
                business_name = p.business_name,
                balance = p.balance,
                persontype = new Domain.AggregatesModel.PersonAggregate.PersonType()
                {
                    ID = p.person_type
                }
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyPerson(PersonR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            srv.Update(new Person()
            {
                ID = p.ID,
                business_name = p.business_name,
                balance = p.balance,
                persontype = new Domain.AggregatesModel.PersonAggregate.PersonType()
                {
                    ID = p.person_type
                }
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult ModifyPerson(long id)
        {
            srv.Delete(id);
            return Ok();
        }
    }
}
