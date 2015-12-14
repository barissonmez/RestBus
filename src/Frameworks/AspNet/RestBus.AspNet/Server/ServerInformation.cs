﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using RestBus.Common;

namespace RestBus.AspNet.Server
{
    internal class ServerInformation : IServerInformation
    {
        public ServerInformation(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            Addresses = GetAddresses(configuration);
        }

        public ICollection<string> Addresses { get; }

        public IRestBusSubscriber Subscriber { get; internal set; }

        private static ICollection<string> GetAddresses(IConfiguration configuration)
        {
            var addresses = new List<string>();

            var urls = configuration["server.urls"];

            if (!string.IsNullOrEmpty(urls))
            {
                addresses.Add(urls);
            }

            return addresses.AsReadOnly();
        }
    }
}
