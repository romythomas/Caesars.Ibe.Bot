using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.BusinessModel
{
    public class HotelSearchRequest
    {
        public string Market { get; set; }
        public string Property { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public string RoomCount { get; set; }
    }
}
