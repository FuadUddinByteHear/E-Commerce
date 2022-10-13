using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web;
namespace DataLayerSQL
{
    public class MembershipSQLProvider : /*DbContext*/
    {

        public int AddnewRole(string rolename)
        {
            var conncetion=WebSecurity.InitializeDatabaseConnection("DBConnection", "UserProfile", "UserId", "UserName");
            var added = 0;
            try
            {
                Membership.CreateUser("fuad", "fuad");
                Roles.CreateRole(rolename);
                if (!Roles.RoleExists(rolename))
                {
                    Roles.CreateRole(rolename);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Message"+e);
            }
          
            //application
            //Roles.ApplicationName("admin");

            //if (!Roles.RoleExists())
            //{
            //    Roles.CreateRole(rolename);
            //    added = 1;
            //}

            //object p = Roles.ApplicationName(login);
            //var role=Roles.CreateRole(rolename);
            return added;
        }

    }
}
