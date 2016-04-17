using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TombRaider.API.Core;
using TombRaider.API.PoznanApiRepresentations;

namespace TombRaider.API.Providers.TransportProvider
{
    public class MockedTransportProvider : ITransportProvider
    {
        private readonly string filePath = HttpContext.Current.Server.MapPath("~/Resources/MockedResponses/mocked_poznan_api_multiple_bike_response.json"); //I found wrong filepath here (mocked_bike_response.json), now it should work

        public List<MapPoint> FindLocations(string type, Coordinates startPoint)
        {
            var jsonString = File.ReadAllText(filePath);
            var mapPoints = new List<MapPoint>();

            GetFeaturesFromFile().ForEach(f => mapPoints.Add(Mapper.Map<MapPoint>(f)));

            return mapPoints;
        }

        private List<Feature> GetFeaturesFromFile()
        {
            var jsonString = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<PoznanApiResponseRepresentation>(jsonString).Features;
        }
    }
}