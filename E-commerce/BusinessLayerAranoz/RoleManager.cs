using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerSQL;
namespace BusinessLayerAranoz
{
   public class RoleManager
    {
        public static long AddNewPRole(string role)
        {
            MembershipSQLProvider provider = new MembershipSQLProvider();
            var productid = provider.AddnewRole(role);
            return productid;
        }
    }
}
