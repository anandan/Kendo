using System.Collections.Generic;
using System.Web.Http;
using Poc.WebApi.Models;
using System.Linq;
using System.Data;
using System;

namespace Poc.WebApi
{
    public class UnitOfMeasureController : ApiController
    {
        //
        // GET: /UnitOfMeasure/

        public UnitOfMeasureController()
        {
        }

        [HttpGet]
        public IEnumerable<UnitofMeasure> GetAllunits()
        {
            KendoPOCEntities context = new KendoPOCEntities();

            return context.UnitofMeasure.AsEnumerable();
        }
    }
}
