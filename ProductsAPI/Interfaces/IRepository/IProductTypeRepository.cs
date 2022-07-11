using ProductsAPI.Models.Entities;
using System.Collections.Generic;

namespace ProductsAPI.Interfaces.IRepository
{
    public interface IProductTypeRepository
    {
        public IEnumerable<ProductType> GetProductTypes();

        public ProductType GetProductType(int Id);
    }
}
