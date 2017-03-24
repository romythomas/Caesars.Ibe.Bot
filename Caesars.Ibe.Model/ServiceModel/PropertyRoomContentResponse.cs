using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.ServiceModel.PropertyRoomContentResponse
{
    public class PropertyRoomContentResponse
    {
        //public Class1[] Property1 { get; set; }
        public string rateSet { get; set; }
        public string bookingUrl { get; set; }
        public object[] virtualTour { get; set; }
        public bool hidden { get; set; }
        public Amenities amenities { get; set; }
        public string availabilityMessage { get; set; }
        public Image[] images { get; set; }
        public string name { get; set; }
        public string propertyName { get; set; }
        public string property { get; set; }
        public string market { get; set; }
        public int propertyRank { get; set; }
        public int marketRank { get; set; }
        public string summary { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string[] youtubeVideos { get; set; }
        public string callInfo { get; set; }
        public Featuredimage featuredImage { get; set; }
    }

    //public class Class1
    //{
    //    public string rateSet { get; set; }
    //    public string bookingUrl { get; set; }
    //    public object[] virtualTour { get; set; }
    //    public bool hidden { get; set; }
    //    public Amenities amenities { get; set; }
    //    public string availabilityMessage { get; set; }
    //    public Image[] images { get; set; }
    //    public string name { get; set; }
    //    public string propertyName { get; set; }
    //    public string property { get; set; }
    //    public string market { get; set; }
    //    public int propertyRank { get; set; }
    //    public int marketRank { get; set; }
    //    public string summary { get; set; }
    //    public Thumbnail thumbnail { get; set; }
    //    public string[] youtubeVideos { get; set; }
    //    public string callInfo { get; set; }
    //    public Featuredimage featuredImage { get; set; }
    //}

    public class Amenities
    {
        public Service[] services { get; set; }
        public Bathroom[] bathroom { get; set; }
        public Misc[] misc { get; set; }
        public Electronic[] electronics { get; set; }
        public Room[] room { get; set; }
    }

    public class Service
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Bathroom
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Misc
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Electronic
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Room
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
    }

    public class Featuredimage
    {
        public string url { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public string title { get; set; }
    }

}
