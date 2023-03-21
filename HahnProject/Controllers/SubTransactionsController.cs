using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.TransactionAggregate;
using HahnProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTransactionsController : ControllerBase
    {
        public ISubTransactionsService SubTransactions;
        public SubTransactionsController(ISubTransactionsService SubTransactions)
        {
            this.SubTransactions = SubTransactions;
        }
        [HttpGet]
        public ActionResult GetSubTransactions()
        {
            return Ok(SubTransactions.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetSubTransactions(long id)
        {
            return Ok(SubTransactions.FindById(id));
        }

        [HttpPost]
        public ActionResult PostSubTransactions(SubTransactionR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            SubTransactions.Insert(new Domain.AggregatesModel.TransactionAggregate.SubTransactions()
            {
                product_id = p.product_id,
                transaction_id = p.transaction_id,
                amount = p.amount
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifySubTransactions(SubTransactionR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            SubTransactions.Update(new Domain.AggregatesModel.TransactionAggregate.SubTransactions()
            {
                ID = p.ID,
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteSubTransactions(long id)
        {
            SubTransactions.Delete(id);
            return Ok();
        }
    }
}
