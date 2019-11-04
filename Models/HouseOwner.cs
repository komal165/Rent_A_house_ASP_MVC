using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_House.BusinessLayer
{
    //House owner information
    public class HouseOwner
    {
        //Primary key.
        public int Id { get; set; }

        //House owner name
        public  string Name{get; set;}


        //House owner regsitration id 
        public string HouseOwnerRegistrationId {
            get { return "HOW00" + Id +"-"+Name; }


        }


        //House owner contact number.
        public string ContactNumber { get; set; }



    }
}
