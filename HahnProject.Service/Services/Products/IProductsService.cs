using HahnProject.Domain.AggregatesModel.PersonAggregate;
using HahnProject.Domain.AggregatesModel.ProductsAggregate;

namespace HahnProject.Service
{
    public interface IProductsService
    {
        public List<Products> FindAll();
        public Products FindById(long id);
        public void Insert(Products item);
        public void Update(Products item);
        public void Delete(long id);
    }
}
