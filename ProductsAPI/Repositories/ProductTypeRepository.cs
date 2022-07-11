using Newtonsoft.Json;
using ProductsAPI.Constants;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductsAPI.Repositories
{
    public class ProductTypeRepository : BaseRepository, IProductTypeRepository
    {
        private List<ProductType> ProductTypes { get; set; }

        public ProductTypeRepository()
        {
            DeserializeData();
        }

        public override void DeserializeData()
        {
            ProductTypes = JsonConvert.DeserializeObject<List<ProductType>>
            (File.ReadAllText(FilePaths.productTypesPath));
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return ProductTypes;
        }

        public ProductType GetProductType(int Id)
        {
            return ProductTypes.Where(product => product.Id == Id).SingleOrDefault();
        }

    }
}
