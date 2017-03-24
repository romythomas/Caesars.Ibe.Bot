namespace Caesars.Ibe.Bot
{
    using System;
    using Microsoft.Bot.Builder.FormFlow;

    [Serializable]
    public class HotelSearchQuery
    {
        [Prompt("Location (Las Vegas) ?")]
        [Optional]
        public string Market { get; set; }

        [Prompt("Hotel (Caesars Palace) ?")]
        [Optional]
        public string Property { get; set; }

        [Prompt("Room count ?")]
        [Optional]
        public string RoomCount { get; set; }

        [Prompt("Checkin (mm/dd) ?")]
        [Optional]
        public string CheckinDate { get; set; }

        [Prompt("Checkout (mm/dd) ?")]
        [Optional]
        public string CheckoutDate { get; set; }
    }
}