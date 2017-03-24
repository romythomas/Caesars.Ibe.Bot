using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.ServiceModel.HotelSearchResponse
{

    public class HotelSearchResponse
    {
        public Log[] Logs { get; set; }
        public Producttype[] ProductTypes { get; set; }
        public Request Request { get; set; }
        public object[] SearchDetails { get; set; }
    }

    public class Request
    {
        public object[] Features { get; set; }
        public object[] API { get; set; }
        public string AppKey { get; set; }
        public object CompanionSecurityToken { get; set; }
        public Criteria Criteria { get; set; }
        public object[] ExcludedSelectionAttributes { get; set; }
        public string GroupCode { get; set; }
        public object[] PackageRateModifiers { get; set; }
        public object[] PromotionRateModifiers { get; set; }
        public Quotespecification QuoteSpecification { get; set; }
        public string Requestor { get; set; }
        public string SecurityToken { get; set; }
        public Selectionattribute[] SelectionAttributes { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionStartTime { get; set; }
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
        public int Adults { get; set; }
        public int Children { get; set; }
    }

    public class Quotespecification
    {
        public int MaxQuotes { get; set; }
        public object[] QuotePrioritys { get; set; }
    }

    public class Selectionattribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Log
    {
        public DateTime CreationTime { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public string StatusName { get; set; }
    }

    public class Producttype
    {
        public bool Act { get; set; }
        public string ContentLink { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public object[] ProductAttributes { get; set; }
        public Product[] Products { get; set; }
    }

    public class Product
    {
        public string __type { get; set; }
        public object[] ASKU { get; set; }
        public bool Act { get; set; }
        public Attr[] Attr { get; set; }
        public object[] Chgs { get; set; }
        public int DisplayRank { get; set; }
        public int Id { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public Sku[] SKUs { get; set; }
        public bool UpAct { get; set; }
        public int CCW { get; set; }
        public string DEPAMOUNT { get; set; }
        public bool HasActiveResortFee { get; set; }
        public string HotelType { get; set; }
        public int MaxBookableNights { get; set; }
        public int MaxCompNights { get; set; }
        public string ResortFeeDisplay { get; set; }
        public string ContentLink { get; set; }
    }

    public class Location
    {
        public string __type { get; set; }
        public bool Act { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }
        public object Msg { get; set; }
        public string Name { get; set; }
        public object LMSPropCode { get; set; }
        public int PropertyId { get; set; }
        public object RevenueCenterId { get; set; }
        public string ContentLink { get; set; }
    }

    public class Attr
    {
        public bool Active { get; set; }
        public string DisplayName { get; set; }
        public string DisplayValue { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool INITVIS { get; set; }
    }

    public class Sku
    {
        public string __type { get; set; }
        public object AProd { get; set; }
        public object[] AUS { get; set; }
        public bool Act { get; set; }
        public string ContentLink { get; set; }
        public int DisplayRank { get; set; }
        public object[] GroupAvailabilityCalendar { get; set; }
        public int Id { get; set; }
        public object[] InventoryGroups { get; set; }
        public object[] InventoryItems { get; set; }
        public string Name { get; set; }
        public Productattribute[] ProductAttributes { get; set; }
        public Quote[] Quotes { get; set; }
        public object[] Rates { get; set; }
        public bool UpAct { get; set; }
        public string InventoryCode { get; set; }
        public string LMSPropCode { get; set; }
        public string RateSetCode { get; set; }
        public string EmailTemplateLink { get; set; }
    }

    public class Productattribute
    {
        public int Id { get; set; }
        public bool IsReference { get; set; }
    }

    public class Quote
    {
        public string __type { get; set; }
        public string Hash { get; set; }
        public object[] AC { get; set; }
        public object API { get; set; }
        public string Arr { get; set; }
        public bool B { get; set; }
        public DateTime CDT { get; set; }
        public string CTRN { get; set; }
        public DateTime EDT { get; set; }
        public object[] F { get; set; }
        public float Grand { get; set; }
        public int Id { get; set; }
        public Mrate[] MRates { get; set; }
        public float Original { get; set; }
        public QR[] QRS { get; set; }
        public object RM { get; set; }
        public object[] RMA { get; set; }
        public int SKUId { get; set; }
        public float SVNG { get; set; }
        public float Sub { get; set; }
        public float TAC { get; set; }
        public string TRN { get; set; }
        public int Type { get; set; }
        public float Avg { get; set; }
        public int LFee { get; set; }
        public int LOS { get; set; }
        public int LTax { get; set; }
        public float OriginalAvg { get; set; }
        public object RTCd { get; set; }
        public float TDT { get; set; }
        public float TNRF { get; set; }
        public float TRF { get; set; }
    }

    public class Mrate
    {
        public float Amt { get; set; }
        public string Date { get; set; }
        public string TXT { get; set; }
    }

    public class QR
    {
        public string __type { get; set; }
        public float Avg { get; set; }
        public float Fees { get; set; }
        public float Orig { get; set; }
        public float OriginalAvg { get; set; }
        public object[] RMA { get; set; }
        public Rate[] Rates { get; set; }
        public float SVNG { get; set; }
        public float Sub { get; set; }
        public float TAC { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
        public int Adults { get; set; }
        public float DAP { get; set; }
        public float DN { get; set; }
        public int Kids { get; set; }
        public float NRF { get; set; }
        public float RF { get; set; }
        public int Z { get; set; }
    }

    public class Rate
    {
        public string __type { get; set; }
        public float Amt { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }
        public float Orig { get; set; }
        public int QT { get; set; }
        public float SVNG { get; set; }
        public string TXT { get; set; }
        public bool B { get; set; }
    }


}
