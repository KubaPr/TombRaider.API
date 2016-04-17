using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TombRaider.API.Core;
using TombRaider.API.Providers.TransportProvider;

namespace TombRaider.API.Controllers
{
    public class TransportController : ApiController
    {
        private ITransportProvider _transportProvider;

        public TransportController(ITransportProvider transportProvider)
        {
            _transportProvider = transportProvider;
        }
        
        public JToken Get(string type = null, double? startPointLon = null, double? startPointLat = null)
        {
            var mapPointsCollection = _transportProvider.FindLocations("abc", new Coordinates { Latitude = 1, Longtitude = 2, Type = "asd" });
            dynamic collectionWrapper = new { points = mapPointsCollection };
            var serializedMapPoints = JsonConvert.SerializeObject(collectionWrapper);

            return JToken.Parse(serializedMapPoints);
        }
    }
}
