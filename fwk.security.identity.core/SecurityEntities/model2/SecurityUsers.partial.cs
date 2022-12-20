
using System;
using System.Collections.Generic;
using System.Linq;
namespace fwk.security.identity.core
{
    public partial class SecurityUsers
    {
        public List<String> GetRolesArray()
        {
            List<String> roles = new List<String>();
            //if (this.SecurityRoles != null)
            //{
            //    if (this.SecurityRoles.Count != 0)
            //    {
            //        roles = new List<String>();
            //        SecurityRoles.ToList().ForEach(r =>
            //        {
            //            roles.Add(r.Name);
            //        });
            //    }
            //}
            if (this.SecurityUserRoles != null)
            {


                this.SecurityUserRoles.ToList().ForEach(r =>
                {
                    roles.Add(r.Role.Name);
                });

            }
            return roles;
        }
    }
}