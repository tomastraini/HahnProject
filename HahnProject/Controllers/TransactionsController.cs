using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.TransactionAggregate;
using HahnProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        public ITransactionsService transactions;
        public TransactionsController(ITransactionsService transactions)
        {
            this.transactions = transactions;
        }
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
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            transactions.Insert(new Domain.AggregatesModel.TransactionAggregate.Transactions()
            {
                person = p.person
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyTransaction(TransactionR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
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
