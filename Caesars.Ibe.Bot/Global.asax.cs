using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Configuration;
using Autofac;
using Caesars.Ibe.Service;
using Caesars.Ibe.Service.Interfaces;
using Caesars.Ibe.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Caesars.Ibe.Bot.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs.Internals;
using System.Reflection;

namespace Caesars.Ibe.Bot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterBotDependencies();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterBotDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();

            string LuisModelId, LuisSubscriptionKey;

            LuisModelId = ConfigurationManager.AppSettings["LuisModelId"].ToString();
            LuisSubscriptionKey = ConfigurationManager.AppSettings["LuisSubscriptionKey"].ToString();

            builder.Register(c => new LuisModelAttribute(LuisModelId, LuisSubscriptionKey))
              .AsSelf()
              .AsImplementedInterfaces()
              .InstancePerDependency();

            builder.RegisterType<LuisService>()
                .Keyed<ILuisService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<IbeRootLuisDialog>()
              .As<IDialog<object>>()
              .InstancePerDependency();

            builder.RegisterType<CatalogService>()
                .Keyed<ICatalogService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<MarketingService>()
                .Keyed<IMarketingService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<IAPSearchService>()
              .Keyed<IIAPSearchService>(FiberModule.Key_DoNotSerialize)
              .AsImplementedInterfaces()
              .InstancePerDependency();

            builder.Update(Conversation.Container);

        }
    }
}
