using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_House.BusinessLayer
{
    //Contract information.
    public class Contract
    {
        //Contract Id
        public int Id { get; set; }

        //House Id foriegn key
        public int HouseId { get; set; }

        //Tenant Id foriegn key.
        public int TenantId { get; set; }

        //Reference to House
        public House House { get; set; }

        //Reference to Tenant
        public Tenant Tenant { get; set; }

        //Rent amount per week
        public decimal RentPerWeek { get; set; }

    }
}
