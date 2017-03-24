using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.BusinessModel
{
    public class MarketPropertyContent
    {
        public List<PropertyContent> PropertyContents { get; set; }
    }
    public class PropertyContent
    {
        public string PropertyCode { get; set; }
        public string PropertyName { get; set; }
        public string Market { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
    }
}
