using Microsoft.AspNetCore.Mvc;
using Models.Product;
using NTA.Extensions;
using Services.Product;
using System.Collections.Generic;

namespace FeatureApp.UI.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await productService.GetAllProductsAsync();

                return View(products);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<IActionResult> AddAsync()
        {
            try
            {
               var htm =  new { html = await this.RenderViewAsync("_AddProduct", new ProductModel(), true) };

                return Json(htm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(ProductModel productModel)
        {
            try
            {
                //if (categoryDto.Id > 0)
                //    await _categoryRepo.UpdateAsync(productModel);
                //else
                    await productService.AddProductAsync(productModel);

                return RedirectToAction(nameof(GetAllProducts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
