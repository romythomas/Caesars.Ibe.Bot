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
using System.Configuration;

namespace Caesars.Ibe.Service
{
    public class IAPSearchService : IIAPSearchService
    {
        private ICatalogService _iCategryService;
        private IMarketingService _iMarketingService;

        public IAPSearchService()
        {

        }
        public IAPSearchService(ICatalogService iCatalogService, IMarketingService iMarketingService)
        {
            _iCategryService = iCatalogService;
            _iMarketingService = iMarketingService;
        }

        public HotelSearchResponse GetHotels(HotelSearchRequest objRequest)
        {
            MarketPropertyContent objMarketPropertyContent = null;
            List<PropertyRoomContent> lstPropertyRoomContent = new List<PropertyRoomContent>();
            PropertyRoomContent objPropertyRoomContent;
            var objHotelSearchResponse = new HotelSearchResponse();

            try
            {
                var SiteBaseUrl = ConfigurationManager.AppSettings["SiteBaseUrl"].ToString();
                var objHotelSearchRequest = new Model.ServiceModel.HotelSearchRequest.HotelSearchRequest();
                objHotelSearchRequest.request = new Model.ServiceModel.HotelSearchRequest.Request();
                objHotelSearchRequest.request.__type = "SearchRequest";
                objHotelSearchRequest.request.AppKey = "IAPTestWebsite";

                objHotelSearchRequest.request.Criteria = new Model.ServiceModel.HotelSearchRequest.Criteria();
                objHotelSearchRequest.request.Criteria.__type = "HotelCriteria";

                if (!string.IsNullOrEmpty(objRequest.Market))
                {
                    var lstMarkets = _iCategryService.GetMarkets();
                    var objMarket = lstMarkets.Where(item => item.Description.ToLower().Contains(objRequest.Market.ToLower())).FirstOrDefault();

                    if (objMarket!=null)
                    {
                        string[] locations = new string[objMarket.BranchList.Count];
                        for(int i=0; i< objMarket.BranchList.Count; i++)
                        {
                            locations[i] = objMarket.BranchList[i].Code;
                        }
                        objHotelSearchRequest.request.Criteria.Locations = locations;

                        //Need to change this based on the design
                        //objMarketPropertyContent=_iMarketingService.GetMarketPropertyContents(objMarket.Code);

                        //foreach(var item in objMarketPropertyContent.PropertyContents)
                        //{
                        //    objPropertyRoomContent = _iMarketingService.GetPropertyRoomContents(item.PropertyCode);
                        //    lstPropertyRoomContent.Add(objPropertyRoomContent);
                        //}
                    }
                    else
                    {
                        return objHotelSearchResponse;
                    }
                }
                else if(!string.IsNullOrEmpty(objRequest.Property))
                {
                    string[] locations = new string[1];
                    var lstBranches = _iCategryService.GetBranches();
                    if (objRequest.Property.Length == 3)
                    {
                        var objBranch = lstBranches.Where(item => item.Code.ToLower() == objRequest.Property.ToLower()).FirstOrDefault();

                        if (objBranch != null)
                        {
                            locations[0] = objBranch.Code;
                            //Need to change this based on the design
                            //objPropertyRoomContent = _iMarketingService.GetPropertyRoomContents(objBranch.Code);
                            //lstPropertyRoomContent.Add(objPropertyRoomContent);
                        }
                        else
                        {
                            objBranch = lstBranches.Where(item => item.Name.ToLower() == objRequest.Property.ToLower()).FirstOrDefault();
                            if (objBranch != null)
                            {
                                locations[0] = objBranch.Code;
                            }
                            else
                            {
                                return objHotelSearchResponse;
                            }
                        }
                    }
                    else
                    {
                        var objBranch = lstBranches.Where(item => item.Name.ToLower().Contains(objRequest.Property.ToLower())).FirstOrDefault();

                        if(objBranch!= null)
                        {
                            locations[0] = objBranch.Code;
                            //Need to change this based on the design
                            //objPropertyRoomContent = _iMarketingService.GetPropertyRoomContents(objBranch.Code);
                            //lstPropertyRoomContent.Add(objPropertyRoomContent);
                        }
                        else
                        {
                            return objHotelSearchResponse;
                        }
                    }
                    objHotelSearchRequest.request.Criteria.Locations = locations;
                }
                objHotelSearchRequest.request.Criteria.EndDate = objRequest.CheckoutDate.ToString("yyyy-MM-dd");
                objHotelSearchRequest.request.Criteria.HotelRoomDetails = new Model.ServiceModel.HotelSearchRequest.Hotelroomdetail[1];
                objHotelSearchRequest.request.Criteria.HotelRoomDetails[0] = new Model.ServiceModel.HotelSearchRequest.Hotelroomdetail();
                objHotelSearchRequest.request.Criteria.HotelRoomDetails[0].Adults = 2;
                objHotelSearchRequest.request.Criteria.HotelRoomDetails[0].Children = 0;
                objHotelSearchRequest.request.Criteria.HotelRoomDetails[0].__type = "HotelRoomDetail";
                objHotelSearchRequest.request.Criteria.LengthOfStays = new int[1];
                objHotelSearchRequest.request.Criteria.LengthOfStays[0] = (objRequest.CheckoutDate - objRequest.CheckinDate).Days;
                objHotelSearchRequest.request.Criteria.StartDate = objRequest.CheckinDate.ToString("yyyy-MM-dd");
                objHotelSearchRequest.request.GroupCode = "";
                objHotelSearchRequest.request.Requestor = "Galaxy Test Harness";
                objHotelSearchRequest.request.SecurityToken = "";
                objHotelSearchRequest.request.SelectionAttributes = new Model.ServiceModel.HotelSearchRequest.Selectionattribute[1];
                objHotelSearchRequest.request.SelectionAttributes[0] = new Model.ServiceModel.HotelSearchRequest.Selectionattribute();
                objHotelSearchRequest.request.SelectionAttributes[0].__type = "Attr";
                objHotelSearchRequest.request.SelectionAttributes[0].Id = 0;
                objHotelSearchRequest.request.SelectionAttributes[0].Name = "pruning";
                objHotelSearchRequest.request.SelectionAttributes[0].Value = "LowestPromoAndAllOtherQuotes";
                objHotelSearchRequest.request.TransactionStartTime = DateTime.UtcNow;

                var response = ServiceBridge<Model.ServiceModel.HotelSearchRequest.HotelSearchRequest, Model.ServiceModel.HotelSearchResponse.HotelSearchResponse>.Run(objHotelSearchRequest, ServiceTypes.HotelSearch, HttpMethod.Post);
                objHotelSearchResponse.properties = new List<Property>();
                Property objProperty;
                Room objRoom;
                if (response != null)
                {
                    foreach (var productType in response.ProductTypes)
                    {
                        foreach (var product in productType.Products)
                        {
                            objProperty = new Property();
                            objProperty.Name = product.Name;

                            if (objMarketPropertyContent!= null)
                            {
                                var ojPropertyContent = objMarketPropertyContent.PropertyContents.Where(p => p.PropertyName == product.Name).FirstOrDefault();
                                if(ojPropertyContent!=null)
                                {
                                    objProperty.Summary = ojPropertyContent.Summary;
                                    objProperty.ImageUrl = ojPropertyContent.ImageUrl;
                                }
                            }
                            //Need to change this based on the design
                            objPropertyRoomContent = _iMarketingService.GetPropertyRoomContents(product.Location.Code);
                            lstPropertyRoomContent.Add(objPropertyRoomContent);

                            var lstRoomContents = lstPropertyRoomContent.Where(p => p.PropertyName == product.Name).FirstOrDefault();
                            objProperty.Rooms = new List<Room>();
                            foreach (var sku in product.SKUs)
                            {
                                objRoom = new Room();
                                objRoom.Name = sku.Name;
                                if (sku.Quotes[0] != null)
                                {
                                    objRoom.AvgRate = sku.Quotes[0].Avg;
                                }
                                var objRoomContent = lstRoomContents.RoomContents.Where(r => r.Name == sku.Name).FirstOrDefault();

                                if(objRoomContent!= null)
                                {
                                    objRoom.Summary = objRoomContent.Summary;
                                    objRoom.ImageUrl = SiteBaseUrl + objRoomContent.ImageUrl;
                                }

                                objProperty.Rooms.Add(objRoom);
                            }

                            objHotelSearchResponse.properties.Add(objProperty);
                            break;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objHotelSearchResponse;
        }
    }
}
