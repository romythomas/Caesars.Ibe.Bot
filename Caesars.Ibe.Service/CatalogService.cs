using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caesars.Ibe.Service.Interfaces;
using Caesars.Ibe.Model.BusinessModel;
using Caesars.Ibe.Model.ServiceModel;
using Caesars.Ibe.Util;
using Newtonsoft.Json;

namespace Caesars.Ibe.Service
{
    public class CatalogService : ICatalogService
    {

        public CatalogService()
        {

        }
        public List<Branch> GetBranches()
        {
            var lstBranch = new List<Branch>();
            try
            {
                var response = ServiceBridge<Model.ServiceModel.BranchSearchResponse.BranchSearchResponse, Model.ServiceModel.BranchSearchResponse.BranchSearchResponse>.Run(null, ServiceTypes.BranchSearch, HttpMethod.Get);

            
                Branch branch;
                if (response != null)
                {
                    foreach (var item in response.GetBranchesResult)
                    {
                        branch = new Branch();
                        branch.Code = item.Code;
                        branch.Name = item.Name;

                        lstBranch.Add(branch);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lstBranch;
        }

        public List<Market> GetMarkets()
        {
            var lstMarket = new List<Market>();
            try
            {
                var response = ServiceBridge<Model.ServiceModel.MarketSearchResponse.MarketSearchResponse, Model.ServiceModel.MarketSearchResponse.MarketSearchResponse>.Run(null, ServiceTypes.MarketSearch, HttpMethod.Get);
                Market market;
                if (response != null)
                {
                    foreach(var item in response.GetMarketsResult)
                    {
                        market = new Market();
                        market.Code = item.Code;
                        market.Description = item.Description;
                        market.BranchList = new List<Branch>();
                        foreach(Model.ServiceModel.MarketSearchResponse.Property1 property in item.Properties)
                        {
                            market.BranchList.Add(new Branch { Code = property.Code, Name = property.Name });
                        }
                        lstMarket.Add(market);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lstMarket;
        }
    }
}
