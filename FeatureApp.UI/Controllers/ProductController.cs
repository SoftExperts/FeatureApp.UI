using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Product;
using NTA.Extensions;
using Services.Product;

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
                var products = await productService.GetAllAsync();

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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid productId)
        {
            try
            {
                var product = await this.productService.GetById(productId);
                var htm = new { html = await this.RenderViewAsync("_AddProduct", product, true) };

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
                if (productModel.Id == Guid.Empty)
                    await productService.AddAsync(productModel);
                else
                    await productService.UpdateAsync(productModel);

                return RedirectToAction(nameof(GetAllProducts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> DeleteConfirmation(Guid idToDelete)
        {
            try
            {
                return Json(new { html = await this.RenderViewAsync("_DeleteConfirmationModal", new DeleteConfirmModel() { IdToDelete = idToDelete, Controller = "Product", Action = "Delete" }, true) });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Json(new { success = false });
                
                await productService.DeleteAsync(id);

                return Json(new { success = true, redirectUrl = nameof(GetAllProducts) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
