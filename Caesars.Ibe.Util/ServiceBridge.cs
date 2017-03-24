using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace Caesars.Ibe.Util
{
    public class ServiceBridge<T1, T2>
    {
        public static T2 Run(T1 input, ServiceTypes servicetype, HttpMethod method)
        {
            T2 output = default(T2);
            try
            {
                string GalaxyBaseUrl = ConfigurationManager.AppSettings["GalaxyBaseUrl"];
                string SiteBaseUrl = ConfigurationManager.AppSettings["SiteBaseUrl"];
                string Url = string.Empty, ServiceUrl = string.Empty;

                switch(servicetype)
                {
                    case ServiceTypes.MarketSearch:
                        ServiceUrl = ConfigurationManager.AppSettings["MarketSearchApiUrl"];
                        Url = GalaxyBaseUrl + ServiceUrl;
                        break;
                    case ServiceTypes.BranchSearch:
                        ServiceUrl = ConfigurationManager.AppSettings["BranchSearchApiUrl"];
                        Url = GalaxyBaseUrl + ServiceUrl;
                        break;
                    case ServiceTypes.HotelSearch:
                        ServiceUrl = ConfigurationManager.AppSettings["HotelSearchApiUrl"];
                        Url = GalaxyBaseUrl + ServiceUrl;
                        break;
                    case ServiceTypes.MarketPropertyContentSearch:
                        ServiceUrl = ConfigurationManager.AppSettings["MarketPropertyContentApiUrl"];
                        ServiceUrl = ServiceUrl.Replace("{MarketCode}", input.ToString());
                        Url = SiteBaseUrl + ServiceUrl;
                        break;
                    case ServiceTypes.PropertyRoomContentSearch:
                        ServiceUrl = ConfigurationManager.AppSettings["PropertyRoomContentApiUrl"];
                        ServiceUrl = ServiceUrl.Replace("{PropertyCode}", input.ToString());
                        Url = SiteBaseUrl + ServiceUrl;
                        break;
                }

                Task<string> task = RunAsync(input, Url, method);

                task.Wait();

                if(!string.IsNullOrEmpty(task.Result))
                { 
                    output = JsonConvert.DeserializeObject<T2>(task.Result);
                }
            }
            catch (Exception ex)
            {

            }

            return output;
        }

        static async Task<string> RunAsync(T1 input, string ServiceUrl, HttpMethod method)
        {
            string output = string.Empty;

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    var formatter = new JsonMediaTypeFormatter();
                    formatter.SerializerSettings = new JsonSerializerSettings()
                    {
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                    };

                    if (method == HttpMethod.Post)
                    {
                        var response = await client.PostAsync(ServiceUrl, input, formatter).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            output = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        }
                    }else if(method == HttpMethod.Get)
                    {
                        var response = await client.GetAsync(ServiceUrl).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            output = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return output;
        }
    }
}
