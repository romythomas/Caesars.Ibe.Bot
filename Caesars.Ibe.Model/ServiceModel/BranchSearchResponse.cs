using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.ServiceModel.BranchSearchResponse
{
    public class BranchSearchResponse
    {
        public Getbranchesresult[] GetBranchesResult { get; set; }
    }

    public class Getbranchesresult
    {
        public bool Act { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public object Msg { get; set; }
        public string Name { get; set; }
        public Parentlocation ParentLocation { get; set; }
        public string LMSPropCode { get; set; }
        public int PropertyId { get; set; }
        public string RevenueCenterId { get; set; }
        public string ContentLink { get; set; }
    }

    public class Parentlocation
    {
        public string __type { get; set; }
        public bool Act { get; set; }
        public string Code { get; set; }
        public string ContentLink { get; set; }
        public string Description { get; set; }
        public Geolocation GeoLocation { get; set; }
        public int Id { get; set; }
        public string Msg { get; set; }
        public string Name { get; set; }
        public Parentlocation1 ParentLocation { get; set; }
        public object[] Properties { get; set; }
        public object Venues { get; set; }
    }

    public class Geolocation
    {
        public object City { get; set; }
        public int Id { get; set; }
        public Latitude Latitude { get; set; }
        public Longitude Longitude { get; set; }
        public object State { get; set; }
    }

    public class Latitude
    {
        public int Degress { get; set; }
        public int Direction { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }

    public class Longitude
    {
        public int Degress { get; set; }
        public int Direction { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }

    public class Parentlocation1
    {
        public bool Act { get; set; }
        public string Code { get; set; }
        public string ContentLink { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public object Msg { get; set; }
        public string Name { get; set; }
        public Parentlocation2 ParentLocation { get; set; }
    }

    public class Parentlocation2
    {
        public bool Act { get; set; }
        public string Code { get; set; }
        public string ContentLink { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public object Msg { get; set; }
        public string Name { get; set; }
        public Parentlocation3 ParentLocation { get; set; }
    }

    public class Parentlocation3
    {
        public bool Act { get; set; }
        public string Code { get; set; }
        public string ContentLink { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public object Msg { get; set; }
        public string Name { get; set; }
    }

}
