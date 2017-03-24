
namespace Caesars.Ibe.Bot.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Configuration;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;
    using Ibe.Service.Interfaces;
    using Model.BusinessModel;

    [Serializable]
    public class IbeRootLuisDialog : LuisDialog<object>
    {
        private IIAPSearchService _iIAPSearchService;

        public IbeRootLuisDialog(IIAPSearchService iIAPSearchService, ILuisService luis) : base(luis)
        {
            _iIAPSearchService = iIAPSearchService;
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("hotel.search")]
        public async Task Search(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var message = await activity;
            await context.PostAsync($"Welcome to the Hotels finder! We are analyzing your message: '{message.Text}'...");

            var hotelsQuery = new HotelSearchQuery();

            foreach (EntityRecommendation item in result.Entities)
            {
                switch (item.Type)
                {
                    case Constants.ENTITY_MARKET_NAME:
                        hotelsQuery.Market = item.Entity;
                        break;
                    case Constants.ENTITY_HOTEL_NAME:
                        hotelsQuery.Property = item.Entity;
                        break;
                    case Constants.ENTITY_ROOMCOUNT_NAME:
                        hotelsQuery.RoomCount = item.Entity;
                        break;
                    case Constants.ENTITY_DATE_NAME:
                        if (string.IsNullOrEmpty(hotelsQuery.CheckinDate))
                            hotelsQuery.CheckinDate = item.Entity;
                        else
                            hotelsQuery.CheckoutDate = item.Entity;
                        break;
                }
            }

            var hotelsFormDialog = new FormDialog<HotelSearchQuery>(hotelsQuery, this.BuildHotelsForm, FormOptions.PromptInStart);

            context.Call(hotelsFormDialog, this.ResumeAfterHotelsFormDialog);
        }

        [LuisIntent("help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi! Try asking me things like 'search hotels in Las Vegas starting 3/11 to 3/13', 'check rates in Caesars Palace from 3/11 to 3/13' or 'check rates'");

            context.Wait(this.MessageReceived);
        }

        private IForm<HotelSearchQuery> BuildHotelsForm()
        {
            OnCompletionAsyncDelegate<HotelSearchQuery> processHotelsSearch = async (context, state) =>
            {
                var message = "Searching for ";
                if (!string.IsNullOrEmpty(state.Market))
                {
                    message += $"hotels in {state.Market} ";
                }
                else if (!string.IsNullOrEmpty(state.Property))
                {
                    message += $"rooms in {state.Property} ";
                }
                message += $"checkin {state.CheckinDate} and checkout {state.CheckoutDate} ...";
                await context.PostAsync(message);
            };

            return new FormBuilder<HotelSearchQuery>()
                .Field(nameof(HotelSearchQuery.Market), (state) => string.IsNullOrEmpty(state.Property))
                .Field(nameof(HotelSearchQuery.Property), (state) => string.IsNullOrEmpty(state.Market))
                .Field(nameof(HotelSearchQuery.CheckinDate))
                .Field(nameof(HotelSearchQuery.CheckoutDate))
                .OnCompletion(processHotelsSearch)
                .Build();
        }

        private async Task ResumeAfterHotelsFormDialog(IDialogContext context, IAwaitable<HotelSearchQuery> result)
        {
            try
            {
                var searchQuery = await result;

                DateTime checkin, checkout;

                var hotelRequest = new HotelSearchRequest();

                hotelRequest.Market = searchQuery.Market;
                hotelRequest.Property = searchQuery.Property;
                hotelRequest.RoomCount = searchQuery.RoomCount;

                DateTime.TryParse(searchQuery.CheckinDate, out checkin);
                DateTime.TryParse(searchQuery.CheckoutDate, out checkout);

                hotelRequest.CheckinDate = checkin;
                hotelRequest.CheckoutDate = checkout;

                var response = _iIAPSearchService.GetHotels(hotelRequest);

                if (response==null || response.properties == null || response.properties.Count == 0)
                {
                    await context.PostAsync($"No matching options. Please search with a different criteria");
                }
                else
                {
                    var resultMessage = context.MakeMessage();
                    resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    resultMessage.Attachments = new List<Attachment>();
                    var property = response.properties.FirstOrDefault();
                    var rooms = property.Rooms.Where(r => r.ImageUrl != null && r.Summary != null).Take(10);
                    if (hotelRequest.Market != null)
                    {
                        await context.PostAsync($"I found below options in {property.Name}");
                    }
                    else
                    { 
                        await context.PostAsync($"I found below options:");
                    }
                    foreach (var room in rooms)
                    {
                        HeroCard heroCard = new HeroCard()
                        {
                            Title = room.Name,
                            Subtitle = $"AVG PER NIGHT:{room.AvgRate}",
                            Text = room.Summary,
                            Images = new List<CardImage>()
                        {
                            new CardImage() { Url = room.ImageUrl }
                        },
                            Buttons = new List<CardAction>()
                        {
                            new CardAction()
                            {
                                Title = "Book Room",
                                Type = ActionTypes.OpenUrl,
                                Value = $"https://www.totalrewards.com/"
                            }
                        }
                        };
                        resultMessage.Attachments.Add(heroCard.ToAttachment());
                    }
                    await context.PostAsync(resultMessage);
                }
                
            }
            catch (FormCanceledException ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation.";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }
        }
    }
}
