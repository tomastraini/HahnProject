using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.ProductsAggregate;
using HahnProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductsService products;
        public ProductsController(IProductsService products)
        {
            this.products = products;
        }
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
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            products.Insert(new Domain.AggregatesModel.ProductsAggregate.Products()
            {
                ID = p.id,
                description = p.description,
                price = p.price,
                stock = p.stock,
                supplier = new Domain.AggregatesModel.PersonAggregate.Person()
                {
                    ID = p.supplier_id
                }
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyProduct(ProductsR p)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            products.Update(new Domain.AggregatesModel.ProductsAggregate.Products()
            {
                ID = p.id,
                description = p.description,
                price = p.price,
                stock = p.stock,
                supplier = new Domain.AggregatesModel.PersonAggregate.Person()
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
