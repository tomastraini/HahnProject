using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.TransactionAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        public Transactions transactions = new Transactions();
        [HttpGet]
        public ActionResult GetTransactions()
        {
            return Ok(transactions.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetTransaction(long id)
        {
            return Ok(transactions.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertTransaction(TransactionR p)
        {
            transactions.Insert(new Domain.AggregatesModel.TransactionAggregate.Transactions()
            {
                ID = p.ID,
                person = p.person,
                total = p.total,
                transaction_began = p.transaction_began
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyTransaction(TransactionR p)
        {
            transactions.Update(new Transactions()
            {
                ID = p.ID,
                person = p.person,
                total = p.total,
                transaction_began = p.transaction_began
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult ModifyTransaction(long id)
        {
            transactions.Delete(id);
            return Ok();
        }
    }
}
