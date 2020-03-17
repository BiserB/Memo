using Memo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Services
{
    public class VenueService
    {
        public async Task<IList<Venue>> GetVenuesAsync(double latitude, double longitude)
        {
            var url = VenueBase.GenerateURL(latitude, longitude);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<VenueBase>(json);

                return result.Response.Venues;
            }            
        }
    }
}
