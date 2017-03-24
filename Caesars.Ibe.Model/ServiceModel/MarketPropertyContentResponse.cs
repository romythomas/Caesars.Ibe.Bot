using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.ServiceModel.MarketPropertyContentResponse
{
    public class MarketPropertyContentResponse
    {
        //public Class1[] Property1 { get; set; }
        public string id { get; set; }
        public string marketCode { get; set; }
        public string brand { get; set; }
        public string url { get; set; }
        public string mapUrl { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public Location location { get; set; }
        public Social social { get; set; }
        public string hotel { get; set; }
        public Facts facts { get; set; }
        public Logo logo { get; set; }
        public Image[] images { get; set; }
        public Logos logos { get; set; }
        public Outage outage { get; set; }
        public string name { get; set; }
        public string propertyName { get; set; }
        public string property { get; set; }
        public string market { get; set; }
        public int propertyRank { get; set; }
        public int marketRank { get; set; }
        public Featuredimage featuredImage { get; set; }
        public string summary { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string[] youtubeVideos { get; set; }
    }

    //public class Class1
    //{
    //    public string id { get; set; }
    //    public string marketCode { get; set; }
    //    public string brand { get; set; }
    //    public string url { get; set; }
    //    public string mapUrl { get; set; }
    //    public Address address { get; set; }
    //    public string phone { get; set; }
    //    public Location location { get; set; }
    //    public Social social { get; set; }
    //    public string hotel { get; set; }
    //    public Facts facts { get; set; }
    //    public Logo logo { get; set; }
    //    public Image[] images { get; set; }
    //    public Logos logos { get; set; }
    //    public Outage outage { get; set; }
    //    public string name { get; set; }
    //    public string propertyName { get; set; }
    //    public string property { get; set; }
    //    public string market { get; set; }
    //    public int propertyRank { get; set; }
    //    public int marketRank { get; set; }
    //    public Featuredimage featuredImage { get; set; }
    //    public string summary { get; set; }
    //    public Thumbnail thumbnail { get; set; }
    //    public string[] youtubeVideos { get; set; }
    //}

    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float minLatitude { get; set; }
        public float maxLatitude { get; set; }
        public float minLongitude { get; set; }
        public float maxLongitude { get; set; }
    }

    public class Social
    {
        public string twitter { get; set; }
        public string foursquare { get; set; }
        public string massRelevanceHashTags { get; set; }
        public string massRelevanceStreamId { get; set; }
    }

    public class Facts
    {
        public string body { get; set; }
        public List[] list { get; set; }
    }

    public class List
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Logo
    {
        public string url { get; set; }
    }

    public class Logos
    {
        public Darksquare darkSquare { get; set; }
        public Darkwide darkWide { get; set; }
        public Lightsquare lightSquare { get; set; }
        public Lightwide lightWide { get; set; }
    }

    public class Darksquare
    {
        public string url { get; set; }
    }

    public class Darkwide
    {
        public string url { get; set; }
    }

    public class Lightsquare
    {
        public string url { get; set; }
    }

    public class Lightwide
    {
        public string url { get; set; }
    }

    public class Outage
    {
        public bool isAlways { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Featuredimage
    {
        public string url { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string title { get; set; }
    }

}
