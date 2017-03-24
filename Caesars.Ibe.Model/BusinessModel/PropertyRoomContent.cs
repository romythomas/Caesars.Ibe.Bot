using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.BusinessModel
{
    public class PropertyRoomContent
    {
        public string PropertyCode { get; set; }
        public string PropertyName { get; set; }
        public string Market { get; set; }
        public List<RoomContent> RoomContents { get; set; }
    }

    public class RoomContent
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Summary { get; set; }
    }
}
