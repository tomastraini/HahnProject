using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.ProductsAggregate;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public Products products = new Products();
        [HttpGet]
        public ActionResult getProducts()
        {
            return Ok(products.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult getProduct(long id)
        {
            return Ok(products.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertProduct(ProductsR p)
        {
            products.Insert(new Domain.AggregatesModel.PersonAggregate.Products()
            {
                ID = p.id,
                description = p.description,
                price = p.price,
                stock = p.stock,
                supplier = new Domain.AggregatesModel.ClientAggregate.Person()
                {
                    ID = p.supplier_id
                }
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyProduct(ProductsR p)
        {
            products.Update(new Domain.AggregatesModel.PersonAggregate.Products()
            {
                ID = p.id,
                description = p.description,
                price = p.price,
                stock = p.stock,
                supplier = new Domain.AggregatesModel.ClientAggregate.Person()
                {
                    ID = p.supplier_id
                }
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(long id)
        {
            products.Delete(id);
            return Ok();
        }
    }
}
