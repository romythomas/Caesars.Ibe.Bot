using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caesars.Ibe.Model.BusinessModel;
using Caesars.Ibe.Model.ServiceModel;
using Caesars.Ibe.Service.Interfaces;
using Caesars.Ibe.Util;

namespace Caesars.Ibe.Service
{
    public class MarketingService : IMarketingService
    {
        public MarketPropertyContent GetMarketPropertyContents(string MarketCode)
        {
            var objMarketPropertyContent = new MarketPropertyContent();

            try
            {
                var response = ServiceBridge<string, List<Model.ServiceModel.MarketPropertyContentResponse.MarketPropertyContentResponse>>.Run(MarketCode, ServiceTypes.MarketPropertyContentSearch, HttpMethod.Get);

                objMarketPropertyContent.PropertyContents = new List<PropertyContent>();
                PropertyContent objPropertyContent;
                if (response!= null)
                {
                    var objProperties = response.FirstOrDefault();

                    foreach (var item in response)
                    {
                        objPropertyContent = new PropertyContent();
                        objPropertyContent.Market = item.marketCode;
                        objPropertyContent.PropertyCode = item.property;
                        objPropertyContent.PropertyName = item.propertyName;
                        objPropertyContent.Summary = item.summary;
                        objPropertyContent.ImageUrl = item.thumbnail.url;

                        objMarketPropertyContent.PropertyContents.Add(objPropertyContent);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objMarketPropertyContent;
        }

        public PropertyRoomContent GetPropertyRoomContents(string PropertyCode)
        {
            var objPropertyRoomContent = new PropertyRoomContent();

            try
            {
                var response = ServiceBridge<string, List<Model.ServiceModel.PropertyRoomContentResponse.PropertyRoomContentResponse>>.Run(PropertyCode, ServiceTypes.PropertyRoomContentSearch, HttpMethod.Get);

                objPropertyRoomContent.RoomContents = new List<RoomContent>();
                RoomContent objRoomContent;

                if (response != null)
                {
                    var objRoom = response.FirstOrDefault();
                    if (objRoom != null)
                    {
                        objPropertyRoomContent.Market = objRoom.market;
                        objPropertyRoomContent.PropertyCode = objRoom.property;
                        objPropertyRoomContent.PropertyName = objRoom.propertyName;
                    }
                    foreach (var item in response)
                    {
                        objRoomContent = new RoomContent();
                        objRoomContent.Name = item.name;
                        objRoomContent.Summary = item.summary;
                        objRoomContent.ImageUrl = item.thumbnail.url;

                        objPropertyRoomContent.RoomContents.Add(objRoomContent);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objPropertyRoomContent;
        }
    }
}
