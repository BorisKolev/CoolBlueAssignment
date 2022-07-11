using ProductsAPI.Models.Entities;
using System.Collections.Generic;

namespace ProductsAPI.Interfaces.IRepository
{
    public interface IProductRepository
    {

        public IEnumerable<Product> GetProducts();

        public Product GetProduct(int Id);

    }
}
