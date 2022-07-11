using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models.DTos;
using ProductsAPI.Functionalities.ExtensionTests;
using ProductsAPI.Interfaces.IFunctionalities;
using ProductsAPI.Interfaces.IRepository;
using ProductsAPI.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAPI.Controllers
{
    [ ApiController ]
    [ Route("products") ]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IInsuranceLookUps _insuranceLookUps;
        public ProductsController(IProductRepository repository,
                                 IInsuranceLookUps insuranceLookUps)
        {
            _repository = repository;
            _insuranceLookUps = insuranceLookUps;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            return _repository.GetProducts().Select(product => product.AsProductDto());
        }

        [HttpGet("{Id}")]
        public ActionResult<ProductDto> GetProduct(int Id)
        {
            var product = _repository.GetProduct(Id);

            if (product == null)
            {
                return NotFound();
            }

            return product.AsProductDto();
        }

        [HttpGet("{Id}/Insurance")]
        public ActionResult<ProductInsuranceDto> GetProductInsurance(int Id)
        {
            var product = _repository.GetProduct(Id);

            if(product == null)
            {
                return NotFound();
            }
            
            if(!_insuranceLookUps.IsProductTypeInsurable(Id))
            {
                return Ok(InsuranceTypes.NonInsurable.ToString());
            }

            var insurance = _insuranceLookUps.CreateInsurance(Id);
            return insurance.AsProductInsuranceDto();
        }

    }
}
