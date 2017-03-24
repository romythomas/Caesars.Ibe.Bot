using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Caesars.Ibe.Util;
using Newtonsoft.Json.Converters;

namespace Caesars.Ibe.Model.ServiceModel.HotelSearchRequest
{
    public class HotelSearchRequest
    {
        public Request request { get; set; }
    }

    public class Request
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string __type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object API { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string AppKey { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object CompanionSecurityToken { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Criteria Criteria { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object[] ExcludedSelectionAttributes { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string GroupCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object PackageRateModifiers { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object PromotionRateModifiers { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object QuoteSpecification { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Requestor { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string SecurityToken { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Selectionattribute[] SelectionAttributes { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object TransactionId { get; set; }
        //[JsonProperty(ItemConverterType = typeof(DateFormatHandling = DateFormatHandling.MicrosoftDateFormat), NullValueHandling = NullValueHandling.Include)]
        //[JsonProperty(ItemConverterType = DateFormatHandling.MicrosoftDateFormat)]
        public DateTime TransactionStartTime { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public object TransactionType { get; set; }
    }

    public class Criteria
    {
        public string __type { get; set; }
        public string[] Locations { get; set; }
        public string EndDate { get; set; }
        public Hotelroomdetail[] HotelRoomDetails { get; set; }
        public int[] LengthOfStays { get; set; }
        public string StartDate { get; set; }
    }

    public class Hotelroomdetail
    {
        public string __type { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
    }

    public class Selectionattribute
    {
        public string __type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

}
