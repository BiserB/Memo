using System;
using System.Collections.Generic;
using System.Text;

namespace Memo.Common
{
    public class AppConst
    {
        public const string NoteDateFormat = @"dd/MM/yyyy - H:mm";

        public const string VenueSearch = @"https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";

        public static string ClientId = @"LV2FH2T2TPHZV50UMHRP4NNRXWEJTI1BLOY1UTIFOEKH1215";

        public static string ClientSecret = @"0GVMDX42A4C0PKDEIRXKO11N134RFVLEVCC2AONCLZOLK2LQ";

        public static string AzureWebApp = @"https://memoweb.azurewebsites.net";
    }
}
