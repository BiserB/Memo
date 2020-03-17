using Memo.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memo.Models
{
    public class VenueBase
    {
        public Response Response { get; set; }

        public static string GenerateURL(double latitude, double longitude)
        {
            return string.Format(AppConst.VenueSearch, latitude, longitude, AppConst.ClientId, AppConst.ClientSecret, DateTime.UtcNow.ToString("yyyyMMdd"));
        }
    }

    public class Venue
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public IList<Category> Categories { get; set; }        
    }

    public class Response
    {
        public IList<Venue> Venues { get; set; }
    }

    public class Location
    {
        public string Address { get; set; }

        public string CrossStreet { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public int Distance { get; set; }

        public string PostalCode { get; set; }

        public string Cc { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public IList<string> FormattedAddress { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PluralName { get; set; }

        public string ShortName { get; set; }

        public bool Primary { get; set; }
    }
}
