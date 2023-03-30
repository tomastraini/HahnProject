using HahnProject.Domain.AggregatesModel.PersonAggregate;
using HahnProject.Domain.AggregatesModel.ProductsAggregate;

namespace HahnProject.Service
{
    public class ProductsService : IProductsService
    {
        public Products p = new Products();

        public List<Products> FindAll()
        {
            return p.FindAll();
        }
        public Products FindById(long id)
        {
            return p.FindById(id);
        }
        public void Insert(Products item)
        {
            p.Insert(item);
        }
        public void Update(Products item)
        {
            p.Update(item);
        }
        public void Delete(long id)
        {
            p.Delete(id);
        }
    }
}
