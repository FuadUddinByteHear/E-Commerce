using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aranoz.Model;
using  Aranoz.Model.Model;
using DataLayerSQL;
namespace BusinessLayerAranoz
{
    public class CategoryManager
    {
        public static long AddNewCategory(CategoryModel category)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categorytid = provider.AddNewCategory(category);
            return Categorytid;
        }
        public static List<CategoryModel> GetAllCategory()
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.ViewAllCategory();
            return Categoriesd;
        }
        public static bool UpdateCategory(CategoryModel category)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.UpdateCategory(category);
            return Categoriesd;
        }
        public static CategoryModel GetSingleCategory(int categoryId)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.GetSingleCategory(categoryId);
            return Categoriesd;
        }
        public static bool DeleteCategory(int categoryId)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.DeleteCategory(categoryId);
            return Categoriesd;
        }
    }
}
