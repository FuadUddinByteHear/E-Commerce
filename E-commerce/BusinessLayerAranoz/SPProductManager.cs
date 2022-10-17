using Aranoz.Model;
using DataLayer.Aranoz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerAranoz
{
    public class SPProductManager
    {
        ProductData data = new ProductData();
        public List<ProductModel> GetAlllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            products = data.GetAllProduct();
            return products;
        }

        public List<ProductModel> SpecificProduct(int Id)
        {
            List<ProductModel> items = new List<ProductModel>();
            items = data.GetSpecificProduct(Id);
            return items;

        }

    }
}
