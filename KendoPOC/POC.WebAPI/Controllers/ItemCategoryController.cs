using System.Collections.Generic;
using System.Web.Http;
using Poc.WebApi.Models;
using System.Linq;
using System.Data;
using System;

namespace Poc.WebApi
{
    public class ItemCategoryController : ApiController
    {
        //
        // GET: /Category/

        public ItemCategoryController()
        {
        }

        [HttpGet]
        public IEnumerable<Category> GetAllCategory()
        {
            KendoPOCEntities context = new KendoPOCEntities();

            return context.Category.AsEnumerable();
        }
    }
}
