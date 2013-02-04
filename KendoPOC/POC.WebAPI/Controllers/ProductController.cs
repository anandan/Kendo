using System.Collections.Generic;
using System.Web.Http;
using Poc.WebApi.Models;
using System.Linq;
using System.Data;
using System;

namespace Poc.WebApi
{
    public class ProductController : ApiController
    {
        public ProductController()
        {
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            KendoPOCEntities context = new KendoPOCEntities();

            var productsList = context.Product.Include("Category").Include("UnitofMeasure");
            //var productsList = context.Product;
            return productsList.AsEnumerable();
        }

        
        [HttpGet]
        public Product GetProductById(int id)
        {
            KendoPOCEntities context = new KendoPOCEntities();
            var result = context.Product.FirstOrDefault(item => item.Id == id);
            return result;
        }

        [HttpPost]
        public Product SaveProduct(Product product)
        {
            KendoPOCEntities context = new KendoPOCEntities();
            Product result = null;

            product.StatusType = 1;
            context.Entry<Product>(product).State = (product.Id == 0 ? EntityState.Added : EntityState.Modified);

            if (context.Entry<Product>(product).State == EntityState.Added)
            {
                product.CreationUserId = "SuperUser";
                product.CreationTs = DateTime.Now;
                context.Product.Add(product);
            }
            else
            {
                product.LastChangeUserId = "SuperUser";
                product.LastChangeTs = DateTime.Now;
            }
            int rowsAffected = context.SaveChanges();

            if (rowsAffected != 0)
            {
                result = product;
            }

            return result;
        }

        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            KendoPOCEntities context = new KendoPOCEntities();

            var product = new Product() { Id = id };

            context.Entry<Product>(product).State = EntityState.Deleted;
            int rowsAffected = context.SaveChanges();

            return (rowsAffected == 1);
        }
    }
}

