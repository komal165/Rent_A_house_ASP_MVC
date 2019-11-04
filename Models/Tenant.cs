using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_House.BusinessLayer
{
    //Tenant information
    public class Tenant
    {
        //Primary key.
        public int Id { get; set; }

        //Tenant name.
        public string Name { get; set; }

        //Tenant contact number 
        public string ContactNumber { get; set; }

        //Tenant regsitration ID 
        public string TenantRegistrationId {
            get
            {
                return "TEN00" + Id +"-"+Name;
            }

        }


    }
}
