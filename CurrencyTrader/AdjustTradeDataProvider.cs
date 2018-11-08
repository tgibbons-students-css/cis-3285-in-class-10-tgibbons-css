using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using CurrencyTrader.Contracts;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        ITradeDataProvider urlProvider;

        public AdjustTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradeTxt = urlProvider.GetTradeData();
            // new list of trades with substitutions in them
            List<string> newTradeTxt = new List<string>();

            foreach (string line in tradeTxt)
            {
                newTradeTxt.Add(line.Replace("GBP", "EUR"));
            }
            return newTradeTxt;
        }
    }
}
