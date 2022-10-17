using Aranoz.Model;
using DataLayer.Aranoz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerAranoz
{
    public class SPCategoryManager
    {
      public List<CategoryModel> AllCategory()
        {
            CategoryData categories = new CategoryData();
            var allCategory = categories.GetCategory();
            return allCategory;
        }
    }
}
