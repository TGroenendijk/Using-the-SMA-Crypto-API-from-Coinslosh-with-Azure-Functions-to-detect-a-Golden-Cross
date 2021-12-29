using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Coinslosh.FunctionApp.Facades
{
    internal class CoinsloshFacade
    {
        internal CoinsloshFacade(string subscriptionKey)
        {
            SubscriptionKey = subscriptionKey;
        }

        public string SubscriptionKey { get; set; }

        private string BaseAddress = "https://api.coinslosh.com/";
        private string ApiSMA = "sma/v1/";

        #region GetUserIdByToken
        public async Task<double> GetValueSMA(int period, string market, string interval, string candleType)
        {

            double value = 0;

            using (var client = new HttpClient())
            {
                string requestUri = string.Format("{0}?period={1}&market={2}&interval={3}&type={4}", ApiSMA, period, market, interval, candleType);

                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);

                // Get all the subscriptions from API Management
                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    HttpContent cont = response.Content;

                    string content = cont.ReadAsStringAsync().Result;

                    value = double.Parse(content);
                }
            }

            return value;
        }
        #endregion
    }
}
