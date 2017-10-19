using login_small.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace login_small.Data
{
    public class DbOperations
    {
        private loginlEntities db = new loginlEntities();

        public bool CheckUserCredentials(string username, string password)
        {
            
            var user = db.Person
                                 .Where(x => x.Username.Equals(username) && x.Password.Equals(password));
                                 //.Include(x => x.Roles);
            if (user.Any())
                return true;
            else
                return false;

            //if (username.Equals("eriobe") && password.Equals("test"))
            //    return true;
            //else
            //    return false;


        }
        public bool IsUserInRole(string userName, string roleName)
        {
            var role = db.Person
                 .Where(x => x.Username.Equals(userName))
                 .Include(x => x.Roles).Where(x => x.Roles.Role.Equals(roleName));

            return role.Any();
         }

    }
}