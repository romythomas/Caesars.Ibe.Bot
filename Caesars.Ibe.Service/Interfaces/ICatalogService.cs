using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caesars.Ibe.Model.ServiceModel;
using Caesars.Ibe.Model.BusinessModel;

namespace Caesars.Ibe.Service.Interfaces
{
    public interface ICatalogService
    {
        List<Market> GetMarkets();
        List<Branch> GetBranches();
    }
}
