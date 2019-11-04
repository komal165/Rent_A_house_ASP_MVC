using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_A_House.BusinessLayer
{
    //House imformation.
    public class House
    {
        //House primary key.
        public int Id { get; set; }

        //House Owner foriegn key.
        public int HouseOwnerId { get; set; }

        //House owner reference
        public HouseOwner HouseOwner { get; set; }

        //House owner address
        public string HouseAddress { get; set; }

        //House registration sequence Id 
        public string HouseRegistrationId {

            get { return "HOUSE00" + Id; }


        }


        //House name 
        public string HouseName
        {

            get { return "HOUSE00" + Id +"-"+ HouseAddress; }


        }



    }
}
