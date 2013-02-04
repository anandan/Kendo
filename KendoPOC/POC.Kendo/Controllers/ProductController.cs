using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Poc.Kendo.Controllers;
using Poc.WebApi.Models;

namespace Poc.Kendo
{
    public class ProductController : BaseController
    {
        public ProductViewModel _productVM;

        public ProductController()
        {

            _productVM = new ProductViewModel();
        }

        public ActionResult Index([DataSourceRequest]
                                  DataSourceRequest request, string button)
        {
            _productVM.ProductList = new List<Product>();
            _productVM.SelectedProduct = new Product();

            HttpResponseMessage response = this.ServiceClient.GetAsync(ApiResources.UnitOfMeasure).Result;
            
            if( response.IsSuccessStatusCode)
                _productVM.UnitOfMeasureList = response.Content.ReadAsAsync<IEnumerable<UnitofMeasure>>().Result;

            response = this.ServiceClient.GetAsync(ApiResources.ItemCategory).Result;

            if (response.IsSuccessStatusCode)
                _productVM.Categorylist = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            
            return View(_productVM);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public HttpResponseMessage SaveProducts(Product product, ProductViewModel productViewModel)
        {
            HttpResponseMessage response = this.ServiceClient.PostAsJsonAsync(ApiResources.Products, product).Result;
            response.Headers.Add("Accept", "application/json");
            return response;
        }

        public HttpResponseMessage DeleteProduct(int id)
        {
            return this.ServiceClient.DeleteAsync(ApiResources.Products).Result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public HttpResponseMessage DeleteProduct(Product product)
        {
            string uri = ApiResources.Products + @"\" + product.Id;
            HttpResponseMessage resnpose =  this.ServiceClient.DeleteAsync(uri).Result;
            return resnpose;
        }

        public ActionResult Products_Read([DataSourceRequest]
                                          DataSourceRequest request)
        {
            var result = Json(new DataSourceResult { Data = GetProducts() });
            return result;
        }

        private IEnumerable<Product> GetProducts()
        {
            HttpResponseMessage response = this.ServiceClient.GetAsync(ApiResources.Products).Result;  // Blocking call! 
            IEnumerable<Product> products = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            }

            return products;
        }
    }
}
