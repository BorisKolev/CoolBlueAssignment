using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models.DTos;
using ProductsAPI.Functionalities.ExtensionTests;
using ProductsAPI.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("productTypes")]
    public class ProductTypesController : Controller
    {
        private readonly IProductTypeRepository _repository;

        public ProductTypesController(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ProductTypeDto> GetProductTypes()
        {
            return _repository.GetProductTypes().Select(productType => productType.AsProductTypeDto());
        }

        [HttpGet("{Id}")]
        public ActionResult<ProductTypeDto> GetProductType(int Id)
        {
            var productType = _repository.GetProductType(Id);

            if(productType == null)
            {
                return NotFound();
            }

            return productType.AsProductTypeDto();
        }
    }
}
