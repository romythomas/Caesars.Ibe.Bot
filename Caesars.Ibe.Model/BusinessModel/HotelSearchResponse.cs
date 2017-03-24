using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.BusinessModel
{
    public class HotelSearchResponse
    {
        public List<Property> properties { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public List<Room> Rooms { get; set; }
    }

    public class Room
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public float AvgRate { get; set; }
    }
}
