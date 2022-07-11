using Newtonsoft.Json;
using ProductsAPI.Constants;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private List<Product> Products { get; set; }

        public ProductRepository()
        {
            DeserializeData();
        }

        public override void DeserializeData()
        {
            Products = JsonConvert.DeserializeObject<List<Product>>
                        (File.ReadAllText(FilePaths.productJsonPath));
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public Product GetProduct(int Id)
        {
            return Products.Where(product => product.Id == Id).SingleOrDefault();
        }
    }
}
