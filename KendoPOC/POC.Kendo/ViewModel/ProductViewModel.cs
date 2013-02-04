using System.Collections.Generic;
using Poc.WebApi.Models;

namespace Poc.Kendo 
{
    public class ProductViewModel
    {
        public IEnumerable<Product> ProductList { get; set; }

        public Product SelectedProduct { get; set; }

        public UnitofMeasure SelectedUnit { get; set; }

        public Category SelectedCategory { get; set; }

        public IEnumerable<Category> Categorylist { get; set; }

        public IEnumerable<UnitofMeasure> UnitOfMeasureList { get; set; }

        public ProductViewModel()
        {
        }

        public bool ShowForm { get; set; }
    }
}