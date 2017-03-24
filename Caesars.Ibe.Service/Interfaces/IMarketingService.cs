using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caesars.Ibe.Model.BusinessModel;

namespace Caesars.Ibe.Service.Interfaces
{
    public interface IMarketingService
    {
        MarketPropertyContent GetMarketPropertyContents(string MarketCode);
        PropertyRoomContent GetPropertyRoomContents(string PropertyCode);
    }
}
