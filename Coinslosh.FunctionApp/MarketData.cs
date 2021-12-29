using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Coinslosh.FunctionApp.Facades;


namespace Coinslosh.FunctionApp
{
    public class MarketData
    {
        [FunctionName("MarketData")]
        public async Task Run([TimerTrigger("*/30 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"[MarketData] Executed at: {DateTime.Now}");

            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("en-US");

            // Go to developer.coinslosh.com to sign up and create a subscription key
            string subscriptionKey = Environment.GetEnvironmentVariable("SubscriptionKey");
            
            int shortPeriod = 9;
            int longPeriod = 26;
            string market = "BTC-EUR";
            string interval = "30m";
            string candleType = "Candles";

            CoinsloshFacade facade = new CoinsloshFacade(subscriptionKey);
            double shortSMA = await facade.GetValueSMA(shortPeriod, market, interval, candleType);
            double longSMA = await facade.GetValueSMA(longPeriod, market, interval, candleType);

            log.LogInformation($"[MarketData] Market: {market} Short Period: {shortPeriod} SMA: {shortSMA}");
            log.LogInformation($"[MarketData] Market: {market} Long Period: {longPeriod} SMA: {longSMA}");

            if (shortSMA > longSMA)
            {
                log.LogInformation($"[MarketData] Golden Cross detected for market: {market} ");
            }            
        }
    }
}
