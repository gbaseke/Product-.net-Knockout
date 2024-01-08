using Microsoft.AspNetCore.Mvc;
using Test.Contracts;
using Test.Entities;
using Test.Models;

namespace Test.Controllers;
public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductRepository _productRepository;
    public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public ActionResult Index()
    {
        return View();
    }

    public JsonResult GetAllProducts()
    {
        return Json(_productRepository.GetAll());
    }

    [HttpPost]
    public JsonResult AddProduct([FromBody] ProductViewModel item)
    {
        if (ModelState.IsValid)
        {
            Product product = item.To();
            product = _productRepository.Add(product);
            return Json(product);
        }

        return Json(null);
    }

    [HttpPut]
    public JsonResult EditProduct(int id, [FromBody]ProductViewModel vm)
    {   
        if (ModelState.IsValid)
        {
            vm.Id = id;
            var product = vm.To();
            if (_productRepository.Update(product))
            {
                return Json(vm);
            }
        }

        return Json(null);
    }

    [HttpDelete]
    public JsonResult DeleteProduct(int id)
    {
        if (_productRepository.Delete(id))
        {
            return Json(new { Status = true });
        }

        return Json(new { Status = false });
    }
}