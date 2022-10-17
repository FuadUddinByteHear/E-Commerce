using Aranoz.Model;
using Aranoz.Model.Model;
using DataLayer.Aranoz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerAranoz
{
   public class CartManager
    {
        public List<ProductModel> GetCartItem(List<SessionIdModel> idList) {
            List<ProductModel> cartProduct = new List<ProductModel>();
            List<SessionIdModel> IdList = new List<SessionIdModel>();
            ProductData data = new ProductData();
            IdList = idList;
            cartProduct = data.CartItem(IdList);
            return cartProduct;

        }
    }
}
